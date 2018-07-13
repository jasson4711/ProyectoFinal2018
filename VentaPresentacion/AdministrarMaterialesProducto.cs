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
        public AdministrarMaterialesProducto(int id)
        {
            InitializeComponent();
            Id = id;
        }

        private void AdministrarMaterialesProducto_Load(object sender, EventArgs e)
        {
            try
            {
                CargarMateriales();
                CargarMaterialesProducto();
            }
            catch
            {
                MessageBox.Show("No se pudieron obtener los datos de la base");
            }
            
        }

        private void CargarMaterialesProducto()
        {
            throw new NotImplementedException();
        }

        private void CargarMateriales()
        {
            
        }
    }
}
