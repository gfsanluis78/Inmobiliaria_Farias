using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Farias_Inmobiliaria.Models
{
    public class LoginRetrofit
    {
        public LoginRetrofit(string Token, Propietario Propietario)
        {
            this.Token = Token;
            this.Propietario = Propietario;
        }

        public LoginRetrofit(string Token)
        {
            this.Token = Token;
        }


        public String Token { get; set; }


        
        public Propietario Propietario { get; set; }
    }
}
