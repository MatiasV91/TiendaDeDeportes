using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaDeDeportes.Models;
using TiendaDeDePortes.Dominio.Abstract;

namespace TiendaDeDePortes.Controllers
{
    public class ProductoController : Controller
    {
        private IProductoRepositorio repositorio;
        public int NumeroPorPagina = 4;

        public ProductoController(IProductoRepositorio productoRepositorio)
        {
            this.repositorio = productoRepositorio;
        }

        public ViewResult Lista(int page = 1)
        {
            ListaProductosViewModel vm = new ListaProductosViewModel
            {
                Productos = repositorio.Productos
                                        .OrderBy(p => p.ProductoId)
                                        .Skip((page - 1) * NumeroPorPagina)
                                        .Take(NumeroPorPagina),

                PaginacionInfo = new PaginacionInfo
                {
                    PaginaActual = page,
                    ItemsPorPagina = NumeroPorPagina,
                    TotalItems = repositorio.Productos.Count()
                }
            };
            return View(vm);
        }

    }
}