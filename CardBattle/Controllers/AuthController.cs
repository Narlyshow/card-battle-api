using CardBattle.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CardBattle.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        [HttpPost]
        [Route("Auth")]
        public async Task<ActionResult> Auth(string username, string password)
        {
            if(username == "Narlson" && password == "123456")
            {
                var token = TokenService.GenerateToken(new Domain.Models.Players());
                return Ok(token);
            }

            return BadRequest("username or password invalid");
        }
    
        
    }
}
