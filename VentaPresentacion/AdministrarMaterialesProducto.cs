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
        List<ProductoDetalleEntidadMostrar> listaDetalles = new List<ProductoDetalleEntidadMostrar>();
        List<ProductoDetalleEntidad> listaDetallesBase = new List<ProductoDetalleEntidad>();
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
                    btnQuitar.Enabled = true;
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
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!HayMateriales)
            {
                this.Close();
            }
            else
            {
                if(MessageBox.Show("¿Desea confirmar los materiales utilizados?","Confirmar",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        GuardarDetallesProducto();
                        this.Close();
                    }
                    catch
                    {
                        MessageBox.Show("No se pudo realizar la operación");
                    }
                    
                }
            }
            
        }

        private void GuardarDetallesProducto()
        {
            throw new NotImplementedException();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            AñadirMaterialAProducto();
        }

        private void AñadirMaterialAProducto()
        {
            if (dgvMateriales.CurrentRow != null)
            {
                ProductoDetalleEntidadMostrar detalle = ConvertirProductoDetalleEntidadMostrar();
                AñadirDetalleAListaParaBase();
                listaDetalles.Add(detalle);
                CargarMaterialesProducto();
            }
            else
            {
                MessageBox.Show("Seleccione un material");
            }
        }

        private void AñadirDetalleAListaParaBase()
        {
            ProductoDetalleEntidad detalle = new ProductoDetalleEntidad();
            detalle.Id_Material = Convert.ToInt32(dgvMateriales.CurrentRow.Cells["Id"].Value.ToString());
            detalle.Id_Producto = this.Id;
            detalle.Cantidad = Convert.ToInt32(txtCantidad.Text);
            detalle.Precio = Convert.ToDouble(dgvMateriales.CurrentRow.Cells["Precio"].Value.ToString());
            listaDetallesBase.Add(detalle);
        }

        private ProductoDetalleEntidadMostrar ConvertirProductoDetalleEntidadMostrar()
        {
            ProductoDetalleEntidadMostrar detalle = new ProductoDetalleEntidadMostrar();
            detalle.Nombre = dgvMateriales.CurrentRow.Cells["Nombre"].Value.ToString() + " " + dgvMateriales.CurrentRow.Cells["Descripcion"].Value.ToString();
            detalle.Cantidad = Convert.ToInt32(txtCantidad.Text);
            detalle.Precio = Convert.ToDouble(dgvMateriales.CurrentRow.Cells["Precio"].Value.ToString());
            detalle.UM = dgvMateriales.CurrentRow.Cells["UM"].Value.ToString();
            txtCantidad.Text = "";
            return detalle;
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de quitar este material de la lista?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                listaDetalles.RemoveAt(dgvDetalleProducto.CurrentRow.Index);
                listaDetallesBase.RemoveAt(dgvDetalleProducto.CurrentRow.Index);

                dgvDetalleProducto.DataSource = null;
                dgvDetalleProducto.DataSource = listaDetalles;
            }
        }
    }
}
