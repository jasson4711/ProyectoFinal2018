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
namespace VentaPresentacion
{
    public partial class MenuPresentacion : Form
    {
        public EmpleadoEntidad empleadoActual = new EmpleadoEntidad();
        public MenuPresentacion(EmpleadoEntidad empleado)
        {
            InitializeComponent();
            empleadoActual = empleado;
            lblEmpleado.Text += empleadoActual.Nombre + " " + empleadoActual.Apellido;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit(); 
            
        }

        private void buttonVentas_Click(object sender, EventArgs e)
        {
            VentaPresentacion venta = new VentaPresentacion(empleadoActual.Id);
            venta.ShowDialog();
        }

        private void buttonClientes_Click(object sender, EventArgs e)
        {
            ManejoClientes clientes = new ManejoClientes(empleadoActual);
            clientes.ShowDialog();
        }

        private void buttonEmpleados_Click(object sender, EventArgs e)
        {
            GestionarEmpleados empleados = new GestionarEmpleados();
            empleados.ShowDialog();
        }

        private void buttonProductos_Click(object sender, EventArgs e)
        {
            SeleccionarProducto productos = new SeleccionarProducto(false);
            productos.ShowDialog();
        }
    }
}
