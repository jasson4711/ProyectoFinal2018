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
    public class ProductoDatos
    {
        public static List<ProductoEntidadMostrar> DevolverListaProductos()
        {
            List<ProductoEntidadMostrar> lista = new List<ProductoEntidadMostrar>();
            using (SqlConnection cn = new SqlConnection(ConfiguracionApp.Default.ConexionVentasSql))
            {
                cn.Open();
                //todo cambiar los campos a la base del proyecto
                String sql = @"SELECT [Id_Pro]
                                  ,[Nom_Pro]
                                  ,[Des_Pro]
                                  ,[Pre_Pro]
                                  ,[Can_Pro]
                              FROM [dbo].[Productos_Cabecera]
                              ORDER BY [Nom_Pro] ASC";
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader reader = cmd.ExecuteReader();
                //repita la ejecucion mientras tenga datos
                while (reader.Read())
                {
                    lista.Add(CargarProducto(reader));
                }
            }
            return lista;
        }

        public static ProductoEntidadMostrar DevolverProductoPorID(int idProducto)
        {
            ProductoEntidadMostrar producto = new ProductoEntidadMostrar();

            using (SqlConnection cn = new SqlConnection(ConfiguracionApp.Default.ConexionVentasSql))
            {
                cn.Open();
                String sql = @"SELECT [Id_Pro]
                                  ,[Nom_Pro]
                                  ,[Des_Pro]
                                  ,[Pre_Pro]
                                  ,[Can_Pro]
                              FROM [dbo].[Productos_Cabecera]
                                WHERE [Id_Pro]= @productoId";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@productoId", idProducto);
                SqlDataReader reader = cmd.ExecuteReader();
                //repita la ejecucion mientras tenga datos
                while (reader.Read())
                {
                    producto = CargarProducto(reader);
                }
            }
            return producto;
        }

        private static ProductoEntidadMostrar CargarProducto(IDataReader reader)
        {
            ProductoEntidadMostrar producto = new ProductoEntidadMostrar();
            producto.Id = Convert.ToInt32(reader["Id_Pro"]);
            producto.Nombre = Convert.ToString(reader["Nom_Pro"]);
            producto.Descripcion = Convert.ToString(reader["Des_Pro"]);
            producto.Precio = Convert.ToDecimal(reader["Pre_Pro"]);
            producto.Cantidad = Convert.ToInt32(reader["Can_Pro"]);
            
            return producto;
        }
    }
}
