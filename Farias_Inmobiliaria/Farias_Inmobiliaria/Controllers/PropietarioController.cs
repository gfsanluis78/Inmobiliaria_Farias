using Farias_Inmobiliaria.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace Farias_Inmobiliaria.Controllers
{
    public class PropietarioController : Controller
    {
        RepositorioPropietario repositorio;

        public PropietarioController(IConfiguration configuration)
        {
            repositorio = new RepositorioPropietario(configuration);
        }

        // GET: PropietarioController
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

        // GET: PropietarioController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                Propietario P = repositorio.ObtenerPorId(id);
                return View(P);
            }
            catch (Exception ex) { ViewBag.Error = ex.Message; return View(); }
        }

        // GET: PropietarioController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: PropietarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Propietario p)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repositorio.Alta(p);
                    TempData["Id"] = p.IdPropietario;
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["Mensaje"] = "Ocurrio un error con el modelo al Crear";
                    return View(p);
                }
            }
            catch (Exception ex) { ViewBag.Error = ex.Message; return View(p); }
        }

        // GET: PropietarioController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var p = repositorio.ObtenerPorId(id);

                if (TempData.ContainsKey("Mensaje"))
                    ViewBag.Mensaje = TempData["Mensaje"];
                if (TempData.ContainsKey("Error"))
                    ViewBag.Error = TempData["Error"];

                return View(p);
            }
            catch (Exception ex) { ViewBag.Error = ex.Message; return View(); }

        }

        // POST: PropietarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            Propietario p = null;
            try
            {
                p = repositorio.ObtenerPorId(id);

                p.Nombre = collection["Nombre"];
                p.Apellido = collection["Apellido"];
                p.Dni = collection["Dni"];
                p.Telefono = collection["Telefono"];
                p.Email = collection["Email"];
                //p.Password = collection["Password"];

                repositorio.Modificacion(p);
                TempData["Mensaje"] = "Datos guardados correctamente del Propietario " + id;
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex) { ViewBag.Error = ex.Message; return View(p); }
        }

        // GET: PropietarioController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var p = repositorio.ObtenerPorId(id);

                if (TempData.ContainsKey("Mensaje"))
                    ViewBag.Mensaje = TempData["Mensaje"];
                if (TempData.ContainsKey("Error"))
                    ViewBag.Error = TempData["Error"];
                return View(p);
            }
            catch (Exception ex) { ViewBag.Error = ex.Message; return View(); }
        }

        // POST: PropietarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                repositorio.Baja(id);
                TempData["Mensaje"] = "Eliminación realizada correctamente";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Mensaje"] = "Pueden existir propiedades del Propietario. Borre primero las propiedades";
                ViewBag.Error = ex.Message;
                ViewBag.StackTrate = ex.StackTrace;
                return View();
            }

        }
    }
}
