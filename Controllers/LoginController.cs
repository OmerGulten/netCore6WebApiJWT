using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using netCore6WebApiJWT.Authentication;
using netCore6WebApiJWT.Models;

namespace netCore6WebApiJWT.Controllers
{
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly IJWTAuthenticationManager _jwtAuthenticationManager;
        public LoginController(IJWTAuthenticationManager jwtAuthenticationManager)
        {
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] User user)
        {
            var token = _jwtAuthenticationManager.Authenticate(user.UserName, user.Password);
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
