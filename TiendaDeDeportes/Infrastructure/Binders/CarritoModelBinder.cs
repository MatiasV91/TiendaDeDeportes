using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaDeDeportes.Dominio.Entities;

namespace TiendaDeDeportes.Infrastructure.Binders
{
    public class CarritoModelBinder : IModelBinder
    {
        private const string sessionKey = "Carrito";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Carrito carrito = null;
            if(controllerContext.HttpContext.Session != null)
            {
                carrito = (Carrito)controllerContext.HttpContext.Session[sessionKey];
            }
            if(carrito == null)
            {
                carrito = new Carrito();
                if(controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = carrito;
                }
            }
            return carrito;
        }
    }
}