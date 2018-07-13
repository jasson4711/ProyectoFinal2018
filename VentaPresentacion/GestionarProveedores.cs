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
    public partial class GestionarProveedores : Form
    {
        ProveedorEntidad proveedorActual = new ProveedorEntidad();
        List<ProveedorEntidad> listaProveedores = new List<ProveedorEntidad>();
        string opcionToolStrip = "";
        public GestionarProveedores()
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
           
            txtDireccion.Enabled = v;
            txtEmail.Enabled = v;
            txtTelefono.Enabled = v;
            
        }

        private void CargarDataGridClientes()
        {
            dataGridViewClientes.DataSource = ProveedorNegocio.DevolverListaProveedores();
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
        private void limpiarIngreso()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            
            txtDireccion.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";
            
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
                txtNombre.Focus();
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
                    EstablecerProveedorActual();
                    ProveedorNegocio.EliminarProveedor(proveedorActual);
                    HabilitarControlesMenu(false);
                    HabilitarControlesIngreso(false);
                    CargarDataGridClientes();
                    limpiarIngreso();
                }
            }
        }

        private void EstablecerProveedorActual()
        {
            if (txtId.Text == "")
            {
                proveedorActual.Id = 0;
            }
            else
                proveedorActual.Id = Convert.ToInt32(txtId.Text);
            proveedorActual.Nombre = txtNombre.Text;
           
            proveedorActual.Direccion = txtDireccion.Text;
            proveedorActual.Email = txtEmail.Text;
            proveedorActual.Telefono = txtTelefono.Text;
            
        }

        private void toolStripGuardar_Click(object sender, EventArgs e)
        {
            if (validarDatosEntrada())
            {
                if (opcionToolStrip == "nuevo")
                {
                    EstablecerProveedorActual();
                    ProveedorNegocio.GuardarProveedor(proveedorActual);
                    MessageBox.Show("Nuevo proveedor guardado con exito");
                }
                else if (opcionToolStrip == "modificar")
                {
                    EstablecerProveedorActual();
                    ProveedorNegocio.ActualizarProveedor(proveedorActual);
                    MessageBox.Show("Proveedor actualizado con exito");
                }
                dataGridViewClientes.DataSource = null;
                CargarDataGridClientes();
                HabilitarControlesMenu(false);
                limpiarIngreso();
            }
        }

        private bool validarDatosEntrada()
        {
            if (txtNombre.Text == "" || txtDireccion.Text == "" || txtTelefono.Text == "" || txtEmail.Text == "")
            {
                MessageBox.Show("Ingrese correctamente todos los campos");
                txtNombre.Focus();
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

        private void pbBuscar_Click(object sender, EventArgs e)
        {
            BuscarProveedor();
        }

        private void BuscarProveedor()
        {
            if (!txtBuscar.Text.Equals(""))
            {

                    listaProveedores = ProveedorNegocio.DevolverProveedorPorNombre(txtBuscar.Text);
                    dataGridViewClientes.DataSource = listaProveedores;
                }
                else
                    MessageBox.Show("Ingrese datos en el campo de busqueda");

        }

        private void dataGridViewClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;

                DataGridViewRow row = this.dataGridViewClientes.Rows[index];

                txtId.Text = row.Cells["Id"].Value.ToString();
                txtNombre.Text = row.Cells["nombre"].Value.ToString();
               
                txtDireccion.Text = row.Cells["direccion"].Value.ToString();
                txtEmail.Text = row.Cells["email"].Value.ToString();
                txtTelefono.Text = row.Cells["telefono"].Value.ToString();
                
                EstablecerProveedorActual();
            }
            catch (Exception)
            {
            }
        }

        private void GestionarProveedores_Load(object sender, EventArgs e)
        {
            CargarDataGridClientes();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CargarDataGridClientes();
        }
    }
}
