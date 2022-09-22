namespace WebApplication1
{
    public class GatoService : IGatoService
    {
        public List<Gato> ObtenerRazas()
        {
            var gatos = new List<Gato>()
            {
                new Gato {
                    Raza = "Persa"
                    , Id = 0
                },
                new Gato {Raza = "Bengala", Id = 1},
                new Gato {Raza = "Siames",Id = 2},
                new Gato {Raza = "Esfinge",Id = 3}
            };

            return gatos;
        }
    }
}