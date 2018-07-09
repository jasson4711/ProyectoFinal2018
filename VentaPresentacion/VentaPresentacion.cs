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
            LimpiarCampos();
        }

        private void pictureBoxBuscar_Click(object sender, EventArgs e)
        {

            SeleccionarClientes frm = new SeleccionarClientes();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                clienteActual = ClienteNegocio.DevolverClientePorID(frm.IdCliente);
                LlenarCamposTextoCliente();
            }



        }

        private void LlenarCamposTextoCliente()
        {
            txtId.Text = clienteActual.Id.ToString();
            txtNombre.Text = clienteActual.Nombre;
            txtApellido.Text = clienteActual.Apellido;
            txtCedula.Text = clienteActual.Cedula;
            txtDireccion.Text = clienteActual.Direccion;
            txtTelefono.Text = clienteActual.Telefono;
            txtEmail.Text = clienteActual.Email;
            HabilitarBotonesParaEdicionCliente(true);
        }

        private void HabilitarBotonesParaEdicionCliente(bool v)
        {
            btnActualizar.Enabled = v;
            btnLimpiar.Enabled = v;
            btnGuardar.Enabled = !v;
        }

        private void btnCancelarFactura_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea cancelar?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtApellido.Text = "";
            txtCedula.Text = "";
            txtDireccion.Text = "";
            txtId.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            txtCedula.Focus();
            clienteActual = null;
            HabilitarBotonesParaEdicionCliente(false);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampos())
                {
                    ClienteEntidad clienteModificado = EstablecerCliente();
                    ClienteNegocio.ActualizarCliente(clienteModificado);
                    clienteActual = clienteModificado;
                    LlenarCamposTextoCliente();
                }
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error al intentar actualizar");
            }


        }

        private ClienteEntidad EstablecerCliente()
        {
            ClienteEntidad cliente = new ClienteEntidad();
            if (txtId.Text.Length > 0)
            {
                cliente.Id = Convert.ToInt32(txtId.Text);
                cliente.Cedula = txtCedula.Text.ToUpper();
                cliente.Nombre = txtNombre.Text.ToUpper();
                cliente.Apellido = txtApellido.Text.ToUpper();
                cliente.Direccion = txtDireccion.Text.ToUpper();
                cliente.Telefono = txtTelefono.Text.ToUpper();
                cliente.Email = txtEmail.Text;
            }
            else
            {
                cliente.Cedula = txtCedula.Text.ToUpper();
                cliente.Nombre = txtNombre.Text.ToUpper();
                cliente.Apellido = txtApellido.Text.ToUpper();
                cliente.Direccion = txtDireccion.Text.ToUpper();
                cliente.Telefono = txtTelefono.Text.ToUpper();
                cliente.Email = txtEmail.Text;
            }


            return cliente;
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) || txtApellido.Text.Length >= 30)
            {
                //MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) || txtNombre.Text.Length >= 30)
            {
                //MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) || txtTelefono.Text.Length >= 10)
            {
                //MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampos())
                {
                    clienteActual = null;
                    clienteActual = EstablecerCliente();
                    ClienteNegocio.GuardarCliente(clienteActual);
                    LlenarCamposTextoCliente();
                }
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error al intentar insertar");
            }

        }

        private bool ValidarCampos()
        {
            if (txtCedula.Text == "")
            {
                txtCedula.Focus();
                MessageBox.Show("Ingrese una cédula correcta");
                return false;
            }
            else if (txtApellido.Text == "")
            {
                txtApellido.Focus();
                MessageBox.Show("Ingrese su apellido");
                return false;
            }
            else if (txtNombre.Text == "")
            {
                txtNombre.Focus();
                MessageBox.Show("Ingrese su nombre");
                return false;
            }
            
            else if (txtDireccion.Text == "")
            {
                txtDireccion.Focus();
                MessageBox.Show("Ingrese su dirección");
                return false;
            }
            else if (txtTelefono.Text == "")
            {
                txtTelefono.Focus();
                MessageBox.Show("Ingrese su teléfono");
                return false;
            }
            //else if (txtEmail.Text == "")
            //{
            //    txtEmail.Focus();
            //    MessageBox.Show("Ingrese su email");
            //    return false;
            //}
            else
            {
                return true;
            }
        }
    }
}
