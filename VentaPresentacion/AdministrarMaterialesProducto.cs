using AluminiosEntidades;
using AluminiosNegocio;
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
    public partial class AdministrarMaterialesProducto : Form
    {
        int Id;
        bool Nuevo;
        bool HayMateriales = false;
        List<MaterialEntidad> listaMateriales = new List<MaterialEntidad>();

        public List<ProductoDetalleEntidadMostrar> listaDetalles = new List<ProductoDetalleEntidadMostrar>();
        public List<ProductoDetalleEntidad> listaDetallesBase = new List<ProductoDetalleEntidad>();
        public AdministrarMaterialesProducto(int id, bool nuevo)
        {
            InitializeComponent();
            Id = id;
            Nuevo = nuevo;
        }

        private void AdministrarMaterialesProducto_Load(object sender, EventArgs e)
        {
            ElementosIniciales();

        }

        private void ElementosIniciales()
        {
            try
            {
                if (Nuevo)
                {
                    CargarMateriales();
                    dgvDetalleProducto.DataSource = listaDetalles;
                    btnQuitar.Enabled = true;
                    txtCantidad.Enabled = true;
                    btnAñadir.Enabled = true;
                }
                else
                {

                    CargarMaterialesProducto();
                    CargarMateriales();
                    BloquearEdicionDataGridDetalle();

                }
                BloquearEdicionDataGridMateriales();

            }
            catch
            {
                MessageBox.Show("No se pudieron obtener los datos de la base");
            }
        }

        private void BloquearEdicionDataGridMateriales()
        {
            for (int i = 0; i < dgvMateriales.ColumnCount; i++)
            {

            }
        }

        private void BloquearEdicionDataGridDetalle()
        {
            for (int i = 0; i < dgvDetalleProducto.ColumnCount; i++)
            {
                dgvDetalleProducto.Columns[i].ReadOnly = true;
            }
        }

        private void CargarMaterialesProducto()
        {
            dgvDetalleProducto.DataSource = null;
            dgvDetalleProducto.DataSource = ProductoNegocio.DevolverListaMaterialesProductoMostrar(Id);
        }

        private void CargarMateriales()
        {
            listaMateriales = MaterialNegocio.DevolverListaMateriales();
            dgvMateriales.DataSource = listaMateriales;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!HayMateriales)
            {
                this.Close();
            }
            else
            {
                if (MessageBox.Show("¿Desea confirmar los materiales utilizados?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        GuardarDetallesProducto();
                       
                    }
                    catch
                    {
                        MessageBox.Show("No se pudo realizar la operación");
                    }

                }
                else
                {
                    this.Close();
                }
            }

        }

        private void GuardarDetallesProducto()
        {
            try
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch
            {
                ///*MessageBox.Show("Er*/ror: ¿Ya ha seleccionado un producto?");
            }
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text != "")
            {
                AñadirMaterialAProducto();
            }
            else
            {
                MessageBox.Show("Ingrese la cantidad utilizada");
            }

        }

        private void AñadirMaterialAProducto()
        {
            if (dgvMateriales.CurrentRow != null)
            {

                if (ValidarCantidad())
                {
                    int idMat = Convert.ToInt32(dgvMateriales.CurrentRow.Cells["Id"].Value.ToString());
                    if (listaDetalles.Find(x => x.Id == idMat) != null)
                    {
                        listaDetalles.Find(x => x.Id == idMat).Cantidad += Convert.ToInt32(txtCantidad.Text);
                        dgvDetalleProducto.DataSource = null;
                        dgvDetalleProducto.DataSource = listaDetalles;
                        txtCantidad.Text = "";
                    }
                    else
                    {
                        ProductoDetalleEntidadMostrar detalle = ConvertirProductoDetalleEntidadMostrar();
                        AñadirDetalleAListaParaBase();
                        listaDetalles.Add(detalle);
                        dgvDetalleProducto.DataSource = null;
                        dgvDetalleProducto.DataSource = listaDetalles;
                        txtCantidad.Text = "";
                    }
                    HayMateriales = true;
                }

            }
            else
            {
                MessageBox.Show("Seleccione un material");
            }
        }

        private bool ValidarCantidad()
        {
            int stock = Convert.ToInt32(dgvMateriales.CurrentRow.Cells["Stock"].Value.ToString());
            int cantidad = Convert.ToInt32(txtCantidad.Text);
            int idMat = Convert.ToInt32(dgvMateriales.CurrentRow.Cells["Id"].Value.ToString());
            if (listaDetalles.Find(x => x.Id == idMat) != null)
            {
                cantidad += listaDetalles.Find(x => x.Id == idMat).Cantidad;

            }
            if (stock > cantidad)
            {
                return true;
            }
            else
            {
                MessageBox.Show("No dispone de la cantidad especificada");
                txtCantidad.Focus();
                txtCantidad.Text = "";
                return false;
            }
        }

        private void AñadirDetalleAListaParaBase()
        {
            ProductoDetalleEntidad detalle = new ProductoDetalleEntidad();
            detalle.Id_Material = Convert.ToInt32(dgvMateriales.CurrentRow.Cells["Id"].Value.ToString());
            detalle.Id_Producto = this.Id;
            detalle.Cantidad = Convert.ToInt32(txtCantidad.Text);
            detalle.Precio = Convert.ToDouble(dgvMateriales.CurrentRow.Cells["Precio_Unitario"].Value.ToString());
            listaDetallesBase.Add(detalle);

        }

        public ProductoDetalleEntidadMostrar ConvertirProductoDetalleEntidadMostrar()
        {
            ProductoDetalleEntidadMostrar detalle = new ProductoDetalleEntidadMostrar();
            detalle.Nombre = dgvMateriales.CurrentRow.Cells["Nombre"].Value.ToString() + " " + dgvMateriales.CurrentRow.Cells["Descripcion"].Value.ToString();
            detalle.Cantidad = Convert.ToInt32(txtCantidad.Text);
            detalle.Precio = Convert.ToDouble(dgvMateriales.CurrentRow.Cells["Precio_Unitario"].Value.ToString());
            detalle.Id = Convert.ToInt32(dgvMateriales.CurrentRow.Cells["Id"].Value.ToString());
            detalle.UM = dgvMateriales.CurrentRow.Cells["UM"].Value.ToString();
            return detalle;
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvDetalleProducto.CurrentRow != null)
            {
                if (MessageBox.Show("¿Está seguro de quitar este material de la lista?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    listaDetalles.RemoveAt(dgvDetalleProducto.CurrentRow.Index);
                    listaDetallesBase.RemoveAt(dgvDetalleProducto.CurrentRow.Index);

                    dgvDetalleProducto.DataSource = null;
                    dgvDetalleProducto.DataSource = listaDetalles;
                    if (listaDetalles.Count == 0)
                    {
                        HayMateriales = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un material para quitar");
            }
        }
    }
}
