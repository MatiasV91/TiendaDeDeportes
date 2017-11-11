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

        public void GuardarProducto(Producto producto)
        {
            if(producto.ProductoId == 0)
            {
                _context.Productos.Add(producto);
            }
            else
            {
                Producto dbEntry = _context.Productos.Find(producto.ProductoId);
                if (dbEntry != null)
                {
                    dbEntry.Nombre = producto.Nombre;
                    dbEntry.Descripcion = producto.Descripcion;
                    dbEntry.Precio = producto.Precio;
                    dbEntry.Categoria = producto.Categoria;
                    if(producto.ImagenData != null)
                    {
                        dbEntry.ImagenData = producto.ImagenData;
                        dbEntry.ImagenMimeType = producto.ImagenMimeType;
                    }
                }
            }
            _context.SaveChanges();
        }

        public Producto EliminarProducto(int productoId)
        {
            Producto dbEntry = _context.Productos.Find(productoId);

            if (dbEntry != null)
            {
                _context.Productos.Remove(dbEntry);
                _context.SaveChanges();
            }

            return dbEntry;
        }
    }

}
