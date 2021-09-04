using Farias_Inmobiliaria.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farias_Inmobiliaria.Controllers
{
    public class ContratoController : Controller
    {
        private readonly RepositorioContrato repositorio;

        private readonly RepositorioGarante repositorioGarante;
        private readonly RepositorioInmueble repositorioInmueble;
        private readonly RepositorioInquilino repositorioInquilino;

        public ContratoController(IConfiguration configuration)
        {
            this.repositorio = new RepositorioContrato(configuration);
            
            this.repositorioGarante = new RepositorioGarante(configuration);
            this.repositorioInmueble = new RepositorioInmueble(configuration);
            this.repositorioInquilino = new RepositorioInquilino(configuration);
        }

        // GET: ContratoController
        public ActionResult Index()
        {
            try
            {
                ViewBag.Garantes = repositorioGarante.ObtenerTodos();
                ViewBag.Inmuebles = repositorioInmueble.ObtenerTodos();
                ViewBag.Inquilinos = repositorioInquilino.ObtenerTodos();
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
                return View(); 
            }
        }

        // GET: ContratoController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                Contrato contrato = repositorio.ObtenerPorId(id);
                return View(contrato);
            }
            catch (Exception ex) 
            {
                ViewBag.Error = ex.Message;
                if (TempData.ContainsKey("Id"))
                    ViewBag.Id = TempData["Id"];
                if (TempData.ContainsKey("Mensaje"))
                    ViewBag.Mensaje = TempData["Mensaje"];
                return View();
            }
        }

        // GET: ContratoController/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.Garantes = repositorioGarante.ObtenerTodos();
                ViewBag.Inmuebles = repositorioInmueble.ObtenerTodos();
                ViewBag.Inquilinos = repositorioInquilino.ObtenerTodos();
                return View();
            }
            catch (Exception ex) 
            { 
                ViewBag.Error = ex.Message; 
                return View();
            }
        }

        // POST: ContratoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contrato c)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    repositorio.Alta(c);
                    TempData["Id"] = c.IdContrato;
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Garantes = repositorioGarante.ObtenerTodos();
                    ViewBag.Inmuebles = repositorioInmueble.ObtenerTodos();
                    ViewBag.Inquilinos = repositorioInquilino.ObtenerTodos();
                    return View(c);

                }


            }
            catch (Exception ex) 
            { 
                ViewBag.Error = ex.Message; 
                return View(c); }
        }

        // GET: ContratoController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var contrato = repositorio.ObtenerPorId(id);

                ViewBag.Garantes = repositorioGarante.ObtenerTodos();
                ViewBag.Inmuebles = repositorioInmueble.ObtenerTodos();
                ViewBag.Inquilinos = repositorioInquilino.ObtenerTodos();
                if (TempData.ContainsKey("Mensaje"))
                    ViewBag.Mensaje = TempData["Mensaje"];
                if (TempData.ContainsKey("Error"))
                    ViewBag.Error = TempData["Error"];

                return View(contrato);
            }
            catch (Exception ex) 
            { 
                ViewBag.Error = ex.Message; 
                return RedirectToAction(nameof(Index)) ; 
            }
        }

        // POST: ContratoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Contrato c)
        {
            try
            {
                c.IdContrato = id;
                int result = repositorio.Modificacion(c);
                if (result>0)
                {
                    TempData["Mensaje"] = "Datos Guardados correctamente";
                    return RedirectToAction(nameof(Index));

                } else if(result==0)
                {
                    TempData["Mensaje"] = "Se impacto en la base de datos pero no afecto a ninguna fila";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["Mensaje"] = "No se lograron guardar las modificaiones";
                    return RedirectToAction(nameof(Index));
                }


            }
            catch (Exception ex)
            {
                ViewBag.Garantes = repositorioGarante.ObtenerTodos();
                ViewBag.Inmuebles = repositorioInmueble.ObtenerTodos();
                ViewBag.Inquilino = repositorioInquilino.ObtenerTodos();
                ViewBag.Error = ex.Message; return View(c);
            }
        }

        // GET: ContratoController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                ViewBag.Garantes = repositorioGarante.ObtenerTodos();
                ViewBag.Inmuebles = repositorioInmueble.ObtenerTodos();
                ViewBag.Inquilinos = repositorioInquilino.ObtenerTodos();
                var c = repositorio.ObtenerPorId(id);
                if (TempData.ContainsKey("Mensaje"))
                    ViewBag.Mensaje = TempData["Mensaje"];
                if (TempData.ContainsKey("Error"))
                    ViewBag.Error = TempData["Error"];
                return View(c);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message; return View();
            }
        }

        // POST: ContratoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Contrato contrato)
        {
            try
            {
                repositorio.Baja(id);
                TempData["Mensaje"] = "Eliminación realizada correctamente del id: "+id;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.StackTrate = ex.StackTrace;
                return View();
            }
        }
    }
}
