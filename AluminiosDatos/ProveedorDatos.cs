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
    public class ProveedorDatos
    {
        public static List<ProveedorEntidad> DevolverListaProveedores()
        {
            List<ProveedorEntidad> lista = new List<ProveedorEntidad>();
            using (SqlConnection cn = new SqlConnection(ConfiguracionApp.Default.ConexionVentasSql))
            {
                cn.Open();
                //todo cambiar los campos a la base del proyecto
                String sql = @"SELECT [Id_Pro]
                             ,[Nom_pro]
                             ,[Dir_pro]
                             ,[Tel_pro]
                             ,[Email_pro]
                                FROM [dbo].[Proveedores]
                                ORDER BY [nom_pro]";
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader reader = cmd.ExecuteReader();
                //repita la ejecucion mientras tenga datos
                while (reader.Read())
                {
                    lista.Add(CargarProveedor(reader));
                }
            }
            return lista;
        }

        public static ProveedorEntidad CargarProveedor(IDataReader reader)
        {
            //todo cambiar los nombres a los campos conforme se encuentra en la bdd del proyecto

            ProveedorEntidad proveedor = new ProveedorEntidad();
            proveedor.Id = Convert.ToInt32(reader["Id_pro"]);
            proveedor.Nombre = Convert.ToString(reader["Nom_pro"]);

            proveedor.Direccion = Convert.ToString(reader["Dir_pro"]);
            proveedor.Telefono = Convert.ToString(reader["Tel_pro"]);
            proveedor.Email = Convert.ToString(reader["Email_pro"]);
            
            return proveedor;
        }
        public static void EliminarProveedor(ProveedorEntidad proveedorActual)
        {
            using (SqlConnection cn = new SqlConnection(ConfiguracionApp.Default.ConexionVentasSql))
            {
                cn.Open();
                String sql = @"DELETE FROM [dbo].[proveedores]
                                WHERE [Id_pro]= @proveedorId";
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {

                    cmd.Parameters.AddWithValue("@proveedorId", proveedorActual.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static int GuardarProveedor(ProveedorEntidad proveedorActual)
        {

            using (SqlConnection cn = new SqlConnection(ConfiguracionApp.Default.ConexionVentasSql))
            {
                cn.Open();
                //todo cambiar los campos a la base del proyecto
                String sql = @"INSERT INTO [dbo].[proveedores]
                               ([Nom_pro]
                               ,[Dir_pro]
                               ,[Tel_pro]
                               ,[Email_pro])
                                  VALUES(
                               @nom
                               ,@dir
                               ,@tel
                               ,@email);
                            SELECT SCOPE_IDENTITY()";
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    
                    cmd.Parameters.AddWithValue("@nom", proveedorActual.Nombre);
                    
                    cmd.Parameters.AddWithValue("@dir", proveedorActual.Direccion);
                    cmd.Parameters.AddWithValue("@tel", proveedorActual.Telefono);
                    cmd.Parameters.AddWithValue("@email", proveedorActual.Email);
                    proveedorActual.Id = Convert.ToInt32(cmd.ExecuteScalar());
                }
                return proveedorActual.Id;
            }
        }

        public static void ActualizarProveedor(ProveedorEntidad proveedorActual)
        {
            using (SqlConnection cn = new SqlConnection(ConfiguracionApp.Default.ConexionVentasSql))
            {
                cn.Open();
                String sql = @"UPDATE [dbo].[proveedores]
                               SET [Nom_pro] = @nom
                                  ,[Dir_pro] = @dir
                                  ,[Tel_pro] = @tel
                                  ,[Email_pro] = @email
                                WHERE [Id_pro]= @proveedorId";
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@nom", proveedorActual.Nombre);
                    cmd.Parameters.AddWithValue("@dir", proveedorActual.Direccion);
                    cmd.Parameters.AddWithValue("@tel", proveedorActual.Telefono);
                    cmd.Parameters.AddWithValue("@email", proveedorActual.Email);
                    cmd.Parameters.AddWithValue("@proveedorId", proveedorActual.Id);
                    cmd.ExecuteNonQuery();
                }

            }
        }

        public static List<ProveedorEntidad> DevolverProveedorPorNombre(string text)
        {
            List<ProveedorEntidad> lista = new List<ProveedorEntidad>();
            using (SqlConnection cn = new SqlConnection(ConfiguracionApp.Default.ConexionVentasSql))
            {
                cn.Open();
                //todo cambiar los campos a la base del proyecto
                String sql = @"SELECT [Id_Pro]
                             ,[Nom_pro]
                             ,[Dir_pro]
                             ,[Tel_pro]
                             ,[Email_pro]
                                FROM [dbo].[Proveedores]
                                WHERE [nom_pro] LIKE '%' + @nombre + '%'";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@nombre", text);
                SqlDataReader reader = cmd.ExecuteReader();
                //repita la ejecucion mientras tenga datos
                while (reader.Read())
                {
                    lista.Add(CargarProveedor(reader));
                }
            }
            return lista;
        }
    }
}
