using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaDeDeportes.Models;
using TiendaDeDeportes.Dominio.Abstract;
using TiendaDeDeportes.Dominio.Entities;

namespace TiendaDeDeportes.Controllers
{
    public class ProductoController : Controller
    {
        private IProductoRepositorio repositorio;
        public int NumeroPorPagina = 5;

        public ProductoController(IProductoRepositorio productoRepositorio)
        {
            this.repositorio = productoRepositorio;
        }

        public ViewResult Lista(string categoria,int pagina = 1)
        {
            ListaProductosViewModel vm = new ListaProductosViewModel
            {
                Productos = repositorio.Productos
                .Where(p => categoria == null || p.Categoria == categoria)
                                        .OrderBy(p => p.ProductoId)
                                        .Skip((pagina - 1) * NumeroPorPagina)
                                        .Take(NumeroPorPagina),

                PaginacionInfo = new PaginacionInfo
                {
                    PaginaActual = pagina,
                    ItemsPorPagina = NumeroPorPagina,
                    TotalItems = categoria == null ?
                                                repositorio.Productos.Count() :
                                                repositorio.Productos.Where(e => e.Categoria == categoria).Count()
                },

                CategoriaActual = categoria
            };
            return View(vm);
        }

        public FileContentResult GetImagen(int productoId)
        {
            Producto producto = repositorio.Productos.FirstOrDefault(p => p.ProductoId == productoId);
            if (producto != null)
            {
                return File(producto.ImagenData, producto.ImagenMimeType);
            }
            else
            {
                return null;
            }
        }

    }
}