using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Farias_Inmobiliaria.Models
{
    public class Inmueble
    {
        [Key]
        [Display(Name = "Código")]
        public int IdInmueble { get; set; }
        

        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Direccion { get; set; }


        [RegularExpression("^[0-9]+([,][0-9]+)?$", ErrorMessage = "Solo numeros y coma")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public String Superficie { get; set; }

        [RegularExpression("^-?\\d+(?:,\\d+)?$", ErrorMessage = "Solo numeros, signo - y coma")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public String Latitud { get; set; }



        [RegularExpression("^-?\\d+(?:,\\d+)?$", ErrorMessage = "Solo numeros, signo - y coma")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public String Longitud { get; set; }


        [RegularExpression(@"^[a-zA-Z\s]{2,254}", ErrorMessage = "Solo letras o espacios")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Uso del local")]
        public string Uso { get; set; }


        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Tipo { get; set; }


        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Cantidad de ambientes")]
        public int Ambientes { get; set; }
                
        
        [Required(ErrorMessage = "Este campo es requerido.")]
        [RegularExpression("^-?\\d+(?:,\\d+)?$", ErrorMessage = "Solo numeros y coma")]
        [Display(Name = "Precio aproximado")]
        public String PrecioAproximado { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [RegularExpression("^-?\\d+(?:,\\d+)?$", ErrorMessage = "Solo numeros y coma")]
        [Display(Name = "Monto alquiler")]
        public String MontoAlquilerPropuesto { get; set; }

        [Display(Name = "Disponibilidad")]
        public bool Disponibilidad { get; set; }


        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Dueño")]
        public int? IdPropietario { get; set; }


        [ForeignKey(nameof(IdPropietario))]
        public Propietario Duenio { get; set; }

        public Inquilino Inquilino { get; set; }

    }
}
