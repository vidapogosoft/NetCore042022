using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ApiDemo1.Interfaces;


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
    }
}
