using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetodosAyuda;
using AluminiosEntidades;
using AluminiosNegocio;

namespace VentaPresentacion
{
    public partial class Login : Form
    {
        
        public Login()
        {

            InitializeComponent();
    }

    private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ValidarDatos();

        }

        EmpleadoEntidad empleadoActual = new EmpleadoEntidad();
        private void ValidarDatos()
        {
            string contraseña = MetodosAyuda.Encriptacion.encriptarDatos(textBoxContraseña.Text);

            empleadoActual = EmpleadoNegocio.DevolverEmpleadoPorCedula(textBoxUsuario.Text);

            if (contraseña.Equals(empleadoActual.Contraseña))
            {
                MenuPresentacion menu = new MenuPresentacion(empleadoActual);
                //this.Close();
                menu.Show();
                Visible = false;
                
            }
            else
            {
                label3.Visible = true;
                textBoxUsuario.Focus();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void textBoxUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e, textBoxUsuario.Text);
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
