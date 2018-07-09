using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluminiosEntidades
{
    public class VentaEntidad
    {
        public int Id { get; set; }
        public int Id_Cliente { get; set; }
        public int Id_Empleado { get; set; }
        public DateTime Fecha { get; set; }
        public int Porcentaje_Ganancia { get; set; }
        public double Total
        {
            get { return (this.ListaDetalles.Sum(x => x.PrecioUnitario * x.Cantidad))*Porcentaje_Ganancia/100 + (this.ListaDetalles.Sum(x => x.PrecioUnitario * x.Cantidad)) + (this.ListaDetalles.Sum(x => x.PrecioUnitario * x.Cantidad)) * Settings.Default.Iva; }

        }
        public List<DetalleEntidad> ListaDetalles { get; set; }


    }
}
