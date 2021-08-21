using Farias_Inmobiliaria.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farias_Inmobiliaria.Controllers
{
    public class PropietarioController : Controller
    {
        RepositorioPropietario repositorio;

        public PropietarioController()
        {
            repositorio = new RepositorioPropietario();
        }

        // GET: PropietarioController
        public ActionResult Index()
        {
            var lista = repositorio.ObtenerTodos();
            return View(lista);
        }

        // GET: PropietarioController/Details/5
        public ActionResult Details(int id)
        {
            Propietario propietario = repositorio.ObtenerPorId(id);
            return View(propietario);
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
                repositorio.Alta(p);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                TempData["Mensaje"] = "Ocurrio un error al querer Crear";
                return View();
            }
        }

        // GET: PropietarioController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var propietario = repositorio.ObtenerPorId(id);
                return View(propietario);
            }
            catch (Exception ex)
            {

                throw;
            }
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
                TempData["Mensaje"] = "Datos guardados correctamente";
                return RedirectToAction(nameof(Index));
            
            }
            catch(Exception exception)
            {
                TempData["Mensaje"] = "Ocurrio un error al querer editar";
                throw;
            }
        }

        // GET: PropietarioController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var propietario = repositorio.ObtenerPorId(id);
                return View(propietario);
            }
            catch (Exception ex)
            {

                throw;
            }
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
            catch
            {

                TempData["Mensaje"] = "Ocurrio un error al querer eliminar";
                return View();
            }
        }
    }
}
