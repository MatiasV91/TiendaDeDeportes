using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiendaDeDeportes.Dominio.Entities;

namespace TiendaDeDeportes.Models
{
    public class OrdenesViewModel
    {
        public IEnumerable<CompraItem> Compras { get; set; }
        public DetallesEnvio DetallesEnvio { get; set; }


        public Decimal Total
        { get
            {
                Decimal suma = 0;
                foreach(var compra in Compras)
                {
                    suma += compra.Cantidad * compra.Producto.Precio;
                }
                return suma;
            }
        }
    }
}