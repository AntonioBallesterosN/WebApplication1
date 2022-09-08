using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    public class GatosController : Controller
    {
        private readonly List<string> _razaGato;

        public GatosController()
        {
            _razaGato = new List<string>()
            {
                "Persa", "Bengala", "Siames", "Esfinge"
            };
        }


        [HttpGet]
        public async Task<ActionResult> ObtenerRazaGatos()
        {
            return Ok(_razaGato);
        }

        [HttpGet]
        [Route("ObtenerRaza")]
        public async Task<ActionResult> ObtenerRazaGatosDos()
        {
            return Ok(_razaGato);
        }

        [Route("AgregarRazaGato")]
        [HttpPost]
        public async Task<ActionResult> AgregarRazaGato(string raza)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(raza))
                {
                    return BadRequest("Escribe una raza de gato por favor");
                }

                _razaGato.Add(raza);

                return Ok(_razaGato);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
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
                    return BadRequest("Escribe una raza de perro por favor");
                }

                _razaGato.RemoveAt(id);
                _razaGato.Insert(id, raza);

                return Ok(_razaGato);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
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

                switch (razaEnLista)
                {
                    case "Persa":
                        _razaGato.RemoveAt(0);
                        _razaGato.Insert(0, razaNueva); break;

                    case "Bengala":
                        _razaGato.RemoveAt(1);
                        _razaGato.Insert(1, razaNueva); break;

                    case "Siames":
                        _razaGato.RemoveAt(2);
                        _razaGato.Insert(2, razaNueva); break;

                    case "Esfinge":
                        _razaGato.RemoveAt(3);
                        _razaGato.Insert(3, razaNueva); break;
                }

                return Ok(_razaGato);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [Route("DeleteRazaPorPosicion")]
        [HttpDelete]

        public async Task<ActionResult> DeleteRazaPorPosicion(int id)
        {
            try
            {
                var id1 = (id).ToString();

                if (string.IsNullOrWhiteSpace(id1))
                {
                    return BadRequest("Escribe una raza de perro por favor");
                }

                _razaGato.RemoveAt(id);

                return Ok(_razaGato);
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
                //Validar que el indice a eliminar este dentro del rango y en caso contrario mandar un 400

                if (string.IsNullOrWhiteSpace(raza))
                {
                    return BadRequest("Escribe una raza de perro por favor");
                }

                var fueEliminado = SwitchDeleteRazaPorNombre(raza);

                //En caso de que sea falso mandar un 400
                if (!fueEliminado)
                {
                    //
                }

                return Ok(_razaGato);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        private bool SwitchDeleteRazaPorNombre(string raza)
        {
            var exito = true;

            switch (raza)
            {
                case "Persa":
                    _razaGato.RemoveAt(0); break;

                case "Bengala":
                    _razaGato.RemoveAt(1); break;

                case "Siames":
                    _razaGato.RemoveAt(2); break;

                case "Esfinge":
                    _razaGato.RemoveAt(3); break;

                    //Si el texto no coincide mandar un false
            }

            return exito;
        }
    }
}
