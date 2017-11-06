using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaDeDeportes.Dominio.Abstract;
using TiendaDeDeportes.Dominio.Entities;
using TiendaDeDeportes.Models;
using TiendaDeDePortes.Dominio.Abstract;
using TiendaDeDePortes.Dominio.Entities;

namespace TiendaDeDeportes.Controllers
{
    public class CarritoController : Controller
    {
        private IProductoRepositorio repositorio;
        private IProcesarOrden procesarOrden;

        public CarritoController(IProductoRepositorio repo, IProcesarOrden procesar)
        {
            repositorio = repo;
            procesarOrden = procesar;
        }

        public ViewResult Index(Carrito carrito, string volverAUrl)
        {
            return View(new CarritoIndexViewModel
            {
                Carrito = carrito,
                VolverAUrl = volverAUrl
            });
        }

        public PartialViewResult Sumario(Carrito carrito)
        {
            return PartialView(carrito);
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

        public ViewResult Checkout()
        {
            return View(new DetallesEnvio());
        }

        [HttpPost]
        public ViewResult Checkout(Carrito carrito, DetallesEnvio detallesEnvio)
        {
            if(carrito.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Tu Carrito esta Vacio!");
            }

            if (ModelState.IsValid)
            {
                procesarOrden.ProcesarOrden(carrito, detallesEnvio);
                carrito.RemoverTodo();
                return View("Completado");
            }
            else
            {
                return View(detallesEnvio);
            }
        }
    }
}