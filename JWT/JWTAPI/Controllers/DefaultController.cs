using JWTAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {

        [HttpGet("[action]")]
        public IActionResult GetJWT()
        {
            return Ok(new CreateToken().TokenCreate());
        }

        [Authorize]
        [HttpGet("[action]")]
        public IActionResult TestJWT()
        {
            return Ok("Hoşgeldiniz");
        }

        [HttpGet("[action]")]
        public IActionResult GetAdminJWT()
        {
            return Ok(new CreateToken().TokenCreateAdmin());
        }


        [Authorize(Roles = "Admin,Visitor")]
        [HttpGet("[action]")]
        public IActionResult TestAdminJWT()
        {
            return Ok("Admin token ile giriş yapıldı");
        }


    }
}
