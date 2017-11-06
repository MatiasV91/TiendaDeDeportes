using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TiendaDeDeportes.Dominio.Entities
{
    public class DetallesEnvio
    {
        [Required(ErrorMessage = "Escriba un Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Escriba la Direccion")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Escriba la Localidad")]
        public string Localidad { get; set; }

        [Required(ErrorMessage = "Escriba la Provincia")]
        public string Provincia { get; set; }

        [Required(ErrorMessage = "Escriba el Pais")]
        public string Pais { get; set; }

        [Required(ErrorMessage = "Escriba el Codigo Postal")]
        public string CodigoPostal { get; set; }


        public bool EnvolverParaRegalo { get; set; }
    }
}