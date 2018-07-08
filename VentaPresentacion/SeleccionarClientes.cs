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
    public partial class SeleccionarClientes : Form
    {
        private int _idCliente;
        public int IdCliente
        {
            get
            {
                return _idCliente;
            }

        }
        public SeleccionarClientes()
        {
            InitializeComponent();
        }

        private void SeleccionarClientes_Load(object sender, EventArgs e)
        {
            CargarListaClientes();
        }

        private void CargarListaClientes()
        {
            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.DataSource = ClienteNegocio.DevolverListaClientes();
        }


        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            _idCliente = Convert.ToInt32(dgvClientes.Rows[e.RowIndex].Cells["ID"].Value);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
