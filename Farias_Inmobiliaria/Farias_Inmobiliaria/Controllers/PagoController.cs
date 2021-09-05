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
    public class PagoController : Controller
    {
        private readonly RepositorioPago repositorio;
        private readonly RepositorioContrato repositorioContrato;

        public PagoController(IConfiguration configuration)
        {
            this.repositorio = new RepositorioPago(configuration);
            this.repositorioContrato = new RepositorioContrato(configuration);

        }

        // GET: PagoController
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

        // GET: PagoController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                Pago pago = repositorio.ObtenerPorId(id);
                return View(pago);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: PagoController/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.Contratos = repositorioContrato.ObtenerTodos();
                return View();
            }
            catch (Exception ex)
            {


                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // POST: PagoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pago p)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    repositorio.Alta(p);
                    TempData["Id"] = p.IdPago;
                    return RedirectToAction(nameof(Index));
                }
                else
                {

                    ViewBag.Contratos = repositorioContrato.ObtenerTodos();
                    return View();

                }


            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }

        }

        // GET: PagoController/Edit/5
            public ActionResult Edit(int id)
        {
            try
            {
                var pago = repositorio.ObtenerPorId(id);
                
                if (TempData.ContainsKey("Mensaje"))
                    ViewBag.Mensaje = TempData["Mensaje"];
                if (TempData.ContainsKey("Error"))
                    ViewBag.Error = TempData["Error"];

                return View(pago);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // POST: PagoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Pago p)
        {
            try
            {
                p.IdPago = id;
                repositorio.Modificacion(p);
                TempData["Mensaje"] = "Datos Guardados correctamente";
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message; return View(p);
            }
        }

        // GET: PagoController/Delete/5
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
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message; return View();
            }
        }

        // POST: PagoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Pago p)
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

        // GET: Pago/numPagoSiguiente/idContrato
        [Route("[controller]/NumPagoSiguiente/{i}", Name = "NumPagoSiguiente")]
        public IActionResult NumPagoSiguiente(int i)
        {
            try
            {
                var res = repositorio.NumeroPagoSiguiente(i);
                return Json(new { num = res });
            }
            catch (Exception ex)
            {
                return Json(new { Error = ex.Message });
            }
        }
    }
}
