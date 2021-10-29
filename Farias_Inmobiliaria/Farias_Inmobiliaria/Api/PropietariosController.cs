﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Farias_Inmobiliaria.Models;
using Inmobiliaria_.Net_Core.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inmobiliaria_.Net_Core.Api
{
	[Route("api/[controller]")]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]     // Aca aclaro que para autorizar revise lo tokens
	[ApiController]
	public class PropietariosController : ControllerBase//
	{
		private readonly DataContext contexto;
		private readonly IConfiguration config;

		public PropietariosController(DataContext contexto, IConfiguration config)
		{
			this.contexto = contexto;
			this.config = config;
		}
		// GET: api/<controller>						// Ok
		[HttpGet]
		public async Task<ActionResult<Propietario>> Get()	
		{
			try
			{
				/*contexto.Inmuebles
                    .Include(x => x.Duenio)
                    .Where(x => x.Duenio.Nombre == "")//.ToList() => lista de inmuebles
                    .Select(x => x.Duenio)
                    .ToList();//lista de propietarios*/
				var usuario = User.Identity.Name;
				/*contexto.Contratos.Include(x => x.Inquilino).Include(x => x.Inmueble).ThenInclude(x => x.Duenio)
                    .Where(c => c.Inmueble.Duenio.Email....);*/
				/*var res = contexto.Propietarios.Select(x => new { x.Nombre, x.Apellido, x.Email })
                    .SingleOrDefault(x => x.Email == usuario);*/
				Propietario prop = await contexto.Propietarios.SingleOrDefaultAsync(x => x.Email == usuario);
				return Ok(prop);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// GET api/Propietarios/2						// Ok
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			try
			{
				var entidad = await contexto.Propietarios.SingleOrDefaultAsync(x => x.IdPropietario == id);
				return entidad != null ? Ok(entidad) : NotFound();
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// GET api/<controller>/GetAll					// Ok
		[HttpGet("GetAll")]
		public async Task<IActionResult> GetAll()
		{
			try
			{
				return Ok(await contexto.Propietarios.ToListAsync());
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// POST api/<controller>/login					// Ok
		[HttpPost("login")]							
		[AllowAnonymous]
		public async Task<IActionResult> Login([FromForm] String usuario, [FromForm] String clave)
		{
			try
			{
				string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
					password: clave,
					salt: System.Text.Encoding.ASCII.GetBytes(config["Salt"]),
					prf: KeyDerivationPrf.HMACSHA1,
					iterationCount: 1000,
					numBytesRequested: 256 / 8));
				var p = await contexto.Propietarios.FirstOrDefaultAsync(x => x.Email == usuario);
				if (p == null || p.Password != hashed)
				{
					return BadRequest("Nombre de usuario o clave incorrecta");
				}
				else
				{
					// Para el json w token

					var key = new SymmetricSecurityKey(
						System.Text.Encoding.ASCII.GetBytes(config["TokenAuthentication:SecretKey"]));
					var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
					var claims = new List<Claim>
					{
						new Claim(ClaimTypes.Name, p.Email),
						new Claim("FullName", p.Nombre + " " + p.Apellido),
						new Claim(ClaimTypes.Role, "Propietario"),
					};

					var token = new JwtSecurityToken(
						issuer: config["TokenAuthentication:Issuer"],
						audience: config["TokenAuthentication:Audience"],
						claims: claims,
						expires: DateTime.Now.AddYears(1),
						signingCredentials: credenciales
					);

					var rta = new LoginRetrofit(
						Token: new JwtSecurityTokenHandler().WriteToken(token)
						);
					
					return Ok(rta);
				}
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// POST api/Propietarios/Crear					// Ok faltaria mejorar el mensaje de fallo insertar datos
		[HttpPost("Crear")]
		public async Task<IActionResult> Crear([FromForm] Propietario entidad)
		{
			try
			{
				if (ModelState.IsValid)
				{
					await contexto.Propietarios.AddAsync(entidad);
					contexto.SaveChanges();
					return CreatedAtAction(nameof(Get), new { id = entidad.IdPropietario }, entidad);
				}
				return BadRequest();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// PUT api/Propietarios/Editar				// Ok
		[HttpPatch("Editar")]
		public async Task<IActionResult> Editar([FromBody] Propietario propietario)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var usuario = User.Identity.Name;

					if(usuario != propietario.Email)
                    {
						return BadRequest(new { Error = "No es el mismo usuario" }); 
                    }
					
					Propietario original = await contexto.Propietarios.AsNoTracking().SingleOrDefaultAsync(p => p.IdPropietario == propietario.IdPropietario);
                    
					if (String.IsNullOrEmpty(propietario.Password))
                    {
                        propietario.Password = original.Password;
                    }
                    else
                    {
                        propietario.Password = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                            password: propietario.Password,
                            salt: System.Text.Encoding.ASCII.GetBytes(config["Salt"]),
                            prf: KeyDerivationPrf.HMACSHA1,
                            iterationCount: 1000,
                            numBytesRequested: 256 / 8));
                    }
                    contexto.Propietarios.Update(propietario);
					await contexto.SaveChangesAsync();
					return Ok(propietario);
				}
				return BadRequest(new { Error = "Modelo invalido" });
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// DELETE api/Propietarios/Delete/5				// Ok
		[HttpDelete("Delete/{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var p = contexto.Propietarios.Find(id);
					if (p == null)
						return NotFound();
					contexto.Propietarios.Remove(p);
					contexto.SaveChanges();
					return Ok(p);
				}
				return BadRequest();
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// GET: api/Propietarios/test					// Ok
		[HttpGet("test")]
		[AllowAnonymous]
		public IActionResult Test()
		{
			try
			{
				return Ok("anduvo");
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// GET: api/Propietarios/test/5					// Ok
		[HttpGet("test/{codigo}")]
		[AllowAnonymous]
		public IActionResult Code(int codigo)
		{
			try
			{
				//StatusCodes.Status418ImATeapot //constantes con códigos
				return StatusCode(codigo, new { Mensaje = "Anduvo", Error = false });
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}
	}
}
