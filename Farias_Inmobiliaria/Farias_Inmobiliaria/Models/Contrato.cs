using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Farias_Inmobiliaria.Models
{
    public class Contrato
    {

        [Display(Name = "Código")]
        public int IdContrato { get; set; }


        [Display(Name = "Nombre del Garante")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public int IdGarante { get; set; }


        [Display(Name = "Propiedad")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public int IdInmueble { get; set; }


        [Display(Name = "Nombre del Inquilino")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public int IdInquilino { get; set; }


        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public DateTime? FechaInicio { get; set; }


        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public DateTime? FechaFin { get; set; }



        [Required(ErrorMessage = "Este campo es requerido.")]
        public string MontoAlquiler { get; set; }

        [ForeignKey(nameof(IdGarante))]
        public Garante  Garante { get; set; }


        [ForeignKey(nameof(IdInmueble))]
        public Inmueble Inmueble { get; set; }

        [ForeignKey(nameof(IdInquilino))]
        public Inquilino Inquilino { get; set; }



    }
}
