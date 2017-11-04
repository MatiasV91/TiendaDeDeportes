using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaDeDeportes.Models;
using TiendaDeDePortes.Dominio.Abstract;
using TiendaDeDePortes.Dominio.Entities;

namespace TiendaDeDePortes.Dominio.Concrete
{
    public class EFProductoRepositorio : IProductoRepositorio
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public IEnumerable<Producto> Productos { get { return _context.Productos; } }
    }
}
