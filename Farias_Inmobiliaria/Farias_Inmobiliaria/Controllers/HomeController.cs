using Farias_Inmobiliaria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Farias_Inmobiliaria.Controllers
{
    public class HomeController : Controller
        

    {
        private readonly ILogger<HomeController> _logger;
        private readonly RepositorioPropietario propietarios;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            propietarios = new RepositorioPropietario();
        }

        public IActionResult Index()
        {
            List<string> clientes = propietarios.ObtenerTodos().Select(x => x.Nombre + " " + x.Apellido).ToList();
            return View(clientes);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
