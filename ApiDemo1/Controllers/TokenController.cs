using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using ApiDemo1.Modelo.DTO;

namespace ApiDemo1.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthInfo user)
        {
            var token = user.Username + user.Password;

            if(token == null)
            {
                return Unauthorized();
            }

            return Ok();
        }

    }
}
