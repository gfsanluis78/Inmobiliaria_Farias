using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farias_Inmobiliaria.Models
{
    public class DisponiblesEntreFechas
    {
        public int Id { get; set; }
        public string Direccion { get; set; }
        public String Tipo { get; set; }
        public int Ambientes { get; set; }

        public String MontoAlquilerPropuesto { get; set; }
    }
}
