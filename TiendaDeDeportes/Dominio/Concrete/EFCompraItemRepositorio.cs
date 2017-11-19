using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TiendaDeDeportes.Dominio.Abstract;
using TiendaDeDeportes.Dominio.Entities;
using TiendaDeDeportes.Models;

namespace TiendaDeDeportes.Dominio.Concrete
{
    public class EFCompraItemRepositorio : ICompraItemRepositorio
    {
        private ApplicationDbContext _contexto = new ApplicationDbContext();

        public IEnumerable<CompraItem> CompraItems(int detallesEnvioId)
        {
            return _contexto.CompraItems.Include(c => c.Producto).Where(c => c.DetallesEnvioId == detallesEnvioId);
        }

        public void GuardarCompraItem(CompraItem compraItem)
        {
            _contexto.CompraItems.Add(compraItem);
            _contexto.SaveChanges();
        }
    }
}