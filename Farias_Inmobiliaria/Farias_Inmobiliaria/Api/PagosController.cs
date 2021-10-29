using Farias_Inmobiliaria.Models;
using Inmobiliaria_.Net_Core.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Farias_Inmobiliaria.Api
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PagosController : ControllerBase
    {

        // Se agrega el DataContect
        private readonly DataContext contexto;

        // Y el constructor
        public PagosController(DataContext contexto)
        {
            this.contexto = contexto;
        }


        // GET https://localhost:44372/api/Pagos            // Ok
        [HttpPost]
        public async Task<IActionResult> Get([FromBody]  Contrato contrato)
        {
            try
            {
                var usuario = User.Identity.Name;
                var hoy = DateTime.Now;

                var query = contexto.Pagos.Where(p => p.IdContrato == contrato.IdContrato);
                return Ok(query);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        // GET api/<PagosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        //// POST api/<PagosController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<PagosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PagosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
