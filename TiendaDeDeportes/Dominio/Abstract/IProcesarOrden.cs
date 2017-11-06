using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaDeDeportes.Dominio.Entities;

namespace TiendaDeDeportes.Dominio.Abstract
{
    public interface IProcesarOrden
    {
        void ProcesarOrden(Carrito carrito, DetallesEnvio detallesEnvio);
    }
}
