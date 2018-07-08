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
    public partial class VentaPresentacion : Form
    {
        ClienteEntidad clienteActual = new ClienteEntidad();
        public VentaPresentacion()
        {
            InitializeComponent();
        }

        private void pictureBoxBuscar_Click(object sender, EventArgs e)
        {
            SeleccionarClientes frm = new SeleccionarClientes();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                clienteActual = ClienteNegocio.DevolverClientePorID(frm.IdCliente);

                txtId.Text = clienteActual.Id.ToString();
                txtNombre.Text = clienteActual.Nombre;
                txtApellido.Text = clienteActual.Apellido;
                txtCedula.Text = clienteActual.Cedula;
                txtDireccion.Text = clienteActual.Direccion;
                txtTelefono.Text = clienteActual.Telefono;
            }

        }

        private void btnCancelarFactura_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea cancelar?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
