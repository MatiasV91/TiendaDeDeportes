using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiendaDeDePortes.Dominio.Entities;

namespace TiendaDeDeportes.Dominio.Entities
{
    public class CompraItem
    {
        public int CompraItemId { get; set; }

        public int Cantidad { get; set; }

        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

        public int DetallesEnvioId { get; set; }
        public DetallesEnvio DetallesEnvio { get; set; }
    }
}