using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoLojaCarros.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Ol�, voc� deu um GET";
        }

        [HttpGet("authenticated")]
        [Authorize]
        public IActionResult GetAuthenticated()
        {
            return Ok("Voc� est� autenticado!");
        }
    }
}
