using AppAngular.Server.Servicio;
using AppAngular.Server.Utils;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAngular.Server.Controllers.Catalogo
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogoController : ControllerBase
    {
        //Inyectar la interfaz de Servicio
        private readonly IServicioCatalogo _servicioCatalogo;
        
        //Instancia a clase de respuestas.
        GeneralResponse generalResponse = new GeneralResponse();
        public CatalogoController(IServicioCatalogo servicioCatalogo)
        {
            _servicioCatalogo = servicioCatalogo;
        }


        // GET: api/<CatalogoController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                generalResponse = _servicioCatalogo.listaCatalogos();
                if (generalResponse.Status.Equals(Constantes.CODIGO_EXITO))
                {
                    return Ok(generalResponse);
                }
                else
                {
                    return BadRequest(generalResponse);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(Constantes.CODIGO_ERROR, ex.Message);
            }
        }

        // GET api/<CatalogoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CatalogoController>
        [HttpPost]
        public IActionResult Post([FromBody] Entities.Catalogo catalogo) 
        {
            try
            {
                generalResponse = _servicioCatalogo.guardarCatalogo(catalogo);
                if (generalResponse.Status.Equals(Constantes.CODIGO_EXITO))
                {
                    return Ok(generalResponse);
                }
                else
                {
                    return BadRequest(generalResponse);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(Constantes.CODIGO_ERROR, ex.Message);
            }
        }

        // PUT api/<CatalogoController>/ESO
        [HttpPut("{idCatalogo}")]
        public IActionResult Put(string idCatalogo, [FromBody] Entities.Catalogo catalogo)
        {
            try
            {
                generalResponse = _servicioCatalogo.actualizarCatalogo(idCatalogo, catalogo);
                if (generalResponse.Status.Equals(Constantes.CODIGO_EXITO))
                {
                    return Ok(generalResponse);
                }
                else 
                {
                    return BadRequest(generalResponse); 
                }
            }
            catch (Exception ex)
            {
                return StatusCode(Constantes.CODIGO_ERROR, ex.Message);
            }
        }

        // DELETE api/<CatalogoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
