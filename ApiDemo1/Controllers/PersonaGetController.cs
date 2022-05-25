using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ApiDemo1.Interfaces;
using ApiDemo1.Modelo.Database;


using Microsoft.AspNetCore.Authorization;

namespace ApiDemo1.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaGetController : ControllerBase
    {
        private readonly IPersonasGet _Persona;

        public PersonaGetController (IPersonasGet iper)
        {
            _Persona = iper;
        }

        [HttpGet("PersonasAll1")]
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

        [HttpGet("IdPersona/{IdPersona}")]
        public IActionResult GetPersonaByIde(int IdPersona)
        {
            return Ok(_Persona.ListPersonaById2(IdPersona));
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

        [HttpPut]
        public IActionResult UpdatePersona([FromBody] Persona Item)
        {
            try
            {
                if (Item == null || !ModelState.IsValid)
                {
                    return BadRequest("Error: Envio de datos");
                }

                _Persona.UpdatePersona(Item);

            }
            catch (Exception ex)
            {
                return BadRequest("Error:" + ex.Message);
            }


            return Ok(Item);

        }

        [HttpPut("update/{IdPersona}/{Identificacion}/{Nombres}/{Apellidos}/{Estado}")]
        public IActionResult UpdatePersona2(int IdPersona, string Identificacion,
                string Nombres, string Apellidos, string Estado)
        {
            try
            {
                if (IdPersona == 0)
                {
                    return BadRequest("Error: Envio de datos");
                }

                _Persona.UpdatePersona2(IdPersona, Identificacion,
                Nombres, Apellidos, Estado);

            }
            catch (Exception ex)
            {
                return BadRequest("Error:" + ex.Message);
            }


            return Ok();

        }

        [HttpDelete]
        public IActionResult DeletePersona([FromBody] Persona Item)
        {
            try
            {
                if (Item == null || !ModelState.IsValid)
                {
                    return BadRequest("Error: Envio de datos");
                }

                _Persona.DeletePersona(Item);

            }
            catch (Exception ex)
            {
                return BadRequest("Error:" + ex.Message);
            }


            return Ok();

        }

    }
}
