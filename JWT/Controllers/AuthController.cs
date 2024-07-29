using JWT.Dtos;
using JWT.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthInterface _authInterface;

        public AuthController(IAuthInterface authInterface)
        {
            this._authInterface = authInterface;
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(UsuarioLoginDto usuario)
        {
            var response = await _authInterface.Login(usuario);
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(UsuarioDto usuario)
        {
            var response = await _authInterface.Register(usuario);
            return Ok(response);
        }
    }
}
