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
    public static class VentaDatos
    {
        public static int GenerarVenta(VentaEntidad ventas)
        {
            using (SqlConnection cn = new SqlConnection(ConfiguracionApp.Default.ConexionVentasSql))
            {

                cn.Open();
                string sqlFactura = @"INSERT INTO [dbo].[Ventas_Cabecera]
                                          ([Id_Cli_Ven]
                                          ,[Id_Emp_Ven]
                                          ,[Fec_Ven]
                                          ,[Por_Gan_Ven]
                                          ,[Total])
                                    VALUES (@idCliente, @idEmpleado,@fechaVenta,@porGan, @total)
                                    SELECT SCOPE_IDENTITY()";

                using (SqlCommand cmd = new SqlCommand(sqlFactura, cn))
                {
                    cmd.Parameters.AddWithValue("@idCliente", ventas.Id_Cliente);
                    cmd.Parameters.AddWithValue("@idEmpleado", ventas.Id_Empleado);
                    cmd.Parameters.AddWithValue("@fechaVenta", ventas.Fecha);
                    cmd.Parameters.AddWithValue("@porGan", ventas.Ganancia);
                    cmd.Parameters.AddWithValue("@total", 0);
                    ventas.Id = Convert.ToInt32(cmd.ExecuteScalar());
                }

                string sqlDetalle = @"INSERT INTO [dbo].[Ventas_Detalle]
                                           ([Id_Ven_Per]
                                           ,[Id_Pro_Ven]
                                           ,[Can_Pro_Ven])
                                     VALUES (@idVenta, @idProducto, @cantidad)";

                using (SqlCommand cmd = new SqlCommand(sqlDetalle, cn))
                {

                    foreach (var detalle in ventas.ListaDetalles)
                    {
                        //
                        // como se reutiliza el mismo objeto SqlCommand es necesario limpiar los parametros
                        // de la operacion previa, sino estos se iran agregando en la coleccion, generando un fallo
                        //
                        cmd.Parameters.Clear();

                        cmd.Parameters.AddWithValue("@idVenta", ventas.Id);
                        cmd.Parameters.AddWithValue("@idProducto", detalle.Id_Pro_Ven);
                        cmd.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                        cmd.ExecuteNonQuery();
                    }

                }
                return ventas.Id;
            }

        }

        public static List<DetalleEntidadMostrar> DevolverVentaDetalle(int id_venta)
        {
            List<DetalleEntidadMostrar> listaVentaDetalle = new List<DetalleEntidadMostrar>();
            using (SqlConnection cn = new SqlConnection(ConfiguracionApp.Default.ConexionVentasSql))
            {
                cn.Open();
                string sql = @"SELECT [Nom_Pro]
                                  ,[Des_Pro]
                                  ,[Pre_Pro]
                                  ,[Id_Ven_Per]
                                  ,[Id_Pro_Ven]
                                  ,[Can_Pro_Ven]
                              FROM [dbo].[View_Detalle]
                            WHERE [Id_Ven_Per] = @id_Venta
                            ";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@id_Venta", id_venta);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listaVentaDetalle.Add(TraducirDetalleEntidad(reader));
                }
            }
            return listaVentaDetalle;
        }

        private static DetalleEntidadMostrar TraducirDetalleEntidad(SqlDataReader reader)
        {
            DetalleEntidadMostrar ms = new DetalleEntidadMostrar();
            ms.Id = Convert.ToInt32(reader["Id_Ven_Per"]);
            ms.Nombre= Convert.ToString(reader["Nom_Pro"] + " "+reader["Des_Pro"]);
            ms.Precio = Convert.ToDouble(reader["Pre_Pro"]);
            ms.Cantidad = Convert.ToInt32(reader["Can_Pro_Ven"]);
            return ms;
        }

        public static VentaEntidadMostrar DevolverVentaCabecera(int id_venta)
        {
            VentaEntidadMostrar ventaCabeceraEntidad = new VentaEntidadMostrar();
            using (SqlConnection cn = new SqlConnection(ConfiguracionApp.Default.ConexionVentasSql))
            {
                cn.Open();
                string sql = @"SELECT [Ced_Cli]
                                  ,[Nom_Cli]
                                  ,[Ape_Cli]
                                  ,[Dir_Cli]
                                  ,[Tel_Cli]
                                  ,[Ced_Emp]
                                  ,[Nom_Emp]
                                  ,[Ape_Emp]
                                  ,[Id_Ven]
                                  ,[Fec_Ven]
                                  ,[Por_Gan_Ven]
                                  ,[Total]
                              FROM [dbo].[View_Cabecera]
                              WHERE [Id_Ven] = @id_Venta";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@id_Venta", id_venta);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ventaCabeceraEntidad = TraducirCabeceraEntidad(reader);
                }
            }
            return ventaCabeceraEntidad;
        }

        private static VentaEntidadMostrar TraducirCabeceraEntidad(IDataReader reader)
        {
            VentaEntidadMostrar ms = new VentaEntidadMostrar();
            ms.Id = Convert.ToInt32(reader["Id_Ven"]);
            ms.FechaVenta = Convert.ToDateTime(reader["Fec_Ven"]);
            ms.Nombre = Convert.ToString(reader["Nom_Cli"]);
            ms.Apellido = Convert.ToString(reader["Ape_Cli"]);
            ms.Cedula = Convert.ToString(reader["Ced_Cli"]);
            ms.Direccion = Convert.ToString(reader["Dir_Cli"]);
            ms.Telefono = Convert.ToString(reader["Tel_Cli"]);
            ms.Total = Convert.ToDouble(reader["Total"]);
            ms.Ganancia = Convert.ToDouble(reader["Por_Gan_Ven"]);
            return ms;
        }

        public static void UpdateTotal(int id, double total)
        {
            using (SqlConnection conn = new SqlConnection(ConfiguracionApp.Default.ConexionVentasSql))
            {
                conn.Open();

                string sqlUpdateTotal = @"UPDATE [dbo].[Ventas_Cabecera]
                                        SET Total = @total WHERE Id_Ven = @ventaId";

                using (SqlCommand cmd = new SqlCommand(sqlUpdateTotal, conn))
                {
                    cmd.Parameters.AddWithValue("@total", total);
                    cmd.Parameters.AddWithValue("@ventaId", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
