using Farias_Inmobiliaria.Models;
using Inmobiliaria_.Net_Core.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Farias_Inmobiliaria.Api
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ContratosController : ControllerBase
    {
        // Se agrega el DataContect
        private readonly DataContext contexto;

        // Y el constructor
        public ContratosController(DataContext contexto)
        {
            this.contexto = contexto;
        }

        // GET: api/<ContratosController>/Vigentes          // OK
        [HttpGet("Vigentes")]
        public async Task<IActionResult> GetVigentes()
        {
            try
            {
                var usuario = User.Identity.Name;
                var hoy = DateTime.Now;

                return Ok(contexto.Contratos
                    .Include(c => c.Inquilino)
                    .Include(c => c.Garante)
                    .Include(c => c.Inmueble)
                    .Where(c => c.Inmueble.Duenio.Email == usuario && c.FechaInicio <= hoy && c.FechaFin >= hoy));               }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ContratosController>                 //
        [HttpPost]
        public async Task<IActionResult> Get([FromBody] Inmueble inmueble)
        {
            try
            {
                var usuario = User.Identity.Name;
                var hoy = DateTime.Now;

                var contrato = contexto.Contratos
                        .Include(c => c.Inmueble.Duenio)
                        .Include(c=> c.Garante)
                        .Include(c=> c.Inquilino)
                        .Where(c => c.Inmueble.Duenio.Email == usuario
                        && c.FechaInicio <= hoy && c.FechaFin >= hoy)
                        //&& c.IdInmueble == inmueble.IdInmueble)
                        .SingleOrDefault(c => c.Inmueble.IdInmueble == inmueble.IdInmueble);

                return Ok(contrato);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ContratosController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<ContratosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ContratosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
