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

        [HttpGet]
        public async Task<ActionResult> ObtenerJuegos()
        {
            var juegos = await ListaJuegosAsync();

            return Ok(juegos);
        }

        [HttpPost]
        public async Task<ActionResult> AgregarJuego(string juego)
        {
            try
            {
                juego = string.Empty;

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