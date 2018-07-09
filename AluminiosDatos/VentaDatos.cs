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
                    cmd.Parameters.AddWithValue("@porGan", ventas.Porcentaje_Ganancia);
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
