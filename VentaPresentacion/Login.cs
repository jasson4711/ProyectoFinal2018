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
                MenuPresentacion menu = new MenuPresentacion();
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
    }
}
