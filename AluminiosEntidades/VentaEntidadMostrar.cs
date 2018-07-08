using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluminiosEntidades
{
    public class VentaEntidadMostrar
    {
        public int Id { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal Total { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}
