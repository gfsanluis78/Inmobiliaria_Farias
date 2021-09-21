using Farias_Inmobiliaria.Models;
using Microsoft.AspNetCore.Authorization;
//using Google.Type;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;


namespace Farias_Inmobiliaria.Controllers
{
    [Authorize]
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

        // GET: ContratoController
        public ActionResult IndexSoloVigentes()
        {
            try
            {
                ViewBag.Garantes = repositorioGarante.ObtenerTodos();
                ViewBag.Inmuebles = repositorioInmueble.ObtenerTodos();
                ViewBag.Inquilinos = repositorioInquilino.ObtenerTodos();
                ViewBag.Vigentes = "vigentes";
                var lista = repositorio.ObtenerTodosVigentes();
                if (TempData.ContainsKey("Id"))
                    ViewBag.Id = TempData["Id"];
                if (TempData.ContainsKey("Mensaje"))
                    ViewBag.Mensaje = TempData["Mensaje"];
                //throw new Exception(); //Prueba de cacth
                //return View(lista);
                return View("Index", lista);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: ContratoController
        [Route("[controller]/IndexUnInmueble/{inmueble}", Name = "IndexUnInmueble")]
        public ActionResult IndexUnInmueble(int inmueble)
        {
            try
            {
                Inmueble inmu = repositorioInmueble.ObtenerPorId(inmueble);


                ViewBag.Garantes = repositorioGarante.ObtenerTodos();
                ViewBag.Inmuebles = repositorioInmueble.ObtenerTodos();
                ViewBag.Inquilinos = repositorioInquilino.ObtenerTodos();
                ViewBag.inmueble = inmu;
                var lista = repositorio.ObtenerTodosDeUnInmueble(inmueble);
                if (TempData.ContainsKey("Id"))
                    ViewBag.Id = TempData["Id"];
                if (TempData.ContainsKey("Mensaje"))
                    ViewBag.Mensaje = TempData["Mensaje"];
                if (lista.Count == 0)
                {
                    TempData["Mensaje"] = "El inmueble " + inmu.IdInmueble + " no tiene Contratos";
                    return RedirectToAction(nameof(Index), "Inmueble");
                }


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
                BuscarEntreFecha buscar = new()
                {
                    Desde = (DateTime)c.FechaInicio,
                    Hasta = (DateTime)c.FechaFin
                };

                var hayContratos = repositorio.ObtenerPorfechasInm(buscar);

                if (!hayContratos)
                {
                    TempData["mensaje"] = "Existen contratos en esa fecha. Revise las disponibles";
                    ViewBag.Garantes = repositorioGarante.ObtenerTodos();
                    ViewBag.Inmuebles = repositorioInmueble.ObtenerTodos();
                    ViewBag.Inquilinos = repositorioInquilino.ObtenerTodos();
                    return View(c);
                }
                else
                {

                    if (true)
                    {
                        repositorio.Alta(c);
                        TempData["Id"] = c.IdContrato;
                        return RedirectToAction(nameof(Index));
                    }
               

                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(c);
            }
        }

        // GET: ContratoController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var contrato = repositorio.ObtenerPorId(id);
                if (contrato.EstadoCancelado)
                {
                    TempData["Mensaje"] = "No se puede editar un contrato Cancelado";
                    return RedirectToAction(nameof(Index));
                }
                else if (contrato.FechaFin < DateTime.Now)
                {
                    TempData["Mensaje"] = "No se puede editar un contrato Finalizado";
                    return RedirectToAction(nameof(Index));
                }

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
                return RedirectToAction(nameof(Index));
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
                if (result > 0)
                {
                    TempData["Mensaje"] = "Datos Guardados correctamente";
                    return RedirectToAction(nameof(Index));

                }
                else if (result == 0)
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


        // ##########################################
        // renovar contrato
        // ##########################################


        // GET: ContratoController/Edit/5
        public ActionResult Cancelar(int id)
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
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: ContratoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cancelar(int id, Contrato c)
        {
            try
            {
                c.IdContrato = id;
                int result = repositorio.Cancelar(c);
                if (result > 0)
                {
                    TempData["Mensaje"] = "Datos cancelado correctamente";
                    return RedirectToAction(nameof(Index));

                }
                else if (result == 0)
                {
                    TempData["Mensaje"] = "Se impacto en la base de datos pero no afecto a ninguna fila";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["Mensaje"] = "No se lograron guardar las modificaciones";
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

        [Authorize(Policy = "Administrador")]
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
        [Authorize(Policy = "Administrador")]
        public ActionResult Delete(int id, Contrato contrato)
        {
            try
            {
                repositorio.Baja(id);
                TempData["Mensaje"] = "Eliminación realizada correctamente del id: " + id;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.StackTrate = ex.StackTrace;
                return View();
            }
        }


        [Route("[controller]/tieneContrato/{idInmueble}", Name = "tieneContrato")]
        public IActionResult TieneContrato(int idInmueble)
        {
            try
            {
                var res = repositorio.obtenerPorInmueble(idInmueble);
                return Json(new { Datos = res });
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.StackTrate = ex.StackTrace;
                return View();
            }


        }

        // Get: Contrato/Renovar/1
        public ActionResult Renovar(int id)
        {
            try
            {
                var contrato = repositorio.ObtenerPorId(id);
                if (contrato.EstadoCancelado)
                {
                    TempData["Mensaje"] = "No se puede renovar un contrato Cancelado. Realice un contrato nuevo";
                    return RedirectToAction(nameof(Index));
                }
                else if (contrato.FechaFin < DateTime.Now)
                {
                    TempData["Mensaje"] = "No se puede renovar un contrato Finalizado. Realice un contrato nuevo";
                    return RedirectToAction(nameof(Index));
                }
                else if (contrato.FechaInicio > DateTime.Now)
                {
                    TempData["Mensaje"] = "Ya existe una Renovacion pendiente de inicio para este contrato";
                    return RedirectToAction(nameof(Index));
                }

                var fechaNuevaInicio = new DateTime();
                var fechaNuevaFin = new DateTime();

                fechaNuevaInicio = (DateTime)contrato.FechaFin;

                fechaNuevaInicio = fechaNuevaInicio.AddDays(1);
                fechaNuevaFin = fechaNuevaInicio.AddDays(365);

                contrato.FechaInicio = fechaNuevaInicio;
                contrato.FechaFin = fechaNuevaFin;



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
                return RedirectToAction(nameof(Index));
            }
        }

        // Post: Contrato/Renovar/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Renovar(Contrato c)
        {
            try
            {
                if (ModelState.IsValid)


                {
                    var i = repositorioInmueble.ObtenerPorId((int)c.IdInmueble);
                    var estaDisponible = i.Disponibilidad;

                    if (estaDisponible != true)
                    {
                        TempData["mensaje"] = "El inmueble no esta disponible para nuevos Contratos";
                        ViewBag.Garantes = repositorioGarante.ObtenerTodos();
                        ViewBag.Inmuebles = repositorioInmueble.ObtenerTodos();
                        ViewBag.Inquilinos = repositorioInquilino.ObtenerTodos();
                        return RedirectToAction(nameof(Index));
                    }

                    BuscarEntreFecha buscar = new()
                    {
                        Desde = (DateTime)c.FechaInicio,
                        Hasta = (DateTime)c.FechaFin,
                        Inmueble = (int)c.IdInmueble,
                    };

                    var lista = repositorio.ObtenerPorfechas(buscar);
                    var cant = lista.Count;

                    if (cant == 0)
                    {
                        repositorio.Alta(c);
                        TempData["Id"] = c.IdContrato;
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        var cantString = cant == 1 ? "contrato" : "contratos";
                        var existe_n = cant == 1 ? "Existe " : "Existen";


                        TempData["mensaje"] = existe_n + cant + " " + cantString + " para este inmueble entre las fechas seleccionadas. Revise las fechas disponibles";
                        ViewBag.Garantes = repositorioGarante.ObtenerTodos();
                        ViewBag.Inmuebles = repositorioInmueble.ObtenerTodos();
                        ViewBag.Inquilinos = repositorioInquilino.ObtenerTodos();
                        return RedirectToAction(nameof(Index));
                    }


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
                return View(c);
            }
        }
    }
}
