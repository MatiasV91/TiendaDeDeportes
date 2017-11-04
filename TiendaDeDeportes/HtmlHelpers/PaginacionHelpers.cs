using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TiendaDeDeportes.Models;

namespace TiendaDeDeportes.HtmlHelpers
{
    public static class PaginacionHelpers
    {
        public static MvcHtmlString PaginasLinks(this HtmlHelper html, PaginacionInfo paginacionInfo, Func<int, string> urlPagina)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= paginacionInfo.TotalPaginas; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", urlPagina(i));
                tag.InnerHtml = i.ToString();
                if (i == paginacionInfo.PaginaActual)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }

    }
}