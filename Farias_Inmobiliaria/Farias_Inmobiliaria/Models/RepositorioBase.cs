using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farias_Inmobiliaria.Models
{
    public abstract class RepositorioBase
    {
        protected readonly IConfiguration configuration;
        protected readonly string connectionString;

        public RepositorioBase(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = configuration["ConnectionStrings:DefaultConnection"];
            //connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Farias_inmonbiliaria_BD;Trusted_Connection=True;MultipleActiveResultSets=true";
        }

    }
}
