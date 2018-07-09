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
        public ManejoClientes()
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

        private void ManejoClientes_Load(object sender, EventArgs e)
        {
            CargarDataGridClientes();
        }

        private void CargarDataGridClientes()
        {
            dataGridViewClientes.DataSource = ClienteNegocio.DevolverListaClientes();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
