using Farias_Inmobiliaria.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace Farias_Inmobiliaria.Controllers
{
    [Authorize]
    public class InmuebleController : Controller
    {
        private readonly RepositorioInmueble repositorio;
        private readonly RepositorioPropietario repositorioPropietario;
        private readonly RepositorioContrato repositorioContrato;

        public InmuebleController(IConfiguration configuration)
        {
            this.repositorio = new RepositorioInmueble(configuration);
            this.repositorioPropietario = new RepositorioPropietario(configuration);
            this.repositorioContrato = new RepositorioContrato(configuration);
        }

        // GET: InmuebleController
        public ActionResult Index()
        {
            try
            {

                var listaContratos = repositorioContrato.ObtenerTodos();
                var lista = repositorio.ObtenerTodos();
                ViewBag.listaContratos = listaContratos;
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

        public ActionResult IndexConContrato()
        {
            try
            {

                var listaContratos = repositorioContrato.ObtenerUltimosContrato();
                var lista = repositorio.ObtenerTodos();
                Boolean soloContratos = true;
                ViewBag.contratos = listaContratos;
                ViewBag.soloContratos = "soloContratos";
                if (TempData.ContainsKey("Id"))
                    ViewBag.Id = TempData["Id"];
                if (TempData.ContainsKey("Mensaje"))
                    ViewBag.Mensaje = TempData["Mensaje"];
                
                ////throw new Exception(); //Prueba de cacth
                return View(lista);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // get levanta modal fechas
        public ActionResult ModalFechas()
        {
            try
            {
                return PartialView("_ModalFechas");
            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                return PartialView("_ModalFechas");
            }
            
        }



        // get inmubles disponible entre fechas
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IndexDisponiblesEntreFechas(BuscarEntreFecha buscar)
        {
            try
            {
                
                var lista = repositorio.ObtenerDisponiblesPorFecha(buscar);
                ViewBag.fechas = buscar;
                
                if (TempData.ContainsKey("Id"))
                    ViewBag.Id = TempData["Id"];
                if (TempData.ContainsKey("Mensaje"))
                    ViewBag.Mensaje = TempData["Mensaje"];

                ////throw new Exception(); //Prueba de cacth
                return View(lista);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return RedirectToAction("Index");
            }
        }


        // GET: Inmueble/BusquedaTodos/1
        [Route("[controller]/BusquedaTodos/{propietario}", Name = "BusquedaTodos")]
        public ActionResult BusquedaTodos(int propietario)
        {
            try
            {
                Propietario prop = repositorioPropietario.ObtenerPorId(propietario);
                var lista = repositorio.ObtenerTodosPorId(propietario);
                if (TempData.ContainsKey("Id"))
                    ViewBag.Id = TempData["Id"];
                if (TempData.ContainsKey("Mensaje"))
                    ViewBag.Mensaje = TempData["Mensaje"];
                ViewBag.propietario = prop;
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
                var url = Request.Headers["referer"].FirstOrDefault();
                TempData["url"] = url;
                ViewBag.url = url;
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
                var urlAnterior = "";

                i.IdInmueble = id;
                repositorio.Modificacion(i);
                TempData["Mensaje"] = "Datos Guardados correctamente";

                if (TempData.ContainsKey("url"))
                    urlAnterior = TempData["url"].ToString();
                ViewBag.url = urlAnterior;
                           

                if (string.IsNullOrEmpty(urlAnterior))
                {
                    return RedirectToAction(nameof(Index));
                }

                return Redirect(urlAnterior);

            }
            catch (Exception ex)
            {
                ViewBag.Propietarios = repositorioPropietario.ObtenerTodos();
                ViewBag.Error = ex.Message; return View(i);
            }
        }


        // GET: InmuebleController/Delete/5
        [Authorize(Policy = "Administrador")]
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
        [Authorize(Policy = "Administrador")]
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

