using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiendaDeDeportes.Dominio.Abstract;
using TiendaDeDeportes.Dominio.Entities;
using TiendaDeDeportes.Models;

namespace TiendaDeDeportes.Dominio.Concrete
{
    public class EFDetallesEnvioRepositorio : IDetallesEnvioRepositorio
    {
        private ApplicationDbContext _contexto = new ApplicationDbContext();

        public IEnumerable<DetallesEnvio> DetallesEnvios { get { return _contexto.DetallesEnvios; } }

        public DetallesEnvio DetallesEnvio(int detallesEnvioId)
        {
            return _contexto.DetallesEnvios.SingleOrDefault(d => d.DetallesEnvioId == detallesEnvioId);
        }

        public DetallesEnvio GuardarEnvio(DetallesEnvio detallesEnvio)
        {
            var detalles = _contexto.DetallesEnvios.Add(detallesEnvio);
            _contexto.SaveChanges();
            return detalles;
        }
    }
}