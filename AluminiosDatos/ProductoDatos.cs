﻿using System;
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

        public static List<ProductoEntidadMostrar> DevolverProductosPorNombre(string text)
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
                              WHERE [Nom_Pro] LIKE  '%' + @nombre + '%'";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@nombre", text);
                SqlDataReader reader = cmd.ExecuteReader();
                //repita la ejecucion mientras tenga datos
                while (reader.Read())
                {
                    lista.Add(CargarProducto(reader));
                }
            }
            return lista;
        }

        public static void ActualizarStock(List<DetalleEntidad> listaDetalles)
        {
            using (SqlConnection cn = new SqlConnection(ConfiguracionApp.Default.ConexionVentasSql))
            {
                cn.Open();
                String sql = @"UPDATE [dbo].[Productos_Cabecera]
                               SET [Can_Pro] = [Can_Pro] - @cantidad
                                WHERE [Id_Pro]= @productoId";
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {

                    foreach (var detalle in listaDetalles)
                    {
                        //
                        // como se reutiliza el mismo objeto SqlCommand es necesario limpiar los parametros
                        // de la operacion previa, sino estos se iran agregando en la coleccion, generando un fallo
                        //
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@productoId", detalle.Id_Pro_Ven);
                        cmd.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
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
            producto.Precio = Convert.ToDouble(reader["Pre_Pro"]);
            producto.Cantidad = Convert.ToInt32(reader["Can_Pro"]);
            
            return producto;
        }
    }
}
