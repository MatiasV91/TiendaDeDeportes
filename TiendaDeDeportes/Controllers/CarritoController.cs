using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaDeDeportes.Dominio.Entities;
using TiendaDeDeportes.Models;
using TiendaDeDePortes.Dominio.Abstract;
using TiendaDeDePortes.Dominio.Entities;

namespace TiendaDeDeportes.Controllers
{
    public class CarritoController : Controller
    {
        private IProductoRepositorio repositorio;

        public CarritoController(IProductoRepositorio repo)
        {
            repositorio = repo;
        }

        public ViewResult Index(Carrito carrito, string volverAUrl)
        {
            return View(new CarritoIndexViewModel
            {
                Carrito = carrito,
                VolverAUrl = volverAUrl
            });
        }

        public RedirectToRouteResult AgregarAlCarrito(Carrito carrito, int productoId, string volverAUrl)
        {
            Producto producto = repositorio.Productos.FirstOrDefault(p => p.ProductoId == productoId);
            if (producto != null)
            {
                carrito.AgregarItem(producto, 1);
            }
            return RedirectToAction("Index", new { volverAUrl });
        }

        public RedirectToRouteResult RemoverDelCarrito(Carrito carrito, int productoId, string volverAUrl)
        {
            Producto producto = repositorio.Productos.FirstOrDefault(p => p.ProductoId == productoId);

            if(producto != null)
            {
                carrito.RemoverItem(producto);
            }

            return RedirectToAction("Index", new { volverAUrl });
        }
    }
}