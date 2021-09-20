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

        // GET: PagoController
        public ActionResult IndexDeUnContrato(int id)
        {
            try
            {
                Contrato contrato = repositorioContrato.ObtenerPorId(id);
                ViewBag.desde = contrato;

                var lista = repositorio.ObtenerTodosDeUnContrato(contrato);

                if (lista.Count == 0)
                {
                    TempData["Mensaje"] = "El contrato " + contrato.IdContrato + " no tiene Pagos registrados. Puede crear el primero";
                }
                if (TempData.ContainsKey("Id"))
                    ViewBag.Id = TempData["Id"];
                if (TempData.ContainsKey("Mensaje"))
                    ViewBag.Mensaje = TempData["Mensaje"];
                //throw new Exception(); //Prueba de cacth
                return View("Index",lista);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Index");
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
                ViewBag.Pago = "solo";
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
                    p.Fecha = DateTime.Now;
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

        // Crear Pago modal

        // GET: PagoController/CreateModal
        public ActionResult CreateModal(int id)
        {
            try
            {
                Contrato contrato = repositorioContrato.ObtenerPorId(id);
                BusquedaSiguiente pagoSiguiente = repositorio.NumeroPagoSiguiente(contrato.IdContrato);
                Pago pago = new()
                {
                    NumeroPago = pagoSiguiente.NumeroSiguiente,
                    IdContrato = contrato.IdContrato,
                    Fecha = DateTime.Now,
                    Importe = contrato.MontoAlquiler
                };
                
                return PartialView("_CreateModal",pago);
            }
            catch (Exception ex)
            {


                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // POST: PagoController/CreateModal
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateModal(Pago p)
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
                ViewBag.Contratos = repositorioContrato.ObtenerTodos();
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
                var ultimo = repositorio.ObtenerElMayor(p.Contrato.IdContrato);
                ViewBag.ultimo = ultimo;


                if (ultimo != p.NumeroPago)
                {
                    ViewBag.Error = "No se puede Borrar " + id + ", Solo se puede Borrar el ultimo del contrato";
                }
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
                return Json(new { num = res.NumeroSiguiente, mon=res.Monto});
            }
            catch (Exception ex)
            {
                return Json(new { Error = ex.Message });
            }
        }

        // GET: Pago/numPagoSiguiente/idContrato
        [Route("[controller]/MontoPropuesto/{i}", Name = "MontoPropuesto")]
        public IActionResult MontoPropuesto(int i)
        {
            try
            {
                var res = repositorioContrato.ObtenerPorId(i);
                return Json(new { mon = res.MontoAlquiler});
            }
            catch (Exception ex)
            {
                return Json(new { Error = ex.Message });
            }
        }


        // Control borrado para no perder correlatividad

        // GET: Pago/numPagoSiguiente/idContrato
        [Route("[controller]/EsBorrable/{i}", Name = "EsBorrable")]
        public IActionResult EsBorrable(int i)
        {
            try
            {
                var res = repositorio.ObtenerElMayor(i);
                return Json(new { mon = res });
            }
            catch (Exception ex)
            {
                return Json(new { Error = ex.Message });
            }
        }
    }
}
