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
        

        [Required(ErrorMessage = "Direccion es requerido.")]                                    // required
        public string Direccion { get; set; }

        [RegularExpression(@"^[a-zA-Z\s]{2,254}", ErrorMessage = "Solo letras o espacios")]
        [Required(ErrorMessage = "Uso del local es requerido.")]                                // required
        [Display(Name = "Uso del local")]
        public string Uso { get; set; }

        [Required(ErrorMessage = "Tipo es requerido.")]                                         // required
        public string Tipo { get; set; }


        [Required(ErrorMessage = "Cantidad de ambientes es requerido.")]                        // required
        [Display(Name = "Cantidad de ambientes")]
        public int Ambientes { get; set; }


        [Required(ErrorMessage = "Este campo es requerido.")]                                   // required
        [RegularExpression("^-?\\d+(?:,\\d+)?$", ErrorMessage = "Solo numeros y coma")]
        [Display(Name = "Monto alquiler")]
        public String MontoAlquilerPropuesto { get; set; }

        [ForeignKey(nameof(IdPropietario))]
        public Propietario Duenio { get; set; }

        [Display(Name = "Disponibilidad")]
        public bool Disponibilidad { get; set; }

        public String Imagen { get; set; }


        [RegularExpression("^[0-9]+([,][0-9]+)?$", ErrorMessage = "Solo numeros y coma")]
        // [Required(ErrorMessage = "Superficie es requerido.")]                                   
        public String Superficie { get; set; }

        [RegularExpression("^-?\\d+(?:,\\d+)?$", ErrorMessage = "Solo numeros, signo - y coma")]
        // [Required(ErrorMessage = "Latitud es requerido.")]
        public String Latitud { get; set; }



        [RegularExpression("^-?\\d+(?:,\\d+)?$", ErrorMessage = "Solo numeros, signo - y coma")]
        // [Required(ErrorMessage = "Longitud es requerido.")]
        public String Longitud { get; set; }
                
        
        // [Required(ErrorMessage = "Precio aproximado es requerido.")]
        [RegularExpression("^-?\\d+(?:,\\d+)?$", ErrorMessage = "Solo numeros y coma")]
        [Display(Name = "Precio aproximado")]
        public String PrecioAproximado { get; set; }



        // [Required(ErrorMessage = "Dueño (Id Propietario) es requerido.")]
        [Display(Name = "Dueño")]
        public int? IdPropietario { get; set; }



        // public Inquilino Inquilino { get; set; }

    }
}
