﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaDeDePortes.Dominio.Entities
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Decimal Precio { get; set; }
        public string Categoria { get; set; }
    }
}
