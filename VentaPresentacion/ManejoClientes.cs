using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AluminiosNegocio;
using AluminiosEntidades;

namespace VentaPresentacion
{
    public partial class ManejoClientes : Form
    {
        ClienteEntidad clienteActual = new ClienteEntidad();
        List<ClienteEntidad> ListaClientes = new List<ClienteEntidad>();
        string opcionToolStrip = "";
        EmpleadoEntidad empleado = new EmpleadoEntidad();

        public ManejoClientes(EmpleadoEntidad empleadoActual)
        {
            InitializeComponent();
            empleado = empleadoActual;
        }

        private void toolStripEditar_Click(object sender, EventArgs e)
        {
            HabilitarControlesMenu(true);
        }
        private void HabilitarControlesMenu(bool v)
        {
            toolStripNuevo.Enabled = v;
            toolStripActualizar.Enabled = v;
            toolStripEliminar.Enabled = v;
            toolStripGuardar.Enabled = v;
            toolStripCancelar.Enabled = v;

            toolStripEditar.Enabled = !v;
        }

        private void HabilitarControlesIngreso(bool v)
        {
            txtNombre.Enabled = v;
            txtApellido.Enabled = v;
            txtCedula.Enabled = v;
            txtDireccion.Enabled = v;
            txtEmail.Enabled = v;
            txtTelefono.Enabled = v;
        }

        private void ManejoClientes_Load(object sender, EventArgs e)
        {
            try
            {
                CargarDataGridClientes();
            }
            catch
            {
                MessageBox.Show("No se han podido mostrar los datos");
                this.Close();
            }

        }

        private void CargarDataGridClientes()
        {
            dataGridViewClientes.DataSource = ClienteNegocio.DevolverListaClientes();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pbBuscar_Click(object sender, EventArgs e)
        {
            BuscarCliente();
        }


        private void BuscarCliente()
        {
            if (!txtBuscar.Text.Equals(""))
            {
                if (radioButtonCedula.Checked)
                {
                    clienteActual = ClienteNegocio.DevolverClientePorCedula(txtBuscar.Text);
                    if (clienteActual.Id!=0)
                        cargarClientePorCedula();
                    else
                        MessageBox.Show("Sin resultados. Verifique si la cedula es correcta");
                }
                else if (radioButtonApellido.Checked)
                {
                    ListaClientes = ClienteNegocio.DevolverClientePorApellido(txtBuscar.Text);
                    dataGridViewClientes.DataSource = ListaClientes;
                }else
                    MessageBox.Show("Seleccione un metodo de busqueda");

            }
            else
            {
                MessageBox.Show("Ingrese un valor para buscar");
            }
        }

        private void cargarClientePorCedula()
        {
            txtId.Text = clienteActual.Id.ToString();
            txtNombre.Text = clienteActual.Nombre;
            txtApellido.Text = clienteActual.Apellido;
            txtCedula.Text = clienteActual.Cedula;
            txtDireccion.Text = clienteActual.Direccion;
            txtEmail.Text = clienteActual.Email ;
            txtTelefono.Text = clienteActual.Telefono;
        }

        private void dataGridViewClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;

                DataGridViewRow row = this.dataGridViewClientes.Rows[index];

                txtId.Text = row.Cells["Id"].Value.ToString();
                txtNombre.Text = row.Cells["nombre"].Value.ToString();
                txtApellido.Text = row.Cells["apellido"].Value.ToString();
                txtCedula.Text = row.Cells["cedula"].Value.ToString();
                txtDireccion.Text = row.Cells["direccion"].Value.ToString();
                txtEmail.Text = row.Cells["email"].Value.ToString();
                txtTelefono.Text = row.Cells["telefono"].Value.ToString();
                EstablecerClienteActual();
            }
            catch (Exception)
            {
            }
        }

