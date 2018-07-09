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
    public class EmpleadoNegocio
    {
        public static List<EmpleadoEntidad> DevolverListaEmpleados()
        {

            return EmpleadoDatos.DevolverListaEmpleados();
        }

        public static EmpleadoEntidad DevolverEmpleadoPorID(int idEmpleado)
        {
            return EmpleadoDatos.DevolverEmpleadoPorID(idEmpleado);
        }

       //todo hacer insertar modificar y borrar empleado

        public static EmpleadoEntidad DevolverEmpleadoPorCedula(string text)
        {
            return EmpleadoDatos.DevolverEmpleadoPorCedula(text);
        }

        public static List<EmpleadoEntidad> DevolverEmpleadoPorApellido(string text)
        {
            return EmpleadoDatos.DevolverEmpleadoPorApellido(text);
        }

        public static void ActualizarEmpleado(EmpleadoEntidad empleado)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                EmpleadoDatos.ActualizarEmpleado(empleado);
                scope.Complete();
            }

        }

        public static int GuardarEmpleado(EmpleadoEntidad empleado)
        {
            int id = 0;
            using (TransactionScope scope = new TransactionScope())
            {
                id = EmpleadoDatos.GuardarEmpleado(empleado);
                scope.Complete();
            }
            return id;

        }

        public static void EliminarEmpleado(EmpleadoEntidad empleado)
        {
            EmpleadoDatos.EliminarEmpleado(empleado);
        }
    }
}
