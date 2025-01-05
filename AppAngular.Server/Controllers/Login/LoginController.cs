using AppAngular.Server.Servicio;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAngular.Server.Controllers.Login
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IServicioGenerarToken _servicioGenerarToken;
        public LoginController(IServicioGenerarToken servicioGenerarToken) 
        {
            _servicioGenerarToken = servicioGenerarToken;  
        }

        // GET api/<LoginController>/5
        [HttpGet("{username}")]
        public IActionResult Get(string username)
        {
            var token = _servicioGenerarToken.GenerateJwtToken(username);   
            return Ok(new {Token= token});
        }       
    }
}
