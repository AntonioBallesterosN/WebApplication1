using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        //
        private readonly IGato _gato;
        private readonly IPerro _perro;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IGato gato, IPerro perro)
        {
            _logger = logger;
            _gato = gato;
            _perro = perro;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            _gato.Raza = "Montes";
            _gato.Color = "Negro";

            Gato gatoDos = (Gato)_gato;

           var color = _gato.ObtieneColor(gatoDos);

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

       
    }
}