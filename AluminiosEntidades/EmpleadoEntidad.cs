using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluminiosEntidades
{
    public class EmpleadoEntidad : PersonaEntidad
    {
        public double Sueldo { get; set; }
        public string Contraseña { get; set; }
        public string Cargo { get; set; }
        public int Estado { get; set; }
    }
}
