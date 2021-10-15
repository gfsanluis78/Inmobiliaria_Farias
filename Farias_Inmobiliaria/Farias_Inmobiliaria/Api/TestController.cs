﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Inmobiliaria_.Net_Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Farias_Inmobiliaria.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inmobiliaria_.Net_Core.Api
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestController : ControllerBase
	{
		private readonly DataContext Contexto;

		public TestController(DataContext dataContext)
		{
			this.Contexto = dataContext;
		}
		// GET: api/<controller>
		[HttpGet]
		public async Task<IActionResult> Get()			// Ok
		{
			try
			{
				return Ok(new
				{
					Mensaje = "Éxito",
					Error = 0,
					Resultado = new
					{
						Clave = "Key",
						Valor = new Random().Next(0, 10000)
					},
				});
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// GET api/<controller>/5 // string
		[HttpGet("propietario/{id=0}")]					// Ok
		public IActionResult Get(int id)
		{
			if (id > 0)
			{
				return Ok(Contexto.Propietarios.Find(id));
			}
			else
			{
				return Ok(Contexto.Propietarios.ToList());
			}
		}

		// GET api/Test/usuarios || api/Test/usuarios/1
		[HttpGet("usuarios/{id=0}")]					// Ok
		public IActionResult GetUsers(int id)
		{
            if (id>0)
            {
				return Ok(Contexto.Usuarios.Find(id));

			}
			else
            {
				return Ok(Contexto.Usuarios.ToList());
			}
		}

		// POST api/<controller>/usuario/5				// Ok
		[HttpPost("usuarios/{id}")]
		public Usuario Post([FromForm] Usuario usuario, int id)
		{
			usuario.Id = id;
			return usuario;
		}

		// GET api/<controller>/1						// Ok
		[HttpGet("emails/{id=0}")]
		public IActionResult Emails(int id)
		{
			if(id > 0)
				return Ok(Contexto.Propietarios.Where(x => x.IdPropietario == id).Select(x => x.Email).Single());
			else
				return Ok(Contexto.Propietarios.Select(x => x.Email).ToList());
		}

		// GET api/<controller>/5
		[HttpGet("anonimo/{id=0}")]
		public IActionResult GetAnonimo(int id)
		{
			return id > 0 ?
				Ok(Contexto.Propietarios.Where(x => x.IdPropietario == id)
				.Select(x => new { Id = x.IdPropietario, x.Email }).Single()) :
				Ok(Contexto.Propietarios.Select(x => new { Id = x.IdPropietario, x.Email }).ToList());
		}

		// POST api/<controller>
		[HttpPost]
		public void Post([FromForm] string value, IFormFile file)
		{

		}

		// POST api/<controller>/usuario/5
		[HttpPost("login")]
		public async Task<IActionResult> Post([FromForm] LoginView login)
		{
			return Ok(login);
		}

		// PUT api/<controller>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<controller>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}

		// DELETE api/<controller>/5
		[HttpGet("personas")]
		public async Task<IActionResult> Personas()
		{
			//return Ok(Contexto.Personas.Include(x => x.Pasatiempos).ThenInclude(x => x.Pasatiempo).Select(x => new PersonaView(x)));
			var lta = await Contexto.Personas.Include(x => x.Pasatiempos).ThenInclude(x => x.Pasatiempo).ToListAsync();
			return Ok(lta.Select(x => new PersonaView(x)));
		}

		// DELETE api/<controller>/5
		[HttpGet("pasatiempos")]
		public async Task<IActionResult> Pasatiempos()
		{
			return Ok(Contexto.PersonaPasatiempos.Include(x => x.Pasatiempo).Where(x => x.PersonaId == 10).Select(x => x.Pasatiempo));
		}

		// DELETE api/<controller>/5
		[HttpGet("dependientes")]
		public async Task<IActionResult> Dependientes()
		{
			Persona p10 = new Persona
			{
				Id = 10,
				Pasatiempos = new List<PersonaPasatiempo>
				{
					new PersonaPasatiempo {
						Id = 10,
					},
					new PersonaPasatiempo {
						Id = 0,
						PersonaId = 10,
						PasatiempoId = 11,
					},
				},
			};
			Contexto.Personas.Attach(p10);
			await Contexto.SaveChangesAsync();
			return Ok(1);
		}
	}
}
