using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiendaDeDeportes.Dominio.Abstract;
using TiendaDeDeportes.Dominio.Entities;

namespace TiendaDeDeportes.Dominio.Concrete
{
    public class ProcesarOrdenDb : IProcesarOrden
    {
        private ICompraItemRepositorio compraItemRepositorio;
        private IDetallesEnvioRepositorio detallesEnvioRepositorio;

        public ProcesarOrdenDb(ICompraItemRepositorio cIRepo,IDetallesEnvioRepositorio dERepo )
        {
            compraItemRepositorio = cIRepo;
            detallesEnvioRepositorio = dERepo;
        }

        public void ProcesarOrden(Carrito carrito, DetallesEnvio detallesEnvio)
        {
            List<CompraItem> compras = new List<CompraItem>();

            detallesEnvio = detallesEnvioRepositorio.GuardarEnvio(detallesEnvio);

            foreach(var item in carrito.Items)
            {
                compras.Add(new CompraItem
                {
                    Cantidad = item.Cantidad,
                    ProductoId = item.Producto.ProductoId,
                    DetallesEnvioId = detallesEnvio.DetallesEnvioId
                });
            }

            foreach(var compra in compras)
            {
                compraItemRepositorio.GuardarCompraItem(compra);
            }
        }
    }
}