using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TiendaDeDeportes
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null,
                "",
                new
                {
                    controller = "Producto", action = "Lista",
                    categoria = (string)null, pagina = 1
                });

            routes.MapRoute(null,
                "Pagina{pagina}",
                new { controller = "Producto", action = "Lista", categoria = (string)null},
                new { pagina = @"\d+"}
                );

            routes.MapRoute(null,
                "{categoria}",
                new { controller = "Producto", action = "Lista", pagina = 1 }
                );

            routes.MapRoute(null,
                "{categoria}/Pagina{pagina}",
                new { controller = "Producto", action = "Lista" },
                new { pagina = @"d+" }
                );

            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
