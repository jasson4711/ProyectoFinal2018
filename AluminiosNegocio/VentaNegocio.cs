using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using AluminiosDatos;
using AluminiosEntidades;
namespace AluminiosNegocio
{
    public static class VentaNegocio
    {
        public static int GenerarVenta(VentaEntidad ventas)
        {
            int id = 0;
            using (TransactionScope scope = new TransactionScope())
            {
                id = VentaDatos.GenerarVenta(ventas);
                VentaDatos.UpdateTotal(ventas.Id, ventas.Total);
                scope.Complete();
            }
            return id;
        }
    }
}
