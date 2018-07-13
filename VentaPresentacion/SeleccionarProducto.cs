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
        bool Escoger;
        ProductoEntidadMostrar productoActual = new ProductoEntidadMostrar();
        ProductoEntidad productoBase = new ProductoEntidad();
        List<ProductoEntidadMostrar> listaProductos = new List<ProductoEntidadMostrar>();
        List<ProductoDetalleEntidad> listaMateriales = new List<ProductoDetalleEntidad>();
        string opcionToolStrip = "";
        private int _idProducto;
        public int IdProducto
        {
            get
            {
                return _idProducto;
            }

        }
        public SeleccionarProducto(bool escoger)
        {
            InitializeComponent();
            Escoger = escoger;
            btnEscogerProducto.Visible = Escoger;

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
                //HabilitarControlesMenu(false);
                
                HabilitarControlesIngreso(false);
                toolStripGuardar.Enabled = false;
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
                productoActual.Nombre = txtNombre.Text;
                productoActual.Descripcion = txtDescripcion.Text;
                productoActual.Precio = Convert.ToDouble(txtPrecio.Text);
                productoActual.Cantidad = Convert.ToInt32(txtCantidad.Text);
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
            //toolStripGuardar.Enabled = v;
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
            txtPrecio.Text = "0,00";
        }

        private void limpiarIngreso()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
            productoActual = new ProductoEntidadMostrar();
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
            txtCantidad.Enabled = v;
            btnVerMateriales.Enabled = v;
        }

        private void toolStripActualizar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Busque o seleccione un producto para modificarlo");
            }
            else
            {
                HabilitarControlesMenuActualizar(true);
                HabilitarControlesIngreso(true);
                txtNombre.Focus();
                opcionToolStrip = "modificar";
            }
        }
        private void HabilitarControlesMenuActualizar(Boolean v)
        {
            toolStripNuevo.Enabled = !v;
            toolStripActualizar.Enabled = !v;
            toolStripEliminar.Enabled = !v;
            toolStripGuardar.Enabled = v;
            toolStripCancelar.Enabled = v;

            toolStripEditar.Enabled = !v;
        }

        private void toolStripEliminar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Busque o seleccione un producto para Eliminar");
            }
            else
            {
                if (MessageBox.Show("Desea realmente elminar la informacion de la base de datos?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    EstablecerProductoActual();
                    ProductoNegocio.EliminarProducto(productoActual.Id);
                    HabilitarControlesMenu(false);
                    HabilitarControlesIngreso(false);
                    CargarListaProductos();
                    limpiarIngreso();
                }
            }
        }

        private void toolStripGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Guardar();
            }
            catch (Exception ex){
                MessageBox.Show(ex.ToString());
            }

        }

        private void Guardar()
        {
            if (validarDatosEntrada())
            {

                EstablecerProductoActual();
                EstablecerProductoEntidad();

                if (productoBase.listaMateriales.Count > 0)
                {

                    if (opcionToolStrip == "nuevo")
                    {
                        ProductoNegocio.GuardarProducto(productoBase);
                        MessageBox.Show("Nuevo producto guardado con exito");
                    }
                    else if (opcionToolStrip == "modificar")
                    {
                        EstablecerProductoActual();
                        ProductoNegocio.ActualizarProducto(productoBase);
                        MessageBox.Show("Producto actualizado con exito");
                    }
                    dgvProductos.DataSource = null;
                    CargarListaProductos();
                }
                else
                {
                    MessageBox.Show("Por favor ingrese los materiales con los que se fabricó el producto");
                }

            }
        }

        private void EstablecerProductoEntidad()
        {

            productoBase.Id = productoActual.Id;
            productoBase.Nombre = productoActual.Nombre;
            productoBase.Descripcion = productoActual.Descripcion;
            productoBase.Cantidad = productoActual.Cantidad;
          
        }

        private bool validarDatosEntrada()
        {
            if (txtNombre.Text == "" || txtDescripcion.Text == "" || txtPrecio.Text == ""
                || txtCantidad.Text == "")
            {
                MessageBox.Show("Ingrese correctamente todos los campos");
                txtNombre.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void toolStripCancelar_Click(object sender, EventArgs e)
        {
            HabilitarControlesMenu(false);
            HabilitarControlesIngreso(false);
            toolStripGuardar.Enabled = false;
            limpiarIngreso();
        }

        private void btnVerMateriales_Click(object sender, EventArgs e)
        {
            AdministrarMaterialesProducto frm;
            if (opcionToolStrip == "nuevo")
            {
                frm = new AdministrarMaterialesProducto(productoActual.Id, true);
                //frm.listaDetallesBase = productoBase.listaMateriales;
                //List<ProductoDetalleEntidadMostrar> lista = new List<ProductoDetalleEntidadMostrar();
                //foreach (var item in productoBase.listaMateriales)
                //{
                //    lista.Add(frm.ConvertirProductoDetalleEntidadMostrar());
                //}
                //frm.listaDetalles = ConvertirListaMostrar()
            }
            else
            {
                frm = new AdministrarMaterialesProducto(productoActual.Id, false);
            }
            if (frm.ShowDialog() == DialogResult.OK)
            {
                productoBase.listaMateriales = frm.listaDetallesBase;
            }
            
                
        }

        private void btnEscogerProducto_Click(object sender, EventArgs e)
        {
            EscogerProducto();
        }
    }
}
