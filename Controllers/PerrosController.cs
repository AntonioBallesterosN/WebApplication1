using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PerrosController : Controller
    {
        private readonly List<string> _razaPerros;

        public PerrosController()
        {
            _razaPerros = new List<string>()
            {
                "Galgo","Dalmata","Dingo","Terrierr"
            };
        }

        [Route("ObtenerPerros")]
        [HttpGet]

        public async Task<ActionResult> ObtenerRazaPerros()
        {
            return Ok(_razaPerros);
        }

        [Route("AgregarRazaPerro")]
        [HttpPost]
        public async Task<ActionResult> AgregarRazaPerro(string raza)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(raza))
                {
                    return BadRequest("Escribe una raza de perro por favor");
                }

                _razaPerros.Add(raza);

                return Ok(_razaPerros);
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

                _razaPerros.RemoveAt(id);
                _razaPerros.Insert(id, raza);

                return Ok(_razaPerros);
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
                    return BadRequest("Escribe una raza de perro por favor");
                }

                switch (razaEnLista)
                {
                    case "Galgo":
                        _razaPerros.RemoveAt(0);
                        _razaPerros.Insert(0, razaNueva); break;

                    case "Dalmata":
                        _razaPerros.RemoveAt(1);
                        _razaPerros.Insert(1, razaNueva); break;

                    case "Dingo":
                        _razaPerros.RemoveAt(2);
                        _razaPerros.Insert(2, razaNueva); break;

                    case "Terrierr":
                        _razaPerros.RemoveAt(3);
                        _razaPerros.Insert(3, razaNueva); break;
                }

                return Ok(_razaPerros);
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

                _razaPerros.RemoveAt(id);

                return Ok(_razaPerros);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
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

                switch (raza)
                {
                    case "Galgo":
                        _razaPerros.RemoveAt(0); break;

                    case "Dalmata":
                        _razaPerros.RemoveAt(1); break;

                    case "Dingo":
                        _razaPerros.RemoveAt(2); break;

                    case "Terrierr":
                        _razaPerros.RemoveAt(3); break;
                }

                return Ok(_razaPerros);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
