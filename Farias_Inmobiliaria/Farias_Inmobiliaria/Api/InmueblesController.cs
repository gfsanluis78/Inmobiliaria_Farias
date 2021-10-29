using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Inmobiliaria_.Net_Core.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Farias_Inmobiliaria.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inmobiliaria_.Net_Core.Api
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class InmueblesController : Controller 
    {
        private readonly DataContext contexto;
        private readonly IWebHostEnvironment environment;

        public InmueblesController(DataContext contexto, IWebHostEnvironment environment
)
        {
            this.contexto = contexto;
            this.environment = environment;
        }

        // GET: api/Inmuebles                               // Ok
        [HttpGet]
        public async Task<IActionResult> GetMisInmuebles()
        {
            try
            {
                var usuario = User.Identity.Name;
                return Ok(contexto.Inmuebles.Include(e => e.Duenio).Where(e => e.Duenio.Email == usuario));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Inmuebles/Alquilados                     // Ok alquilados vigentes
        [HttpGet("Alquilados")]
        public async Task<IActionResult> GetMisInmueblesAlquilados()
        {
            try
            {
                var usuario = User.Identity.Name;
                var hoy = DateTime.Now;

                var query = from inmueb in contexto.Inmuebles
                            join cont in contexto.Contratos
                                on inmueb.IdInmueble equals cont.IdInmueble
                            //join prop in contexto.Propietarios
                            //    on inmueb.Duenio.IdPropietario equals usuario
                            where cont.FechaInicio <= hoy && cont.FechaFin >= hoy && usuario == inmueb.Duenio.Email
                            select inmueb;



                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/Inmuebles/5                              //  Ok
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInmueble(int id)
        {
            try
            {
                var usuario = User.Identity.Name;
                return Ok(contexto.Inmuebles.Include(e => e.Duenio).Where(e => e.Duenio.Email == usuario).Single(e => e.IdInmueble == id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<controller>                            // Ok
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Inmueble entidad)
        {
            try
            {
                var direccion = entidad.Direccion;
                var duenioId = User.Identity.Name;

                if (entidad.Imagen.Length > 0)
                {
                    if (ModelState.IsValid)
                    {
                        entidad.IdPropietario = contexto.Propietarios.Single(e => e.Email == User.Identity.Name).IdPropietario;

                        // Guardo la imagen en el servidor
                        //var fileName = CambiarNombre();
                        //var folder = "wwwroot\\NewFolder1\\" + duenioId + "_" + direccion + "\\";
                        //var filePath = Path.Combine(folder, fileName);

                        // 
                        var stream1 = new MemoryStream(Convert.FromBase64String(entidad.Imagen));
                        IFormFile ImagenInmo = new FormFile(stream1, 0, stream1.Length, "inmueble", ".jpg");
                        string wwwPath = environment.WebRootPath;
                        string path = Path.Combine(wwwPath, "NewFolder1");
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        Random r = new Random();
                        //Path.GetFileName(u.AvatarFile.FileName);//este nombre se puede repetir
                        string fileName = CambiarNombre((int) entidad.IdPropietario);          // "inmueble_" + entidad.IdPropietario + r.Next(0, 100000) + Path.GetExtension(ImagenInmo.FileName);
                        string pathCompleto = Path.Combine(path, fileName);

                        entidad.Imagen = Path.Combine("/NewFolder1", fileName);
                        using (FileStream stream = new FileStream(pathCompleto, FileMode.Create))
                        {
                                ImagenInmo.CopyTo(stream);
                         }
                            //contexto.Add(entidad);
                            //await contexto.SaveChangesAsync();
                            //return entidad;

                            contexto.Inmuebles.Add(entidad);
                            contexto.SaveChanges();
                            return CreatedAtAction(nameof(GetInmueble), new { id = entidad.IdInmueble }, entidad);
                          
                    }
                    return BadRequest(ModelState);
                }
                return BadRequest(Ok("Falta imagen"));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<controller>/5                           // Ok
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Inmueble entidad)
        {
            try
            {
                if (ModelState.IsValid && contexto.Inmuebles.AsNoTracking().Include(e=>e.Duenio).FirstOrDefault(e => e.IdInmueble == id && e.Duenio.Email == User.Identity.Name) != null)
                {
                    entidad.IdPropietario = contexto.Propietarios.Single(e => e.Email == User.Identity.Name).IdPropietario;
                    entidad.Duenio = contexto.Propietarios.Single(e => e.Email == User.Identity.Name);
                    entidad.IdInmueble = id;
                    contexto.Inmuebles.Update(entidad);
                    contexto.SaveChanges();
                    return Ok(entidad);
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<controller>/5                        // Ok
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var entidad = contexto.Inmuebles.Include(e => e.Duenio).FirstOrDefault(e => e.IdInmueble == id && e.Duenio.Email == User.Identity.Name);
                if (entidad != null)
                {
                    contexto.Inmuebles.Remove(entidad);
                    contexto.SaveChanges();
                    return Ok("Entidad " + id + " Borrada");
                } 
                return BadRequest("La entidad con el id " + id + " es Nula!!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
		}

        // Patch api/Inmuebles/CambioEstado/5                // Ok
        [HttpPatch("CambioEstado")]
		public async Task<IActionResult> CambioEstado([FromBody]Inmueble inmueble)
		{
			try
			{
				var entidad = contexto.Inmuebles.Include(e => e.Duenio).FirstOrDefault(e => e.IdInmueble == inmueble.IdInmueble && e.Duenio.Email == User.Identity.Name);
				if (entidad != null)
				{
                    entidad.Disponibilidad = !entidad.Disponibilidad; //-1;//cambiar por estado = 0
					contexto.Inmuebles.Update(entidad);
					contexto.SaveChanges();
					return Ok(entidad);
				}
				return BadRequest("La entidad " + inmueble.IdInmueble + " no existe");
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

        // Patch api/Inmuebles/Altalogica/5                // Ok
        [HttpPatch("AltaLogica/{id}")]
        public async Task<IActionResult> AltaLogica(int id)
        {
            try
            {
                var entidad = contexto.Inmuebles.Include(e => e.Duenio).FirstOrDefault(e => e.IdInmueble == id && e.Duenio.Email == User.Identity.Name);
                if (entidad != null)
                {
                    entidad.Disponibilidad = true; //-1;//cambiar por estado = 0
                    contexto.Inmuebles.Update(entidad);
                    contexto.SaveChanges();
                    return Ok(id + " pasado a disponibilidad True");
                }
                return BadRequest("La entidad " + id + " no existe");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        //################################################################
        //    Metodo para generar un nombre al azar para las imagenes
        //################################################################
        private string CambiarNombre(int id)
        {
            //caracteres para el nombre nuevo
            string chars = "23456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            //crean un generador al azar
            Random rnd = new Random();
            string name = string.Empty;
            while (name.Length < 8)
            {
                name += chars.Substring(rnd.Next(chars.Length), 1);
            }
            //agregamos un prefijo al nombre generado al azar y la extension del mismo
            name = "inmb_"+ id + "_" + name + ".jpg";
            return name;
        }

        private string Conversor(string Path)
        {
            byte[] imageArray = System.IO.File.ReadAllBytes(Path);
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);
            return base64ImageRepresentation;
        }
    }


  



}

