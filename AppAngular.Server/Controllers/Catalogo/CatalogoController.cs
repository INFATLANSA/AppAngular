using AppAngular.Server.Entities;
using AppAngular.Server.Servicio;
using AppAngular.Server.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAngular.Server.Controllers.Catalogo
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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

                //Ejemplo de log tomando los claims del jwt
                var claims = User.Claims.Select(x => new {x.Type, x.Value}).ToList();
                var usuario = claims[0].Value;

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

        // DELETE api/<CatalogoController>/ESO
        [HttpDelete("{idCatalogo}")]
        public IActionResult Delete(string idCatalogo)
        {
            try
            {
                generalResponse = _servicioCatalogo.eliminarCatalogo(idCatalogo);
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
    }
}
