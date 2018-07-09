using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AluminiosEntidades;
using AluminiosDatos;
namespace AluminiosNegocio
{
    public static class ProductoNegocio
    {
        public static List<ProductoEntidadMostrar> DevolverListaProductos()
        {
            return ProductoDatos.DevolverListaProductos();
        }

        public static ProductoEntidadMostrar DevolverProductoPorID(int idProducto)
        {
            return ProductoDatos.DevolverProductoPorID(idProducto);
        }
    }
}
