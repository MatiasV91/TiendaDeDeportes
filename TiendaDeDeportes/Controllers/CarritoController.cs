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

        private Carrito GetCarrito()
        {
            Carrito carrito = (Carrito)Session["Carrito"];
            if (carrito == null)
            {
                carrito = new Carrito();
                Session["Carrito"] = carrito;
            }
            return carrito;
        }

        public ViewResult Index(string volverAUrl)
        {
            return View(new CarritoIndexViewModel
            {
                Carrito = GetCarrito(),
                VolverAUrl = volverAUrl
            });
        }

        public RedirectToRouteResult AgregarAlCarrito(int productoId, string volverAUrl)
        {
            Producto producto = repositorio.Productos.FirstOrDefault(p => p.ProductoId == productoId);
            if (producto != null)
            {
                GetCarrito().AgregarItem(producto, 1);
            }
            return RedirectToAction("Index", new { volverAUrl });
        }

        public RedirectToRouteResult RemoverDelCarrito(int productoId, string volverAUrl)
        {
            Producto producto = repositorio.Productos.FirstOrDefault(p => p.ProductoId == productoId);

            if(producto != null)
            {
                GetCarrito().RemoverItem(producto);
            }

            return RedirectToAction("Index", new { volverAUrl });
        }
    }
}