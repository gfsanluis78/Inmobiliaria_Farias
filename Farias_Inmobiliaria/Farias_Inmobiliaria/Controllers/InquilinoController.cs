using Farias_Inmobiliaria.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public InquilinoController()
        {
            repositorio = new RepositorioInquilino();
        }

        // GET: InquilinoController
        public ActionResult Index()
        {
            var lista = repositorio.ObtenerTodos();
            return View(lista);
        }

        // GET: InquilinoController/Details/5
        public ActionResult Details(int id)
        {
            Inquilino inquilino = repositorio.ObtenerPorId(id);
            return View(inquilino);
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
                repositorio.Alta(i);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InquilinoController/Edit/5
        public ActionResult Edit(int id)
        {
            try {
                var inquilino = repositorio.ObtenerPorId(id);
                return View(inquilino);
            } catch (Exception ex)
            {//poner breakpoints para detectar errores
                throw;
            }

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

                repositorio.Modificacion(i);
                TempData["Mensaje"] = "Datos guardados correctamente";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {//poner breakpoints para detectar errores
                throw;
            };
            
        }

        // GET: InquilinoController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var inquilino = repositorio.ObtenerPorId(id);
                return View(inquilino);
            }
            catch (Exception ex)
            {//poner breakpoints para detectar errores
                throw;
            }
        }

        // POST: InquilinoController/Delete/5
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
