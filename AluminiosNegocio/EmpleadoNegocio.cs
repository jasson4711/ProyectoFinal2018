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
    }
}
