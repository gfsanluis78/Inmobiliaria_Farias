using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Farias_Inmobiliaria.Models


{
    public enum enRoles
    {
        Administrador = 1,
        Empleado = 2
    }

    public class Usuario
    {
		[Key]
		[Display(Name = "Código")]
		public int Id { get; set; }
		
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
		//[RegularExpression(@"[0-9]", ErrorMessage = "Solo numeros")]
		public string DNI { get; set; }

		[Display(Name = "Correo electrónico")]
		[Required(ErrorMessage = "Este campo es requerido.")]
		[RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
		   ErrorMessage = "Dirección de Correo electrónico incorrecta.")]
		[StringLength(100, ErrorMessage = "Longitud máxima 100")]
		[EmailAddress(ErrorMessage = "Direccion de Correo incorrecta")]    //No la puedo personalizar
		public string Email { get; set; }


		[Display(Name = "Contraseña")]
		[Required(ErrorMessage = "Este campo es requerido.")]
		[StringLength(15, ErrorMessage = "Longitud entre 6 y 15 caracteres.",
					  MinimumLength = 6)]
		[DataType(DataType.Password)]
		public string Clave { get; set; }

		public string Avatar { get; set; }
		
		[NotMapped]//Para EF
		public IFormFile AvatarFile { get; set; }
		
		public int Rol { get; set; }


		[Display(Name = "Nombre del Rol")]
		[NotMapped]//Para EF
		public string RolNombre => Rol > 0 ? ((enRoles)Rol).ToString() : "";    // Paso un enumerado a string

		public static IDictionary<int, string> ObtenerRoles()   // para usar en lo selects
		{
			SortedDictionary<int, string> roles = new SortedDictionary<int, string>();
			Type tipoEnumRol = typeof(enRoles);
			foreach (var valor in Enum.GetValues(tipoEnumRol))
			{
				roles.Add((int)valor, Enum.GetName(tipoEnumRol, valor));
			}
			return roles;
		}
	}
}
