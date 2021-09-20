using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farias_Inmobiliaria.Models
{
    public class BuscarEntreFecha
    {
        public DateTime Desde { get; set; }

        public DateTime Hasta { get; set; }

        public int Inmueble { get; set; }
    }
}
