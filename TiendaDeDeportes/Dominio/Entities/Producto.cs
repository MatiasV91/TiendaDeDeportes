using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaDeDeportes.Dominio.Entities
{
    public class Producto
    {
        public int ProductoId { get; set; }
        [Required(ErrorMessage ="Ingrese el Nombre del Producto")]
        public string Nombre { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Ingrese la Descripcion del Producto")]
        public string Descripcion { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage ="Ingrese un Precio positivo")]
        public Decimal Precio { get; set; }

        [Required(ErrorMessage = "Especifique una Categoria")]
        public string Categoria { get; set; }

        public byte[] ImagenData { get; set; }
        public string ImagenMimeType { get; set; }
    }
}
