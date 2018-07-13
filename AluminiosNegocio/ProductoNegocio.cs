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

        public static void ActualizarStock(List<DetalleEntidad> listaDetalles)
        {
            ProductoDatos.ActualizarStock(listaDetalles);
        }

        public static List<ProductoEntidadMostrar> DevolverProductosPorNombre(string text)
        {
            return ProductoDatos.DevolverProductosPorNombre(text);
        }

        public static void EliminarProducto(int id)
        {
            ProductoDatos.EliminarProducto(id);
        }

        public static List<ProductoDetalleEntidad> DevolverListaMaterialesProducto(int id)
        {
            return ProductoDatos.DevolverListaMaterialesProducto(id);
        }
    }
}
