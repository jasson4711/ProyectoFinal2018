using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluminiosEntidades
{
    public class ProductoDetalleEntidadMostrar
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
        public string UM { get; set; }
        public double Precio_Total { get { return this.Precio * this.Cantidad; } }
    }
}
