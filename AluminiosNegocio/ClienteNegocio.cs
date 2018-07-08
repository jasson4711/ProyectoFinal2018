using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AluminiosEntidades;
using AluminiosDatos;
namespace AluminiosNegocio
{
    public static class ClienteNegocio
    {
        public static List<ClienteEntidad> DevolverListaClientes()
        {
            return ClienteDatos.DevolverListaClientes();
        }

        public static ClienteEntidad DevolverClientePorID(int idCliente)
        {
            return ClienteDatos.DevolverClientePorID(idCliente);
        }
    }
}
