
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Farias_Inmobiliaria.Models
{
    public class Pago
    {
        // Id del pago

        [Display(Name = "Código")]
        public int IdPago { get; set; }

        // Numero del pago

        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Numero")]
        public int? NumeroPago { get; set; }

        // Id contrato

        [Required(ErrorMessage = "El contrato es requerido.")]
        [Display(Name = "Contrato")]
        public int? IdContrato { get; set; }

        // Fecha

        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        //[Required(ErrorMessage = "La Fecha es requerida.")]
        public DateTime? Fecha { get; set; }

        // Importe

        [Required(ErrorMessage = "Este campo es requerido.")]
        [RegularExpression("^-?\\d+(?:,\\d+)?$", ErrorMessage = "Solo numeros y coma")]
        [Display(Name = "Importe")]
        public String Importe { get; set; }


        // Keys 

        [ForeignKey(nameof(IdContrato))]
        public Contrato Contrato { get; set; }

    }
}
