using GreenroomServer.TokenAuthentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreenroomServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly ITokenManager tokenManager;
        public AuthenticateController(ITokenManager tokenManager)
        {
            this.tokenManager = tokenManager;
        }

        public async  Task<IActionResult> Authenticate (string email, string password)
        {
            var result = await tokenManager.Authenticate(email, password);
 
            if (result.Value)
            {
                return Ok(new { Token = tokenManager.NewToken() });
            } 
            else
            {
                ModelState.AddModelError("Unauthorized", "Access Denied");
                return Unauthorized(ModelState);
            }
        }
    }
}
