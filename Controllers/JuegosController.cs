using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JuegosController : Controller
    {
        [HttpGet]
        public IEnumerable<string> ObtenerJuegos()
        {
            List<string> juegos = new List<string>()
            {
                "Halo", "Doom", "AoE", "Oblivion"
            };

            return juegos;
        }
    }
}