using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaDeDePortes.Dominio.Abstract;
using TiendaDeDePortes.Dominio.Entities;

namespace TiendaDeDeportes.Controllers
{
    public class AdminController : Controller
    {
        private IProductoRepositorio repositorio;

        public AdminController(IProductoRepositorio repo)
        {
            repositorio = repo;
        }

        public ActionResult Index()
        {
            return View(repositorio.Productos);
        }

        public ViewResult Create()
        {
            return View("Edit", new Producto());
        }

        public ViewResult Edit(int productoId)
        {
            Producto producto = repositorio.Productos.FirstOrDefault(p => p.ProductoId == productoId);
            return View(producto);
        }

        [HttpPost]
        public ActionResult Edit(Producto producto)
        {
            if (ModelState.IsValid)
            {
                repositorio.GuardarProducto(producto);
                TempData["mensaje"] = string.Format("{0} Se guardo Correctamente", producto.Nombre);
                return RedirectToAction("Index");
            }
            else
            {
                return View(producto);
            }
        }

        [HttpPost]
        public ActionResult Delete(int productoId)
        {
            Producto productoEleminado = repositorio.EliminarProducto(productoId);

            if(productoEleminado != null)
            {
                TempData["mensaje"] = string.Format("{0} fue Eliminado Correctamente", productoEleminado.Nombre);
            }

            return RedirectToAction("Index");
        }
    }
}