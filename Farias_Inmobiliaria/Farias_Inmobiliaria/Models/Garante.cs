﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Farias_Inmobiliaria.Models
{
    public class Garante
    {
        [Key]
        [Display(Name = "Código")]
        public int IdGarante { get; set; }

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

        
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Trabajo { get; set; }



        [Required(ErrorMessage = "Este campo es requerido.")]
        //[RegularExpression(@"^(\d{2}\.{1}\d{3}\.\d{3})|(\d{2}\s{1}\d{3}\s\d{3})$", ErrorMessage = "Ingrese un dni correcto")]

        public string Dni { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        //[RegularExpression(@"/^(?:(?:00)?549?)?0?(?:11|[2368]\d)(?:(?=\d{0,2}15)\d{2})??\d{8}$/", ErrorMessage = "Telefono incorrecto")] //Probar pasando el string a bigint
        [Display(Name = "Numero de telefono")]
        [Phone]
        public string Telefono { get; set; }

        [Display(Name = "Correo electrónico")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
            ErrorMessage = "Dirección de Correo electrónico incorrecta.")]
        [StringLength(100, ErrorMessage = "Longitud máxima 100")]
        [EmailAddress(ErrorMessage = "Direccion de Correo incorrecta")]    //No la puedo personalizar
        public string Email { get; set; }

        public string GetNombreCompleto()
        {
            return this.Nombre + " " +this.Apellido;
        }


    }

}
