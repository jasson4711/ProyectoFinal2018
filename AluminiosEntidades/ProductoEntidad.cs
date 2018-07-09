using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluminiosEntidades
{
    public class ProductoEntidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Precio
        {
            get
            {
                return listaMateriales.Sum(x => x.Precio * x.Cantidad);
            }

        }
        public int Cantidad { get; set; }
        public List<ProductoDetalleEntidad> listaMateriales { get; set; }
    }
}
