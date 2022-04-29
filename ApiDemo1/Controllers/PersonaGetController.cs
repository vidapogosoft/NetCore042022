using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ApiDemo1.Interfaces;
using ApiDemo1.Modelo.Database;


namespace ApiDemo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaGetController : ControllerBase
    {
        private readonly IPersonasGet _Persona;

        public PersonaGetController (IPersonasGet iper)
        {
            _Persona = iper;
        }

        [HttpGet("PerosnasAll1")]
        public IActionResult Get1()
        {
            return Ok(_Persona.ListPersonaAll);
        }

        [HttpGet("PerosnasAll2")]
        public IActionResult Get2()
        {
            return Ok(_Persona.ListPersonaAll2);
        }

        [HttpGet("Estado/{Estado}")]
        public IActionResult GetPersonasByEstado(string Estado)
        {
            return Ok(_Persona.ListPersonas(Estado));
        }

        [HttpGet("DNI/{Identificacion}")]
        public IActionResult GetPersonaByIdentificacion(string Identificacion)
        {
            return Ok(_Persona.ListPersonaByIdentificacion(Identificacion));
        }

        [HttpGet("Id/{Id}/{Estado}")]
        public IActionResult GetPersonaById(int Id, string Estado)
        {
            return Ok(_Persona.ListPersonaById(Id, Estado));
        }

        [HttpPost]
        public IActionResult CreatePersona([FromBody] Persona NewItem)
        {
            try
            {

                if (NewItem == null || !ModelState.IsValid)
                {
                    return BadRequest("Error: Envio de datos");
                }

                //continuo con el registro de datos

                _Persona.InsertPersona(NewItem);

            }
            catch(Exception ex)
            {
                return BadRequest("Error:" + ex.Message);
            }

           
            return Ok(NewItem);
        }

    }
}
