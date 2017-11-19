using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaDeDeportes.Dominio.Abstract;
using TiendaDeDeportes.Models;

namespace TiendaDeDeportes.Controllers
{
    public class OrdenesController : Controller
    {
        private IDetallesEnvioRepositorio envioRepositorio;
        private ICompraItemRepositorio compraRepositorio;

        public OrdenesController(IDetallesEnvioRepositorio detallesRepo, ICompraItemRepositorio compraRepo)
        {
            envioRepositorio = detallesRepo;
            compraRepositorio = compraRepo;
        }

        public ViewResult Index()
        {
            return View(envioRepositorio.DetallesEnvios);
        }

        public ActionResult Detalles(int detallesEnvioId)
        {
            var vm = new OrdenesViewModel
            {
                Compras = compraRepositorio.CompraItems(detallesEnvioId),
                DetallesEnvio = envioRepositorio.DetallesEnvio(detallesEnvioId)
            };
            return View(vm);
        }

    }
}