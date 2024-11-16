using Microsoft.AspNetCore.Mvc;
using AppAngular.Server.Servicio;
using AppAngular.Server.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAngular.Server.Controllers.Parametro
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParametroController : ControllerBase
    {
        //Inyectar el Servicio 
        private readonly IServicioParametro _servicioParametro;

        GeneralResponse generalResponse = new GeneralResponse();
        public ParametroController(IServicioParametro servicioParametro)
        {
            _servicioParametro = servicioParametro;
        }

        // GET: api/<ParametroController>
        [HttpGet]
        public IActionResult Get()
        {
            generalResponse = _servicioParametro.listaParametros();
            if (generalResponse.Status.Equals(200))
            {
                return Ok(generalResponse);
            }
            else {
                return BadRequest(generalResponse);
            }
        }

        // GET api/<ParametroController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ParametroController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ParametroController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ParametroController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
