using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiendaDeDeportes.Dominio.Entities;

namespace TiendaDeDeportes.Dominio.Abstract
{
    public interface IDetallesEnvioRepositorio
    {
        DetallesEnvio GuardarEnvio(DetallesEnvio detallesEnvio);
        IEnumerable<DetallesEnvio> DetallesEnvios { get; }
        DetallesEnvio DetallesEnvio(int detallesEnvioId);
    }
}