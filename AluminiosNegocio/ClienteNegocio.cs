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

        public static List<ClienteEntidad> DevolverClientePorApellido(string idCliente)
        {
            return ClienteDatos.DevolverClientePorApellido(idCliente);
        }

        public static ClienteEntidad DevolverClientePorCedula(string cedula)
        {
            return ClienteDatos.DevolverClientePorCedula(cedula);
        }

        public static void ActualizarCliente(ClienteEntidad clienteNuevo)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                ClienteDatos.ActualizarCliente(clienteNuevo);
                scope.Complete();
            }
            
        }

        public static int GuardarCliente(ClienteEntidad cliente)
        {
            int id = 0;
            using (TransactionScope scope = new TransactionScope())
            {
                id = ClienteDatos.GuardarCliente(cliente);
                scope.Complete();
            }
            return id;
                
        }

        public static void EliminarCliente(ClienteEntidad clienteActual)
        {
            ClienteDatos.EliminarCliente(clienteActual);
        }
    }
}
