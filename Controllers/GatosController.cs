using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    public class GatosController : Controller
    {
        private readonly List<Gato> _razaGato;
        private readonly IGatoService _gatoService;
        public GatosController(IGatoService gatoService)
        {
            _gatoService = gatoService;
        }

        [Route("ObtenerRaza")]
        [HttpGet]
        public async Task<ActionResult> ObtenerRaza()
        {
            try
            {
                var catList = _gatoService.ObtenerRazas();
               
                return Ok(catList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("AgregarRazaGato")]
        [HttpPost]
        public async Task<ActionResult> AgregarRaza(string raza)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(raza))
                {
                    return BadRequest("Escribe una raza de gato por favor");
                }

                var resultado = _gatoService.MetodoAgregarRaza(raza);

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
                    return BadRequest("Escribe una raza de gato por favor");
                }

                if (posicion >= 0 && posicion > 3)
                {
                    return BadRequest("Escribe un numero dentro del rango 0 y 3 porfavor");
                }

                var listaActualizada = _gatoService.MetodoActualizarRazaPorPosicion(posicion,nuevaRaza);

                return Ok(listaActualizada);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //Adecuar de acuerdo a correciones
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

                var seActualizo = _gatoService.MetodoActualizarRazaPorNombre(razaEnLista, razaNueva);
                
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

        public async Task<ActionResult> DeleteRazaPorPosicion(int id)
        {
            try
            {
                if (id >= 0 && id > 3)
                {
                    return BadRequest("Escribe un numero dentro del rango 0 y 3 porfavor");
                }

                var existe = _gatoService.MetodoDeleteRazaPorPosicion(id);

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
                    return BadRequest("Escribe una raza de gato por favor");
                }

                var seBorro = _gatoService.MetodoDeleteRazaPorNombre(raza);
                
                if (!seBorro)
                {
                    return BadRequest("Escribe una raza de gato en lista por favor");
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
