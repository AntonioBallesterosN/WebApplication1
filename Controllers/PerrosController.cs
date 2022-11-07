using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    public class PerrosController : Controller
    {
        private readonly IPerroService _perroService;
        public PerrosController(IPerroService perroService)
        {
            _perroService = perroService;
        }

        [Route("ObtenerRaza")]
        [HttpGet]
        public async Task<ActionResult> ObtenerRaza()
        {
            try
            {
                var dogList = _perroService.ObtenerRazas();

                return Ok(dogList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("AgregarRazaPerro")]
        [HttpPost]
        public async Task<ActionResult> AgregarRaza(string raza)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(raza))
                {
                    return BadRequest("Escribe una raza de perro por favor");
                }

                var resultado = _perroService.MetodoAgregarRaza(raza);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("ActualizarRazaPorPosicion")]
        [HttpPut]

        public async Task<ActionResult> ActualizarRazaPorPosicion(int posicion, string nuevaRaza)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nuevaRaza))
                {
                    return BadRequest("Escribe una raza de perro por favor");
                }

                if (posicion >= 0 && posicion > 3)
                {
                    return BadRequest("Escribe un numero dentro del rango 0 y 3 porfavor");
                }

                var listaActualizada = _perroService.MetodoActualizarRazaPorPosicion(posicion, nuevaRaza);

                return Ok(listaActualizada);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("ActualizarRazaPorNombre")]
        [HttpPut]

        public async Task<ActionResult> ActualizarRazaPorNombre(string razaEnLista, string razaNueva)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(razaNueva))
                {
                    return BadRequest("Escribe una raza de gato por favor");
                }

                var seActualizo = _perroService.MetodoActualizarRazaPorNombre(razaEnLista, razaNueva);

                if (!seActualizo)
                {
                    return BadRequest("Escribe una raza de gato en lista por favor");
                }

                return Ok(seActualizo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("DeleteRazaPorPosicion")]
        [HttpDelete]

        public async Task<ActionResult> DeleteRazaPorPosicion(int posicion)
        {
            try
            {
                if (posicion >= 0 && posicion > 3)
                {
                    return BadRequest("Escribe un numero dentro del rango 0 y 3 porfavor");
                }

                var existe = _perroService.MetodoDeleteRazaPorPosicion(posicion);

                return Ok(existe);
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("DeleteRazaPorNombre")]
        [HttpDelete]
        public async Task<ActionResult> DeleteRazaPorNombre(string raza)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(raza))
                {
                    return BadRequest("Escribe una raza de perro por favor");
                }

                var seBorro = _perroService.MetodoDeleteRazaPorNombre(raza);

                if (!seBorro)
                {
                    return BadRequest("Escribe una raza de perro en lista por favor");
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

