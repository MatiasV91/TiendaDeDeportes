using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaDeDeportes.Models
{
    public class PaginacionInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPorPagina { get; set; }
        public int PaginaActual { get; set; }

        public int TotalPaginas
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / ItemsPorPagina); }
        }
    }
}