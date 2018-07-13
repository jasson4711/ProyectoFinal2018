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
    public static class MaterialDatos
    {
        public static List<MaterialEntidad> DevolverListaMateriales()
        {
            List<MaterialEntidad> lista = new List<MaterialEntidad>();
            using (SqlConnection cn = new SqlConnection(ConfiguracionApp.Default.ConexionVentasSql))
            {
                cn.Open();
                //todo cambiar los campos a la base del proyecto
                String sql = @"SELECT [Id_Mat]
                                  ,[Pre_Mat]
                                  ,[Stock_Mat]
                                  ,[Nom_Mat]
                                  ,[Des_Mat]
                                  ,[Uni_Med_Mat]
                                  ,[Nom_Pro]
                              FROM [dbo].[View_Materiales]
                              ORDER BY [Nom_Mat] ASC";
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader reader = cmd.ExecuteReader();
                //repita la ejecucion mientras tenga datos
                while (reader.Read())
                {
                    lista.Add(CargarMaterial(reader));
                }
            }
            return lista;
        }

        private static MaterialEntidad CargarMaterial(IDataReader reader)
        {
            MaterialEntidad material = new MaterialEntidad();
            material.Id = Convert.ToInt32(reader["Id_Mat"]);
            material.Nombre = Convert.ToString(reader["Nom_Mat"]);
            material.Descripcion = Convert.ToString(reader["Des_Mat"]);
            material.Precio_Unitario = Convert.ToDouble(reader["Pre_Mat"]);
            material.Stock = Convert.ToInt32(reader["Stock_Mat"]);
            material.UM = Convert.ToString(reader["Uni_Med_Mat"]);
            material.Proveedor = Convert.ToString(reader["Nom_Pro"]);
            return material;
        }

        public static void ActualizarInventario(ProductoEntidad productoBase)
        {
            using (SqlConnection cn = new SqlConnection(ConfiguracionApp.Default.ConexionVentasSql))
            {
                cn.Open();
                String sql = @"UPDATE [dbo].[Materiales]
                             SET [Stock_Mat] = Stock_Mat - @cantidad
                             WHERE [Id_Mat_Per] = @idMat";
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {

                    foreach (var detalle in productoBase.listaMateriales)
                    {
                        //
                        // como se reutiliza el mismo objeto SqlCommand es necesario limpiar los parametros
                        // de la operacion previa, sino estos se iran agregando en la coleccion, generando un fallo
                        //
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@idMat", detalle.Id_Material);
                        cmd.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
