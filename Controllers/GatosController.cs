using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    public class GatosController : Controller
    {
        private readonly List<IGato> _razaGato;
        private readonly IMetodosGato _metodosGato;
        public GatosController(IMetodosGato metodos, IGato gato)
        {
            _metodosGato = metodos;
            _razaGato  = new List<IGato>()
            {
                new Gato {Raza = "Persa", Id = 0},
                new Gato {Raza = "Bengala",Id = 1},
                new Gato {Raza = "Siames",Id = 2},
                new Gato {Raza = "Esfinge",Id = 3}
            };
        }

        [Route("ObtenerRaza")]
        [HttpGet]
        public async Task<ActionResult> ObtenerRaza()
        {
            try
            {
                var catList = _metodosGato.ObtenerLista(_razaGato);
               
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

                var listaActualizada = _metodosGato.MetodoAgregarRaza(raza, _razaGato);

                return Ok(listaActualizada);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("ActualizarRazaPorPosicion")]
        [HttpPut]

        public async Task<ActionResult> ActualizarRazaPorPosicion(string raza, int id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(raza))
                {
                    return BadRequest("Escribe una raza de gato por favor");
                }

                if (id >= 0 && id > 3)
                {
                    return BadRequest("Escribe un numero dentro del rango 0 y 3 porfavor");
                }

                var listaActualizada = _metodosGato.MetodoActualizarRazaPorPosicion(raza, id, _razaGato);

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

                var seActualizo = _metodosGato.MetodoActualizarRazaPorNombre(razaEnLista, razaNueva, _razaGato);
                var listaRaza = _metodosGato.ObtenerLista(_razaGato);
                

                if (!seActualizo)
                {
                    return BadRequest("Escribe una raza de gato en lista por favor");
                }

                return Ok(listaRaza);
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
                //Validar que el indice a eliminar este dentro del rango y en caso contrario mandar un 400

                if (id >= 0 && id > 3)
                {
                    return BadRequest("Escribe un numero dentro del rango 0 y 3 porfavor");
                }

                var seBorro = _metodosGato.MetodoDeleteRazaPorPosicion(id, _razaGato);
                var listaRaza = _metodosGato.ObtenerLista(_razaGato);
                

                return Ok(listaRaza);
            }
            //Regresar mensaje de excepcion a la respuesta del servicio
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

                var seBorro = _metodosGato.MetodoDeleteRazaPorNombre(raza, _razaGato);
                var listaRaza = _metodosGato.ObtenerLista(_razaGato);
                

                //En caso de que sea falso mandar un 400
                if (!seBorro)
                {
                    return BadRequest("Escribe una raza de gato en lista por favor");
                }

                return Ok(listaRaza);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
