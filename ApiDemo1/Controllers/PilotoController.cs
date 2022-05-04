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
    public class PilotoController : ControllerBase
    {
        private readonly IPiloto _Piloto;

        public PilotoController(IPiloto ipiloto)
        {
            _Piloto = ipiloto;
        }

        [HttpPost]
        public IActionResult CreatePiloto([FromBody] Piloto NewItem)
        {
            try
            {

                if (NewItem == null || !ModelState.IsValid)
                {
                    return BadRequest("Error: Envio de datos");
                }

                //continuo con el registro de datos

                _Piloto.TranPiloto(NewItem);

            }
            catch (Exception ex)
            {
                return BadRequest("Error:" + ex.Message);
            }

            return Ok();
        }
    }
}
