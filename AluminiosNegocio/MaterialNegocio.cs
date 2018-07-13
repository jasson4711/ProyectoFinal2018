using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AluminiosDatos;
using AluminiosEntidades;

namespace AluminiosNegocio
{
    public static class MaterialNegocio
    {
        public static List<MaterialEntidad> DevolverListaMateriales()
        {
            return MaterialDatos.DevolverListaMateriales();
        }
    }
}
