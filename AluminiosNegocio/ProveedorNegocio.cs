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
    public static class ProveedorNegocio
    {
        public static List<ProveedorEntidad> DevolverListaProveedores()
        {
            return ProveedorDatos.DevolverListaProveedores();
        }

        public static void EliminarProveedor(ProveedorEntidad proveedorActual)
        {
            ProveedorDatos.EliminarProveedor(proveedorActual);
        }

        public static int GuardarProveedor(ProveedorEntidad proveedorActual)
        {
            int id = 0;
            using (TransactionScope scope = new TransactionScope())
            {
                id = ProveedorDatos.GuardarProveedor(proveedorActual);
                scope.Complete();
            }
            return id;
        }

        public static void ActualizarProveedor(ProveedorEntidad proveedorActual)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                ProveedorDatos.ActualizarProveedor(proveedorActual);
                scope.Complete();
            }
        }

        public static List<ProveedorEntidad> DevolverProveedorPorNombre(string text)
        {
            return ProveedorDatos.DevolverProveedorPorNombre(text);
        }
    }
}
