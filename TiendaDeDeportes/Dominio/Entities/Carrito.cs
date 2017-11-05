using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiendaDeDePortes.Dominio.Entities;

namespace TiendaDeDeportes.Dominio.Entities
{
    public class Carrito
    {
        private List<CarritoItem> coleccionItems = new List<CarritoItem>();

        public void AgregarItem(Producto producto, int cantidad)
        {
            CarritoItem Item = coleccionItems.Where(p => p.Producto.ProductoId == producto.ProductoId).FirstOrDefault();
            if (Item == null)
            {
                coleccionItems.Add(new CarritoItem { Producto = producto, Cantidad = cantidad });
            }
            else
            {
                Item.Cantidad += cantidad;
            }
        }

        public void RemoverItem(Producto producto)
        {
            coleccionItems.RemoveAll(i => i.Producto.ProductoId == producto.ProductoId);
        }

        public decimal CalcularValorTotal()
        {
            return coleccionItems.Sum(p => p.Producto.Precio * p.Cantidad);
        }

        public void RemoverTodo()
        {
            coleccionItems.Clear();
        }

        public IEnumerable<CarritoItem> Items
        {
            get { return coleccionItems; }
        }
    }

    public class CarritoItem
    {
        public Producto Producto{ get; set; }
        public int Cantidad { get; set; }
    }
}