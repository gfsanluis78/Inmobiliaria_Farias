using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Farias_Inmobiliaria.Models
{
    public class Propietario
    {   

        [Key]
        [Display(Name = "Código")]
        public int IdPropietario { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        //[RegularExpression(@"[0-9]", ErrorMessage = "Solo numeros")]
        public String Dni { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(30, ErrorMessage = "Longitud entre 4 y 30 caracteres.",
                      MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z\s]{2,254}", ErrorMessage = "Solo letras o espacios")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(30, ErrorMessage = "Longitud entre 4 y 30 caracteres.",
                      MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z\s]{2,254}", ErrorMessage = "Solo letras o espacios")]
        public string Apellido { get; set; }

        [Display(Name = "Correo electrónico")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
       ErrorMessage = "Dirección de Correo electrónico incorrecta.")]
        [StringLength(100, ErrorMessage = "Longitud máxima 100")]
        [EmailAddress(ErrorMessage = "Direccion de Correo incorrecta")]    //No la puedo personalizar
        public string Email { get; set; }


        [Display(Name = "Contraseña")]
        //[Required(ErrorMessage = "Este campo es requerido.")]
        //[StringLength(60, ErrorMessage = "Longitud entre 6 y 15 caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }



        [Required(ErrorMessage = "Este campo es requerido.")]
        //[RegularExpression(@"/^(?:(?:00)?549?)?0?(?:11|[2368]\d)(?:(?=\d{0,2}15)\d{2})??\d{8}$/", ErrorMessage = "Telefono incorrecto")] //Probar pasando el string a bigint
        [Display(Name = "Numero de telefono")]
        [Phone]
        public string Telefono { get; set; }

        //public static implicit operator int(Propietario v)
        //{
        //    throw new NotImplementedException();
        //}

        public string Avatar { get; set; }

        [NotMapped]//Para EF
        public IFormFile AvatarFile { get; set; }

        public string GetNombreCompleto()
        {
            return this.Nombre + " " + this.Apellido;
        }

    }
}
