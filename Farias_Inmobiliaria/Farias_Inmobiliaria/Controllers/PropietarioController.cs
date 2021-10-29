using Farias_Inmobiliaria.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace Farias_Inmobiliaria.Controllers
{
    [Authorize]
    public class PropietarioController : Controller
    {
        private readonly IConfiguration configuration;
        RepositorioPropietario repositorio;

        public PropietarioController(IConfiguration configuration)
        {
            this.configuration = configuration;
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
            catch (Exception ex) 
            { 
                ViewBag.Error = ex.Message; 
                return View(); 
            }
        }

        // GET: PropietarioController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                Propietario P = repositorio.ObtenerPorId(id);
                return View(P);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(); 
            }
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
                    var salt = System.Text.Encoding.ASCII.GetBytes(configuration["Salt"]); /// Busca la sal en configuration

                    // Hasheo el pass
                    string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                        password: p.Password,
                        salt: salt,
                        prf: KeyDerivationPrf.HMACSHA1,
                        iterationCount: 1000,
                        numBytesRequested: 256 / 8));

                    p.Password = hashed;
                    
                    //
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
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(p);
            }
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
            catch (Exception ex) 
            {
                ViewBag.Error = ex.Message;
                return View();
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
                TempData["Mensaje"] = "Datos guardados correctamente del Propietario: " + id;
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message; 
                return View(p);
            }
        }

        public ActionResult EditPassword(int id)
        {
            try
            {
                Propietario propietario = repositorio.ObtenerPorId(id);

                return PartialView("_EditPassword",propietario);
            }
            catch (Exception ex)
            {


                ViewBag.Error = ex.Message;
                return View();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult EditPasswordPost(Propietario propietario)
        {
            if (true)   //ModelState.isvalid
            {
                try
                {
                    var nuevaClave = propietario.Password;

                    Propietario aModificar = repositorio.ObtenerPorId(propietario.IdPropietario);

                    if (!User.IsInRole("Administrador"))//no soy admin
                    {
                        TempData["mensaje"] = "Solo puede ver su perfil. No tiene privilegios para realizar modificaciones. Consulte con el administrador";
                        return RedirectToAction("Index");

                    }


                    if (nuevaClave != null && propietario.IdPropietario > 0)
                    {

                        var salt = System.Text.Encoding.ASCII.GetBytes(configuration["Salt"]); /// Busca la sal en configuration

                        // Hasheo el pass
                        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                            password: nuevaClave,
                            salt: salt,
                            prf: KeyDerivationPrf.HMACSHA1,
                            iterationCount: 1000,
                            numBytesRequested: 256 / 8));

                        propietario.Password = hashed;

                        int res = repositorio.ModificacionPassword(propietario);
                        propietario = repositorio.ObtenerPorId(propietario.IdPropietario);

                        if (res != -1)
                        {
                            TempData["Mensaje"] = "Datos de la nueva contraseña guardados correctamente del Usuario: " + propietario.IdPropietario;

                            return RedirectToAction("Index");
                        }
                        else
                        {
                            TempData["error"] = "Ocurrrio un error al guardar";
                            return RedirectToAction("Index");
                        }


                    }
                    else
                    {
                        TempData["Mensaje"] = "No se elegio una nueva contraseña para: " + propietario.IdPropietario;

                        return RedirectToAction("Index");
                    }




                }

                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                    return RedirectToAction("Index");
                }
            }
            else
            {
                TempData["Mensaje"] = "La contraseña ingresada no cumple con los requisitos minimos: " + propietario.IdPropietario;

                return RedirectToAction("Index");
            }


        }



        // GET: PropietarioController/Delete/5
        [Authorize(Policy = "Administrador")]

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
                ViewBag.Error = ex.Message; 
                return View();
            }
        }

        // POST: PropietarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Administrador")]

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
                TempData["Mensaje"] = "Pueden existir propiedades del Propietario. Borre primero las propiedades";
                ViewBag.Error = ex.Message;
                ViewBag.StackTrate = ex.StackTrace;
                return View();
            }

        }
    }
}
