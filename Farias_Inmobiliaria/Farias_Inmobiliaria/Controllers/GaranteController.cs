using Farias_Inmobiliaria.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farias_Inmobiliaria.Controllers
{
    [Authorize]
    public class GaranteController : Controller
    {
        RepositorioGarante repositorio;
        public GaranteController(IConfiguration configuration) 
        {
            repositorio = new RepositorioGarante(configuration);
        }
        
        
        // GET: GaranteController
        public ActionResult Index()
        {
            try
            {
                var lista = repositorio.ObtenerTodos();
                if (TempData.ContainsKey("Id"))
                    ViewBag.Id = TempData["Id"];
                if (TempData.ContainsKey("Mensaje"))
                    ViewBag.Mensaje = TempData["Mensaje"];
                //throw new Exception(); //Prueba de cacth
                return View(lista);
            }
            catch (Exception ex) 
            {
                ViewBag.Error = ex.Message; 
                return View(); }
        }

        // GET: GaranteController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                Garante i = repositorio.ObtenerPorId(id);

                return View(i);
            }
            catch (Exception ex) 
            {
                ViewBag.Error = ex.Message; 
                return View(); 
            }

        }

        // GET: GaranteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GaranteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Garante g)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repositorio.Alta(g);
                    TempData["Id"] = g.IdGarante;
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["Mensaje"] = "Ocurrio un error con el modelo al Crear";
                    return View(g);
                }
            }
            catch (Exception ex) 
            {
                ViewBag.Error = ex.Message; 
                return View(g); 
            }
        }

        // GET: GaranteController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var i = repositorio.ObtenerPorId(id);

                if (TempData.ContainsKey("Mensaje"))
                    ViewBag.Mensaje = TempData["Mensaje"];
                if (TempData.ContainsKey("Error"))
                    ViewBag.Error = TempData["Error"];

                return View(i);
            }
            catch (Exception ex) 
            {
                ViewBag.Error = ex.Message; 
                return View(); 
            }
        }

        // POST: GaranteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            Garante g = null;

            try
            {
                g = repositorio.ObtenerPorId(id);

                g.Nombre = collection["Nombre"];
                g.Apellido = collection["Apellido"];
                g.Trabajo = collection["Trabajo"];
                g.Dni = collection["Dni"];
                g.Telefono = collection["Telefono"];
                g.Email = collection["Email"];
               
                repositorio.Modificacion(g);
                TempData["Mensaje"] = "Datos guardados correctamente del Inquilino: " + id;
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex) 
            {
                ViewBag.Error = ex.Message; 
                return View(g); 
            }

        }

        // GET: GaranteController/Delete/5
        [Authorize(Policy = "Administrador")]
        public ActionResult Delete(int id)
        {
            try
            {
                var g = repositorio.ObtenerPorId(id);

                if (TempData.ContainsKey("Mensaje"))
                    ViewBag.Mensaje = TempData["Mensaje"];
                if (TempData.ContainsKey("Error"))
                    ViewBag.Error = TempData["Error"];
                return View(g);
            }
            catch (Exception ex) 
            { 
                ViewBag.Error = ex.Message; 
                return View(); 
            }
        }

        // POST: GaranteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Administrador")]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                repositorio.Baja(id);
                TempData["Mensaje"] = "Eliminación realizada correctamente del id: " + id;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Mensaje"] = "Pueden existir contratos con el Garante. Borre primero los contratos";
                ViewBag.Error = ex.Message;
                ViewBag.StackTrate = ex.StackTrace;
                return View();
            }
        }
    }
}
