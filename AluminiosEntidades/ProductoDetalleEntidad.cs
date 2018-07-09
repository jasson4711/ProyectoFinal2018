using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluminiosEntidades
{
    public class ProductoDetalleEntidad
    {
        public int Id_Producto { get; set; }
        public int Id_Material { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

    }
}
