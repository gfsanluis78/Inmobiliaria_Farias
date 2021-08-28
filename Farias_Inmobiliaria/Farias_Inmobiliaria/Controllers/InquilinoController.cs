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
    public class InquilinoController : Controller
    {
        // inicio la variable el repositorio

        RepositorioInquilino repositorio;

        // Y hago un constructor para instanciarlo cuando se abre

        public InquilinoController(IConfiguration configuration)
        {
            repositorio = new RepositorioInquilino(configuration);
        }

        // GET: InquilinoController
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
            catch (Exception ex) { ViewBag.Error = ex.Message; return View(); }

        }

        // GET: InquilinoController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                Inquilino i = repositorio.ObtenerPorId(id);

                return View(i);
            }
            catch (Exception ex) { ViewBag.Error = ex.Message; return View(); }

        }

        // GET: InquilinoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InquilinoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Inquilino i)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repositorio.Alta(i);
                    TempData["Id"] = i.IdInquilino;
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["Mensaje"] = "Ocurrio un error con el modelo al Crear";
                    return View(i);
                }
            }
            catch (Exception ex) { ViewBag.Error = ex.Message; return View(i); }
        }

        // GET: InquilinoController/Edit/5
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
            catch (Exception ex) { ViewBag.Error = ex.Message; return View(); }
        }

        // POST: InquilinoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            Inquilino i = null;

            try
            {
                i = repositorio.ObtenerPorId(id);

                i.Nombre = collection["Nombre"];
                i.Apellido = collection["Apellido"];
                i.Dni = collection["Dni"];
                i.Telefono = collection["Telefono"];
                i.Email = collection["Email"];
                //p.Password = collection["Password"];

                repositorio.Modificacion(i);
                TempData["Mensaje"] = "Datos guardados correctamente del Inquilino: " + id;
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex) { ViewBag.Error = ex.Message; return View(i); }

        }

        // GET: InquilinoController/Delete/5
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
            catch (Exception ex) { ViewBag.Error = ex.Message; return View(); }
        }

        // POST: InquilinoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                repositorio.Baja(id);
                TempData["Mensaje"] = "Eliminación realizada correctamente: "+id;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Mensaje"] = "Pueden existir contratos del Inquilino. Borre primero los contratos";
                ViewBag.Error = ex.Message;
                ViewBag.StackTrate = ex.StackTrace;
                return View();
            }
        }
    }
}
