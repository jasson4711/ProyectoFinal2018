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
    public class EmpleadoDatos
    {
        public static List<EmpleadoEntidad> DevolverListaEmpleados()
        {
            List<EmpleadoEntidad> lista = new List<EmpleadoEntidad>();
            using (SqlConnection cn = new SqlConnection(ConfiguracionApp.Default.ConexionVentasSql))
            {
                cn.Open();
                //todo cambiar los campos a la base del proyecto
                String sql = @"SELECT [Id_Emp]
                             ,[Ape_Emp]
                             ,[Nom_Emp]
                             ,[Ced_Emp]
                             ,[Dir_Emp]
                             ,[Tel_Emp]
                             ,[Email_Emp]
                             ,[Sue_Emp]
                             ,[Cla_Emp]
                            ,[cargo]
                                FROM [dbo].[Empleados]
                                ORDER BY [Ape_Emp]";
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader reader = cmd.ExecuteReader();
                //repita la ejecucion mientras tenga datos
                while (reader.Read())
                {
                    lista.Add(CargarEmpleado(reader));
                }
            }
            return lista;
        }

        public static List<EmpleadoEntidad> DevolverEmpleadoPorApellido(string text)
        {
            List<EmpleadoEntidad> cliente = new List<EmpleadoEntidad>();

            using (SqlConnection cn = new SqlConnection(ConfiguracionApp.Default.ConexionVentasSql))
            {
                cn.Open();
                String sql = @"SELECT [Id_Emp]
                             ,[Ape_Emp]
                             ,[Nom_Emp]
                             ,[Ced_Emp]
                             ,[Dir_Emp]
                             ,[Tel_Emp]
                             ,[Email_Emp]
                             ,[Sue_Emp]
                             ,[Cla_Emp]
                            ,[cargo]
                                FROM [dbo].[Empleados]
                                WHERE [Ape_Emp] LIKE '%' + @apellido + '%'";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@apellido", text);
                SqlDataReader reader = cmd.ExecuteReader();
                //repita la ejecucion mientras tenga datos
                while (reader.Read())
                {
                    cliente.Add(CargarEmpleado(reader));
                }
            }
            return cliente;
        }

        public static EmpleadoEntidad DevolverEmpleadoPorID(int idEmpleado)
        {
            EmpleadoEntidad empleado = new EmpleadoEntidad();

            using (SqlConnection cn = new SqlConnection(ConfiguracionApp.Default.ConexionVentasSql))
            {
                cn.Open();
                String sql = @"SELECT [Id_Emp]
                             ,[Ape_Emp]
                             ,[Nom_Emp]
                             ,[Ced_Emp]
                             ,[Dir_Emp]
                             ,[Tel_Emp]
                             ,[Email_Emp]
                             ,[Sue_Emp]
                             ,[Cla_Emp]
                            ,[cargo]
                                FROM [dbo].[Empleados]
                                WHERE [Id_Emp]= @empleadoId";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@empleadoId", idEmpleado);
                SqlDataReader reader = cmd.ExecuteReader();
                //repita la ejecucion mientras tenga datos
                while (reader.Read())
                {
                    empleado = CargarEmpleado(reader);
                }
            }
            return empleado;
        }

        public static EmpleadoEntidad DevolverEmpleadoPorCedula(string cedulaEmpleado)
        {
            EmpleadoEntidad empleado = new EmpleadoEntidad();

            using (SqlConnection cn = new SqlConnection(ConfiguracionApp.Default.ConexionVentasSql))
            {
                
                cn.Open();
                String sql = @"SELECT [Id_Emp]
                             ,[Ape_Emp]
                             ,[Nom_Emp]
                             ,[Ced_Emp]
                             ,[Dir_Emp]
                             ,[Tel_Emp]
                             ,[Email_Emp]
                             ,[Sue_Emp]
                             ,[Cla_Emp]
                                ,[cargo]
                                FROM [dbo].[Empleados]
                                WHERE [Ced_Emp]= @cedula";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@cedula", cedulaEmpleado);
                SqlDataReader reader = cmd.ExecuteReader();
                //repita la ejecucion mientras tenga datos
                while (reader.Read())
                {
                    empleado = CargarEmpleado(reader);
                }
            }
            return empleado;
        }

        public static int GuardarEmpleado(EmpleadoEntidad empleado)
        {

            using (SqlConnection cn = new SqlConnection(ConfiguracionApp.Default.ConexionVentasSql))
            {
                cn.Open();
                //todo cambiar los campos a la base del proyecto
                String sql = @"INSERT INTO [dbo].[Empleados]
                               ([Ced_Emp]
                               ,[Nom_Emp]
                               ,[Ape_Emp]
                               ,[Dir_Emp]
                               ,[Tel_Emp]
                               ,[Email_Emp]
                               ,[Sue_Emp]
                               ,[Cla_Emp]
                                ,[cargo])
                                  VALUES(
                               @ced
                               ,@nom
                               ,@ape
                               ,@dir
                               ,@tel
                               ,@email
                                ,@sue
                               ,@clave
                                ,@cargo);
                            SELECT SCOPE_IDENTITY()";
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@ced", empleado.Cedula);
                    cmd.Parameters.AddWithValue("@nom", empleado.Nombre);
                    cmd.Parameters.AddWithValue("@ape", empleado.Apellido);
                    cmd.Parameters.AddWithValue("@dir", empleado.Direccion);
                    cmd.Parameters.AddWithValue("@tel", empleado.Telefono);
                    cmd.Parameters.AddWithValue("@email", empleado.Email);
                    cmd.Parameters.AddWithValue("@sue", empleado.Sueldo);
                    cmd.Parameters.AddWithValue("@clave", empleado.Contraseña);
                    cmd.Parameters.AddWithValue("@cargo", empleado.Cargo);
                    empleado.Id = Convert.ToInt32(cmd.ExecuteScalar());
                }
                return empleado.Id;
            }
        }

        public static void EliminarEmpleado(EmpleadoEntidad empleadoActual)
        {
            using (SqlConnection cn = new SqlConnection(ConfiguracionApp.Default.ConexionVentasSql))
            {
                cn.Open();
                String sql = @"DELETE FROM [dbo].[empleados]
                                WHERE [Id_emp]= @empleadoId";
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {

                    cmd.Parameters.AddWithValue("@empleadoId", empleadoActual.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void ActualizarEmpleado(EmpleadoEntidad empleado)
        {

            using (SqlConnection cn = new SqlConnection(ConfiguracionApp.Default.ConexionVentasSql))
            {
                cn.Open();
                String sql = @"UPDATE [dbo].[empleados]
                               SET [Ced_Emp] = @ced
                                  ,[Nom_Emp] = @nom
                                  ,[Ape_Emp] = @ape
                                  ,[Dir_Emp] = @dir
                                  ,[Tel_Emp] = @tel
                                  ,[Email_Emp] = @email
                                ,[Sue_Emp] = @sue
                                  ,[Cla_Emp] = @clave
                                    ,[cargo] = @cargo
                               WHERE [Id_Emp]= @empleadoId";
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@ced", empleado.Cedula);
                    cmd.Parameters.AddWithValue("@nom", empleado.Nombre);
                    cmd.Parameters.AddWithValue("@ape", empleado.Apellido);
                    cmd.Parameters.AddWithValue("@dir", empleado.Direccion);
                    cmd.Parameters.AddWithValue("@tel", empleado.Telefono);
                    cmd.Parameters.AddWithValue("@email", empleado.Email);
                    cmd.Parameters.AddWithValue("@sue", empleado.Sueldo);
                    cmd.Parameters.AddWithValue("@clave", empleado.Contraseña);
                    cmd.Parameters.AddWithValue("@cargo", empleado.Cargo);
                    cmd.Parameters.AddWithValue("@empleadoId", empleado.Id);
                    cmd.ExecuteNonQuery();
                }

            }

        }

        public static EmpleadoEntidad CargarEmpleado(IDataReader reader)
        {
            //todo cambiar los nombres a los campos conforme se encuentra en la bdd del proyecto

            EmpleadoEntidad empleado = new EmpleadoEntidad();
            empleado.Id = Convert.ToInt32(reader["Id_Emp"]);
            empleado.Nombre = Convert.ToString(reader["Nom_Emp"]);
            empleado.Apellido = Convert.ToString(reader["Ape_Emp"]);
            empleado.Cedula = Convert.ToString(reader["Ced_Emp"]);
            empleado.Direccion = Convert.ToString(reader["Dir_Emp"]);
            empleado.Telefono = Convert.ToString(reader["Tel_Emp"]);
            empleado.Email = Convert.ToString(reader["Email_Emp"]);
            empleado.Sueldo = Convert.ToDouble(reader["Sue_Emp"]);
            empleado.Contraseña = Convert.ToString(reader["Cla_Emp"]);
            empleado.Cargo = Convert.ToString(reader["cargo"]);
            return empleado;
        }
    }
}
