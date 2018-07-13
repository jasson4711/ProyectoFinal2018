using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AluminiosEntidades;
using AluminiosDatos;
using System.Transactions;

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

        public static List<ProductoDetalleEntidadMostrar> DevolverListaMaterialesProductoMostrar(int id)
        {
            return ProductoDatos.DevolverListaMaterialesProductoMostrar(id);
        }

        public static void GuardarProducto(ProductoEntidad productoBase)
        {
            using (TransactionScope transaccion = new TransactionScope())
            {
                ProductoDatos.GuardarProducto(productoBase);
                MaterialDatos.ActualizarInventario(productoBase);
                
            }
            

        }

        public static void ActualizarProducto(ProductoEntidad productoBase)
        {
            throw new NotImplementedException();
        }
    }
}
