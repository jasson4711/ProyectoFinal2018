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
    public partial class SeleccionarProducto : Form
    {
        private int _idProducto;
        public int IdProducto
        {
            get
            {
                return _idProducto;
            }

        }
        public SeleccionarProducto()
        {
            InitializeComponent();
        }

        private void SeleccionarProducto_Load(object sender, EventArgs e)
        {
            try
            {
                CargarListaProductos();
            }
            catch
            {
                MessageBox.Show("No se han podido mostrar los datos");
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void CargarListaProductos()
        {
            dgvProductos.DataSource = ProductoNegocio.DevolverListaProductos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            _idProducto = Convert.ToInt32(dgvProductos.Rows[e.RowIndex].Cells["Id"].Value);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
