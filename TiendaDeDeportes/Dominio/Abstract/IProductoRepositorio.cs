using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaDeDePortes.Dominio.Entities;

namespace TiendaDeDePortes.Dominio.Abstract
{
    public interface IProductoRepositorio
    {
        IEnumerable<Producto> Productos { get; }
    }
}
