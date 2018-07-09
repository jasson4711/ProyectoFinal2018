using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AluminiosEntidades;
namespace AluminiosDatos
{
    public static class ClienteDatos
    {
        public static List<ClienteEntidad> DevolverListaClientes()
        {
            List<ClienteEntidad> lista = new List<ClienteEntidad>();
            using (SqlConnection cn = new SqlConnection(ConfiguracionApp.Default.ConexionVentasSql))
            {
                cn.Open();
                //todo cambiar los campos a la base del proyecto
                String sql = @"SELECT [Id_Cli]
                             ,[Ape_Cli]
                             ,[Nom_Cli]
                             ,[Ced_Cli]
                             ,[Dir_Cli]
                             ,[Tel_Cli]
                             ,[Email_Cli]
                                FROM [dbo].[Clientes]
                                ORDER BY [Ape_Cli]";
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader reader = cmd.ExecuteReader();
                //repita la ejecucion mientras tenga datos
                while (reader.Read())
                {
                    lista.Add(CargarCliente(reader));
                }
            }
            return lista;
        }

        public static int GuardarCliente(ClienteEntidad cliente)
        {
            
            using (SqlConnection cn = new SqlConnection(ConfiguracionApp.Default.ConexionVentasSql))
            {
                cn.Open();
                //todo cambiar los campos a la base del proyecto
                String sql = @"INSERT INTO [dbo].[Clientes]
                                       ([Ced_Cli]
                                       ,[Nom_Cli]
                                       ,[Ape_Cli]
                                       ,[Dir_Cli]
                                       ,[Tel_Cli]
                                       ,[Email_Cli])
                                 VALUES(
                                       @ced
                                       ,@nom
                                       ,@ape
                                       ,@dir
                                       ,@tel
                                       ,@email);
                                SELECT SCOPE_IDENTITY()";
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@ced", cliente.Cedula);
                    cmd.Parameters.AddWithValue("@nom", cliente.Nombre);
                    cmd.Parameters.AddWithValue("@ape", cliente.Apellido);
                    cmd.Parameters.AddWithValue("@dir", cliente.Direccion);
                    cmd.Parameters.AddWithValue("@tel", cliente.Telefono);
                    cmd.Parameters.AddWithValue("@email", cliente.Email);
                    cliente.Id = Convert.ToInt32(cmd.ExecuteScalar());
                }
                return cliente.Id;
            }
        }

        public static void EliminarCliente(ClienteEntidad clienteActual)
        {
            using (SqlConnection cn = new SqlConnection(ConfiguracionApp.Default.ConexionVentasSql))
            {
                cn.Open();
                String sql = @"DELETE FROM [dbo].[Clientes]
                                WHERE [Id_Cli]= @clienteId";
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {

                    cmd.Parameters.AddWithValue("@clienteId", clienteActual.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void ActualizarCliente(ClienteEntidad clienteNuevo)
        {

            using (SqlConnection cn = new SqlConnection(ConfiguracionApp.Default.ConexionVentasSql))
            {
                cn.Open();
                String sql = @"UPDATE [dbo].[Clientes]
                               SET [Ced_Cli] = @ced
                                  ,[Nom_Cli] = @nom
                                  ,[Ape_Cli] = @ape
                                  ,[Dir_Cli] = @dir
                                  ,[Tel_Cli] = @tel
                                  ,[Email_Cli] = @email
                               WHERE [Id_Cli]= @clienteId";
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@ced", clienteNuevo.Cedula);
                    cmd.Parameters.AddWithValue("@nom", clienteNuevo.Nombre);
                    cmd.Parameters.AddWithValue("@ape", clienteNuevo.Apellido);
                    cmd.Parameters.AddWithValue("@dir", clienteNuevo.Direccion);
                    cmd.Parameters.AddWithValue("@tel", clienteNuevo.Telefono);
                    cmd.Parameters.AddWithValue("@email", clienteNuevo.Email);
                    cmd.Parameters.AddWithValue("@clienteId", clienteNuevo.Id);
                    cmd.ExecuteNonQuery();
                }

            }

        }

        public static ClienteEntidad DevolverClientePorID(int idCliente)
        {
            ClienteEntidad cliente = new ClienteEntidad();

            using (SqlConnection cn = new SqlConnection(ConfiguracionApp.Default.ConexionVentasSql))
            {
                cn.Open();
                String sql = @"SELECT [Id_Cli]
                             ,[Nom_Cli]
                             ,[Ape_Cli]
                             ,[Ced_Cli]
                             ,[Dir_Cli]
                             ,[Tel_Cli]
                             ,[Email_Cli]
                                FROM [dbo].[Clientes]
                                WHERE [Id_Cli]= @clienteId";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@clienteId", idCliente);
                SqlDataReader reader = cmd.ExecuteReader();
                //repita la ejecucion mientras tenga datos
                while (reader.Read())
                {
                    cliente = CargarCliente(reader);
                }
            }
            return cliente;
        }


        public static ClienteEntidad DevolverClientePorCedula(string cedulaCliente)
        {
            ClienteEntidad cliente = new ClienteEntidad();

            using (SqlConnection cn = new SqlConnection(ConfiguracionApp.Default.ConexionVentasSql))
            {
                cn.Open();
                String sql = @"SELECT [Id_Cli]
                             ,[Nom_Cli]
                             ,[Ape_Cli]
                             ,[Ced_Cli]
                             ,[Dir_Cli]
                             ,[Tel_Cli]
                             ,[Email_Cli]
                                FROM [dbo].[Clientes]
                                WHERE [Ced_Cli]= @cedula";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@cedula", cedulaCliente);
                SqlDataReader reader = cmd.ExecuteReader();
                //repita la ejecucion mientras tenga datos
                while (reader.Read())
                {
                    cliente = CargarCliente(reader);
                }
            }
            return cliente;
        }

        public static List<ClienteEntidad> DevolverClientePorApellido(string apellidoCliente)
        {
            List<ClienteEntidad> cliente = new List<ClienteEntidad>();

            using (SqlConnection cn = new SqlConnection(ConfiguracionApp.Default.ConexionVentasSql))
            {
                cn.Open();
                String sql = @"SELECT [Id_Cli]
                             ,[Nom_Cli]
                             ,[Ape_Cli]
                             ,[Ced_Cli]
                             ,[Dir_Cli]
                             ,[Tel_Cli]
                             ,[Email_Cli]
                                FROM [dbo].[Clientes]
                                WHERE [Ape_Cli] LIKE  '%' + @apellido + '%'";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@apellido", apellidoCliente);
                SqlDataReader reader = cmd.ExecuteReader();
                //repita la ejecucion mientras tenga datos
                while (reader.Read())
                {
                    cliente.Add(CargarCliente(reader));
                }
            }
            return cliente;
        }
        public static ClienteEntidad CargarCliente(IDataReader reader)
        {
            //todo cambiar los nombres a los campos conforme se encuentra en la bdd del proyecto

            ClienteEntidad cliente = new ClienteEntidad();
            cliente.Id = Convert.ToInt32(reader["Id_Cli"]);
            cliente.Nombre = Convert.ToString(reader["Nom_Cli"]);
            cliente.Apellido = Convert.ToString(reader["Ape_Cli"]);
            cliente.Cedula = Convert.ToString(reader["Ced_Cli"]);
            cliente.Direccion = Convert.ToString(reader["Dir_Cli"]);
            cliente.Telefono = Convert.ToString(reader["Tel_Cli"]);
            cliente.Email = Convert.ToString(reader["Email_Cli"]);
            return cliente;
        }
    }


}
