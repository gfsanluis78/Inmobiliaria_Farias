using Farias_Inmobiliaria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace Farias_Inmobiliaria.Controllers
{
    public class InmuebleController : Controller
    {
        private readonly RepositorioInmueble repositorio;
        private readonly RepositorioPropietario repositorioPropietario;

        public InmuebleController(IConfiguration configuration)
        {
            this.repositorio = new RepositorioInmueble(configuration);
            this.repositorioPropietario = new RepositorioPropietario(configuration);

        }

        // GET: InmuebleController
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
                return View();
            }
        }

        // GET: InmuebleController/Details/5//   
        public ActionResult Details(int id)
        {
            try
            {
                Inmueble inmueble = repositorio.ObtenerPorId(id);
                return View(inmueble);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: InmuebleController/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.Propietarios = repositorioPropietario.ObtenerTodos();
                return View();
            }
            catch (Exception ex)
            {


                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // POST: InmuebleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Inmueble i)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    repositorio.Alta(i);
                    TempData["Id"] = i.IdInmueble;
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Propietarios = repositorioPropietario.ObtenerTodos();
                    return View(i);

                }


            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(i);
            }
        }

        // GET: InmuebleController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var inmueble = repositorio.ObtenerPorId(id);

                ViewBag.Propietarios = repositorioPropietario.ObtenerTodos();
                if (TempData.ContainsKey("Mensaje"))
                    ViewBag.Mensaje = TempData["Mensaje"];
                if (TempData.ContainsKey("Error"))
                    ViewBag.Error = TempData["Error"];

                return View(inmueble);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // POST: InmuebleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Inmueble i)
        {
            try
            {
                i.IdInmueble = id;
                repositorio.Modificacion(i);
                TempData["Mensaje"] = "Datos Guardados correctamente";
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                ViewBag.Propietarios = repositorioPropietario.ObtenerTodos();
                ViewBag.Error = ex.Message; return View(i);
            }
        }


        // GET: InmuebleController/Delete/5
        public ActionResult Delete(int id)

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
                ViewBag.Error = ex.Message; return View();
            }
        }

        // POST: Inmueble/Eliminar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Inmueble i)
        {
            try
            {
                repositorio.Baja(id);
                TempData["Mensaje"] = "Eliminación realizada correctamente";
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

