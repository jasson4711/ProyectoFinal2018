﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluminiosEntidades
{
    public class DetalleEntidadMostrar
    {
        public int IdVenta { get; set; }
        public string NombreProducto { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public decimal TotalProducto
        {
            get
            {
                return this.PrecioUnitario * Cantidad;  
            }
        }
    }
}
