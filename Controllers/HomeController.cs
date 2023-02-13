using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace netCore6WebApiJWT.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [HttpPost("TestJwtToken")]
        public IActionResult TestJwtToken()
        {
            return Ok("Authentication is successful!");
        }
    }
}