using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    public class JuegosController : Controller
    {
        private readonly IJuegosService _juegosService;
        public JuegosController(IJuegosService juegosService)
        {
            _juegosService = juegosService;
        }

        [Route("ObtenerJuego")]
        [HttpGet]
        public async Task<ActionResult> ObtenerJuego()
        {
            try
            {
                var gameList = _juegosService.ObtenerJuegos();

                return Ok(gameList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("AgregarJuego")]
        [HttpPost]
        public async Task<ActionResult> AgregarJuego(string juego)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(juego))
                {
                    return BadRequest("Escribe un juego por favor");
                }

                var resultado = _juegosService.MetodoAgregarJuego(juego);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("ActualizarJuegoPorPosicion")]
        [HttpPut]

        public async Task<ActionResult> ActualizarJuegoPorPosicion(int posicion, string juegoNuevo)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(juegoNuevo))
                {
                    return BadRequest("Escribe un juego por favor");
                }

                if (posicion >= 0 && posicion > 3)
                {
                    return BadRequest("Escribe un numero dentro del rango 0 y 3 porfavor");
                }

                var listaActualizada = _juegosService.MetodoActualizarJuegoPorPosicion(posicion, juegoNuevo);

                return Ok(listaActualizada);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("ActualizarJuegoPorNombre")]
        [HttpPut]

        public async Task<ActionResult> ActualizarJuegoPorNombre(string juegoEnLista, string juegoNuevo)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(juegoNuevo))
                {
                    return BadRequest("Escribe un juego por favor");
                }

                var seActualizo = _juegosService.MetodoActualizarJuegoPorNombre(juegoEnLista, juegoNuevo);

                if (!seActualizo)
                {
                    return BadRequest("Escribe un juego en lista por favor");
                }

                return Ok(seActualizo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("DeleteJuegoPorPosicion")]
        [HttpDelete]

        public async Task<ActionResult> DeleteJuegoPorPosicion(int posicion)
        {
            try
            {
                if (posicion >= 0 && posicion > 3)
                {
                    return BadRequest("Escribe un numero dentro del rango 0 y 3 porfavor");
                }

                var existe = _juegosService.MetodoDeleteJuegoPorPosicion(posicion);

                return Ok(existe);
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("DeleteJuegoPorNombre")]
        [HttpDelete]
        public async Task<ActionResult> DeleteJuegoPorNombre(string juego)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(juego))
                {
                    return BadRequest("Escribe un juego por favor");
                }

                var seBorro = _juegosService.MetodoDeleteJuegoPorNombre(juego);

                if (!seBorro)
                {
                    return BadRequest("Escribe un juego en lista por favor");
                }

                return Ok(seBorro);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

