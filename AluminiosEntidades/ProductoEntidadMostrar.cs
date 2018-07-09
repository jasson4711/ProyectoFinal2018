using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluminiosEntidades
{
    public class ProductoEntidadMostrar
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio_Total
        {
            get
            {
                return Precio * Cantidad;
            }
            set { }
        }

    }
}