        private void EstablecerClienteActual()
        {
            if (txtId.Text=="")
            {
                clienteActual.Id = 0;
            }else
                clienteActual.Id = Convert.ToInt32(txtId.Text);
            clienteActual.Nombre = txtNombre.Text;
            clienteActual.Apellido = txtApellido.Text;
            clienteActual.Cedula = txtCedula.Text;
            clienteActual.Direccion = txtDireccion.Text;
            clienteActual.Email = txtEmail.Text;
            clienteActual.Telefono = txtTelefono.Text;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripNuevo_Click(object sender, EventArgs e)
        {
            HabilitarControlesIngreso(true);
            HabilitarControlesMenuNuevo(true);
            opcionToolStrip = "nuevo";
            limpiarIngreso();
        }

        private void HabilitarControlesMenuNuevo(bool v)
        {
            toolStripNuevo.Enabled = !v;
            toolStripActualizar.Enabled = !v;
            toolStripEliminar.Enabled = !v;
            toolStripGuardar.Enabled = v;
            toolStripCancelar.Enabled = v;

            toolStripEditar.Enabled = !v;
        }

        private void toolStripActualizar_Click(object sender, EventArgs e)
        {
            if (txtId.Text=="")
            {
                MessageBox.Show("Busque o seleccione un cliente para modificarlo");
            }
            else
            {
                HabilitarControlesMenuActualizar(true);
                HabilitarControlesIngreso(true);
                txtCedula.Focus();
                opcionToolStrip = "modificar";
            }
            
        }

        private void HabilitarControlesMenuActualizar(Boolean v)
        {
            toolStripNuevo.Enabled = !v;
            toolStripActualizar.Enabled = v;
            toolStripEliminar.Enabled = !v;
            toolStripGuardar.Enabled = v;
            toolStripCancelar.Enabled = v;

            toolStripEditar.Enabled = !v;
        }

        private void toolStripEliminar_Click(object sender, EventArgs e)
        {
            if (empleado.Cargo == "cajero")
            {
                MessageBox.Show("Usted no cuenta con los permisos necesarios para la elminacion de clientes");
            }
            else
            {
                if (txtId.Text == "")
                {
                    MessageBox.Show("Busque o seleccione un cliente para Eliminar");
                }
                else
                {
                    if (MessageBox.Show("Desea realmente elminar la informacion de la base de datos?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        EstablecerClienteActual();
                        ClienteNegocio.EliminarCliente(clienteActual);
                        HabilitarControlesMenu(false);
                        HabilitarControlesIngreso(false);
                        CargarDataGridClientes();
                        limpiarIngreso();
                    }
                }
            }
        }

        private void toolStripGuardar_Click(object sender, EventArgs e)
        {
            if (validarDatosEntrada())
            {
                if (opcionToolStrip == "nuevo")
                {
                    EstablecerClienteActual();
                    ClienteNegocio.GuardarCliente(clienteActual);
                    MessageBox.Show("Nuevo cliente guardado con exito");
                }
                else if (opcionToolStrip == "modificar")
                {
                    EstablecerClienteActual();
                    ClienteNegocio.ActualizarCliente(clienteActual);
                    MessageBox.Show("Cliente actualizado con exito");
                }
                dataGridViewClientes.DataSource = null;
                CargarDataGridClientes();
            }
        }

        private bool validarDatosEntrada()
        {
            if (txtCedula.Text == "" || txtNombre.Text == "" || txtApellido.Text == ""
                || txtDireccion.Text == "" || txtTelefono.Text == "" || txtEmail.Text == "")
            {
                MessageBox.Show("Ingrese correctamente todos los campos");
                txtCedula.Focus();
                return false;
            }
            else if (!MetodosAyuda.Metodos.verificadorCédula(txtCedula.Text))
            {
                MessageBox.Show("Ingrese una cedula valida");
                txtCedula.Focus();
                return false;
            }
            else
                return true;
        }

        private void toolStripCancelar_Click(object sender, EventArgs e)
        {
            HabilitarControlesMenu(false);
            HabilitarControlesIngreso(false);
            limpiarIngreso();
        }

        private void limpiarIngreso()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtApellido.Text= "";
            txtCedula.Text = "";
            txtDireccion.Text= "";
            txtEmail.Text = "";
            txtTelefono.Text= "";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CargarDataGridClientes();
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e, txtTelefono.Text);
        }

        private void SoloNumeros(KeyPressEventArgs e, string texto)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) || texto.Length >= 10)
            {
                //MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }
    }
}
