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
    public class InquilinosController : ControllerBase
    {

        private readonly DataContext contexto;

        public InquilinosController(DataContext contexto)
        {
            this.contexto = contexto;
        }


        // GET api/Inquilinos/                                  // OK
        [HttpPost]
        public async Task<IActionResult> Get([FromBody] Inmueble inmueble)
        {
            try
            {
                var usuario = User.Identity.Name;
                var hoy = DateTime.Now;

                var query = from cont  in contexto.Contratos
                            join inmueb in contexto.Inmuebles
                                on cont.IdInmueble equals inmueb.IdInmueble
                            join inquilino in contexto.Inquilinos
                                on cont.IdInquilino equals inquilino.IdInquilino
                            where cont.FechaInicio <= hoy
                                    && cont.FechaFin >= hoy
                                    && inmueb.IdInmueble == inmueble.IdInmueble
                            select inquilino;

                return Ok(query);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        // GET: api/Inquilinos/GetInquilinos/Todos                       // 
        [HttpGet("Todos")]
        public async Task<IActionResult> GetInquilinos()
        {
            try
            {
                var usuario = User.Identity.Name;
                var hoy = DateTime.Now;

                var query = from inmueb in contexto.Inmuebles
                            join cont in contexto.Contratos
                                on inmueb.IdInmueble equals cont.IdInmueble
                            join inquilino in contexto.Inquilinos
                                on cont.IdInquilino equals inquilino.IdInquilino
                            where cont.FechaInicio <= hoy && cont.FechaFin >= hoy && usuario == inmueb.Duenio.Email
                            select inquilino;

                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        
        //// POST api/<InquilinosController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<InquilinosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InquilinosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
