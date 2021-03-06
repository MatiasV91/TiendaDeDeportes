﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiendaDeDeportes.Dominio.Entities;

namespace TiendaDeDeportes.Models
{
    public class ListaProductosViewModel
    {
        public IEnumerable<Producto> Productos { get; set; }
        public PaginacionInfo PaginacionInfo { get; set; }
        public string CategoriaActual { get; set; }
    }
}