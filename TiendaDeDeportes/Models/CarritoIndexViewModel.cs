using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiendaDeDeportes.Dominio.Entities;

namespace TiendaDeDeportes.Models
{
    public class CarritoIndexViewModel
    {
        public Carrito Carrito{ get; set; }
        public string VolverAUrl { get; set; }
    }
}