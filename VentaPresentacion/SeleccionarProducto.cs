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
        ProductoEntidadMostrar productoActual = new ProductoEntidadMostrar();
        List<ProductoEntidadMostrar> listaProductos = new List<ProductoEntidadMostrar>();
        string opcionToolStrip = "";
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
            try
            {
                int index = e.RowIndex;

                DataGridViewRow row = this.dgvProductos.Rows[index];

                txtId.Text = row.Cells["Id"].Value.ToString();
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtDescripcion.Text = row.Cells["Descripcion"].Value.ToString();
                txtPrecio.Text = row.Cells["Precio"].Value.ToString();
                txtCantidad.Text = row.Cells["Cantidad"].Value.ToString();

                EstablecerProductoActual();
            }
            catch (Exception)
            {
            }
        }

        private void EstablecerProductoActual()
        {
            if (txtId.Text == "")
            {
                productoActual.Id = 0;
            }
            else
            {
                productoActual.Id = Convert.ToInt32(txtId.Text);
                productoActual.Nombre = txtNombre.Text;
                productoActual.Descripcion = txtDescripcion.Text;
                productoActual.Precio = Convert.ToDouble(txtPrecio.Text);
                productoActual.Cantidad = Convert.ToInt32(txtCantidad.Text);
            }

        }

        private void EscogerProducto()
        {
            try
            {
                _idProducto = Convert.ToInt32(dgvProductos.CurrentRow.Cells["Id"].Value);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch
            {
                MessageBox.Show("Error: ¿Ya ha seleccionado un producto?");
            }

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

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pbBuscar_Click(object sender, EventArgs e)
        {
            BuscarProducto();

        }

        private void BuscarProducto()
        {
            if (!txtBuscar.Text.Equals(""))
            {
                if (radioButtonId.Checked)
                {
                    productoActual = ProductoNegocio.DevolverProductoPorID(Convert.ToInt32(txtBuscar.Text));
                    if (productoActual.Id != 0)
                        cargarProducto();
                    else
                        MessageBox.Show("Sin resultados. Verifique el Id ingresado");
                }
                else if (radioButtonNombre.Checked)
                {
                    listaProductos = ProductoNegocio.DevolverProductosPorNombre(txtBuscar.Text);
                    dgvProductos.DataSource = listaProductos;
                }
                else
                    MessageBox.Show("Seleccione un metodo de busqueda");

            }
            else
            {
                MessageBox.Show("Ingrese un valor para buscar");
            }
        }

        private void cargarProducto()
        {
            txtId.Text = productoActual.Id.ToString();
            txtNombre.Text = productoActual.Nombre;
            txtDescripcion.Text = productoActual.Descripcion;
            txtPrecio.Text = productoActual.Precio.ToString();
            txtCantidad.Text = productoActual.Cantidad.ToString();
        }

        private void toolStripNuevo_Click(object sender, EventArgs e)
        {
            HabilitarControlesIngreso(true);
            HabilitarControlesMenuNuevo(true);
            opcionToolStrip = "nuevo";
            limpiarIngreso();
        }

        private void limpiarIngreso()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";

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

        private void HabilitarControlesIngreso(bool v)
        {
            txtNombre.Enabled = v;
            txtId.Enabled = v;
            txtDescripcion.Enabled = v;
            txtPrecio.Enabled = v;
            txtCantidad.Enabled = v;
        }
    }
}
