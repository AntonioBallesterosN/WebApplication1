using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class JuegosController : Controller
    {
        private readonly List<string> _juegos;

        public JuegosController()
        {
            _juegos = new List<string>()
            {
                "Halo", "Doom", "AoE", "Oblivion"
            };
        }

        [Route("ObtenerJuegos")]
        [HttpGet]
        public async Task<ActionResult> ObtenerJuegos()
        {
            var juegos = await ListaJuegosAsync();

            return Ok(juegos);
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

                _juegos.Add(juego);

                return Ok(_juegos);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [Route("ActualizarJuegoPorPosicion")]
        [HttpPut]

        public async Task<ActionResult> ActualizarJuegoPorPosicion(string juego, int id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(juego))
                {
                    return BadRequest("Escribe un juego por favor");
                }
               
                _juegos.RemoveAt(id);
                _juegos.Insert(id, juego);

                return Ok(_juegos);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        
        [Route("ActualizarJuegoPorNombre")]
        [HttpPut]

        public async Task<ActionResult> ActualizarJuegoPorNombre(string juegoEnLista, string juegoNuevo)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(juegoEnLista))
                {
                    return BadRequest("Escribe un juego por favor");
                }

                switch (juegoEnLista)
                {
                    case "Halo":
                        _juegos.RemoveAt(0);
                        _juegos.Insert(0, juegoNuevo); break;

                    case "Doom":
                        _juegos.RemoveAt(1);
                        _juegos.Insert(1, juegoNuevo); break;

                    case "AoE":
                        _juegos.RemoveAt(2);
                        _juegos.Insert(2, juegoNuevo); break;

                    case "Oblivion":
                        _juegos.RemoveAt(3);
                        _juegos.Insert(3, juegoNuevo); break;

                }

                return Ok(_juegos);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [Route("DeleteJuegosPorPosicion")]
        [HttpDelete]

        public async Task<ActionResult> DeleteJuegosPorPosicion(int id)
        {
            try
            {
                var id1 = (id).ToString();
                if (string.IsNullOrWhiteSpace(id1))
                {
                    return BadRequest("Escribe un juego por favor");
                }

                _juegos.RemoveAt(id);

                return Ok(_juegos);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }

        }

        [Route("DeleteJuegosPorNombre")]
        [HttpDelete]

        public async Task<ActionResult> DeleteJuegosPorNombre(string juego)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(juego))
                {
                    return BadRequest("Escribe un juego por favor");
                }

                switch(juego)
                {
                    case "Halo":
                        _juegos.RemoveAt(0); break;

                    case "Doom":
                        _juegos.RemoveAt(1); break;

                    case "AoE":
                        _juegos.RemoveAt(2); break;

                    case "Oblivion":
                        _juegos.RemoveAt(3); break;
                }

                return Ok(_juegos);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        //Método Asíncrono
        private async Task<List<string>> ListaJuegosAsync()
        {
            var primeraTarea = await Task.Run(() => _juegos);

            return primeraTarea;
        }

        //Método Síncrono
        private List<string> ListaJuegos()
        {
            return _juegos;
        }

        //Método Void Asíncrono
        private async Task MetodoVoid()
        {
            var cadena = "Hola";

            var tarea = await Task.Run(() => cadena);
        }
    }
}