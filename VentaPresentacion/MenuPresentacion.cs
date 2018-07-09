using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VentaPresentacion
{
    public partial class MenuPresentacion : Form
    {
        public MenuPresentacion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonVentas_Click(object sender, EventArgs e)
        {
            VentaPresentacion venta = new VentaPresentacion();
            venta.ShowDialog();
        }

        private void buttonClientes_Click(object sender, EventArgs e)
        {
            ManejoClientes clientes = new ManejoClientes();
            clientes.ShowDialog();
        }

        private void buttonEmpleados_Click(object sender, EventArgs e)
        {
            GestionarEmpleados empleados = new GestionarEmpleados();
            empleados.ShowDialog();
        }
    }
}
