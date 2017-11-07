using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaDeDePortes.Dominio.Abstract;

namespace TiendaDeDeportes.Controllers
{
    public class NavController : Controller
    {
        private IProductoRepositorio repositorio;
        public NavController(IProductoRepositorio repo)
        {
            repositorio = repo;
        }

        public PartialViewResult Menu(string categoria = null, bool menuMobile = false)
        {
            ViewBag.CategoriaActual = categoria;
            IEnumerable<string> categorias = repositorio.Productos
                                                    .Select(x => x.Categoria)
                                                    .Distinct()
                                                    .OrderBy(x => x);

            if (menuMobile)
            {
                return PartialView("MenuMobile", categorias);
            }
            return PartialView(categorias);
        }
    }
}