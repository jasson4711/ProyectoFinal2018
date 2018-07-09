using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AluminiosEntidades;
using AluminiosNegocio;


namespace VentaPresentacion
{
    public partial class GestionarEmpleados : Form
    {
        EmpleadoEntidad empleadoActual = new EmpleadoEntidad();
        List<EmpleadoEntidad> listaEmpleados = new List<EmpleadoEntidad>();
        string opcionToolStrip = "";

        public GestionarEmpleados()
        {
            InitializeComponent();
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
            txtSueldo.Enabled = v;
            txtContraseña.Enabled = v;
        }

        private void CargarDataGridClientes()
        {
            dataGridViewClientes.DataSource = EmpleadoNegocio.DevolverListaEmpleados();
        }

        private void GestionarEmpleados_Load(object sender, EventArgs e)
        {
            CargarDataGridClientes();
        }

        private void BuscarEmpleado()
        {
            if (!txtBuscar.Text.Equals(""))
            {
                if (radioButtonCedula.Checked)
                {
                    empleadoActual = EmpleadoNegocio.DevolverEmpleadoPorCedula(txtBuscar.Text);
                    if (empleadoActual.Id!=0)
                    {
                        cargarEmpleadoPorCedula();
                    }else
                        MessageBox.Show("Sin resultados. Verifique si la cedula es correcta");

                }
                else if (radioButtonApellido.Checked)
                {
                    listaEmpleados = EmpleadoNegocio.DevolverEmpleadoPorApellido(txtBuscar.Text);
                    dataGridViewClientes.DataSource = listaEmpleados;
                }
                else
                    MessageBox.Show("Seleccione un metodo de busqueda");

            }
            else
            {
                MessageBox.Show("Ingrese un valor para buscar");
            }
        }

        private void cargarEmpleadoPorCedula()
        {
            txtId.Text = empleadoActual.Id.ToString();
            txtNombre.Text = empleadoActual.Nombre;
            txtApellido.Text = empleadoActual.Apellido;
            txtCedula.Text = empleadoActual.Cedula;
            txtDireccion.Text = empleadoActual.Direccion;
            txtEmail.Text = empleadoActual.Email;
            txtTelefono.Text = empleadoActual.Telefono;
            txtSueldo.Text = empleadoActual.Sueldo.ToString();
            txtContraseña.Text = MetodosAyuda.Encriptacion.DecriptarDatos(empleadoActual.Contraseña);
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
                EstablecerEmpleadoActual();
            }
            catch (Exception)
            {
            }
        }

        private void EstablecerEmpleadoActual()
        {
            if (txtId.Text == "")
            {
                empleadoActual.Id = 0;
            }
            else
                empleadoActual.Id = Convert.ToInt32(txtId.Text);
            empleadoActual.Nombre = txtNombre.Text;
            empleadoActual.Apellido = txtApellido.Text;
            empleadoActual.Cedula = txtCedula.Text;
            empleadoActual.Direccion = txtDireccion.Text;
            empleadoActual.Email = txtEmail.Text;
            empleadoActual.Telefono = txtTelefono.Text;
            empleadoActual.Sueldo = Convert.ToDouble( txtSueldo.Text);
            empleadoActual.Contraseña = txtContraseña.Text;
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
            if (txtId.Text == "")
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
            if (txtId.Text == "")
            {
                MessageBox.Show("Busque o seleccione un cliente para Eliminar");
            }
            else
            {
                if (MessageBox.Show("Desea realmente elminar la informacion de la base de datos?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    EstablecerEmpleadoActual();
                    EmpleadoNegocio.EliminarEmpleado(empleadoActual);
                    HabilitarControlesMenu(false);
                    HabilitarControlesIngreso(false);
                    CargarDataGridClientes();
                    limpiarIngreso();
                }
            }
        }

        private bool validarDatosEntrada()
        {
            if (txtCedula.Text == "" || txtNombre.Text == "" || txtApellido.Text == ""
                || txtDireccion.Text == "" || txtTelefono.Text == "" || txtEmail.Text == ""
                || txtSueldo.Text == "" || txtContraseña.Text == "")
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
        private void toolStripGuardar_Click(object sender, EventArgs e)
        {
            if (validarDatosEntrada())
            {
                if (opcionToolStrip == "nuevo")
                {
                    EstablecerEmpleadoActual();
                    empleadoActual.Contraseña = MetodosAyuda.Encriptacion.encriptarDatos(txtContraseña.Text);
                    EmpleadoNegocio.GuardarEmpleado(empleadoActual);
                    MessageBox.Show("Nuevo empleado guardado con exito");
                }
                else if (opcionToolStrip == "modificar")
                {
                    EstablecerEmpleadoActual();
                    empleadoActual.Contraseña = MetodosAyuda.Encriptacion.encriptarDatos(txtContraseña.Text);
                    EmpleadoNegocio.ActualizarEmpleado(empleadoActual);
                    MessageBox.Show("Empleado actualizado con exito");
                }
                dataGridViewClientes.DataSource = null;
                CargarDataGridClientes();
                HabilitarControlesMenu(false);
                limpiarIngreso();
            }
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
            txtApellido.Text = "";
            txtCedula.Text = "";
            txtDireccion.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";
            txtSueldo.Text = "";
            txtContraseña.Text = "";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CargarDataGridClientes();
        }

        private void pbBuscar_Click(object sender, EventArgs e)
        {
            BuscarEmpleado();
        }

        private void dataGridViewClientes_CellClick_1(object sender, DataGridViewCellEventArgs e)
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
                txtSueldo.Text = row.Cells["sueldo"].Value.ToString();
                txtContraseña.Text =MetodosAyuda.Encriptacion.DecriptarDatos( row.Cells["contraseña"].Value.ToString());
                EstablecerEmpleadoActual();
            }
            catch (Exception)
            {
            }
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
