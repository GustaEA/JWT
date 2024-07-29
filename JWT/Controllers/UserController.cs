using JWT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {


        [HttpGet]
        [Authorize(Policy = "Teste")]
        public ActionResult<Response<string>> GetUser()
        {
            Response<string> response = new Response<string>();
            response.Message = "Acessei";
            return Ok(response);
        }
    }
}
