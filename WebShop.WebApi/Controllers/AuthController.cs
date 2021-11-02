using Microsoft.AspNetCore.Mvc;
using WebShop.WebApi.Dtos.Auth;

namespace WebShop.WebApi.Controllers
{
    public class AuthController : Controller
    {
        [HttpPost]
        public ActionResult<TokenDto> Login([FromBody] LoginDto login)
        {
            if ("admin".Equals(login.Username) && "123456".Equals(login.Password))
            {
                //Get Token
                return Ok(new TokenDto{JwtValue = "jwt12345"});
            }
            return Unauthorized();
        }
    }
}