namespace WebApplication1
{
    public class JuegosService : IJuegosService
    {
        public List<Juegos> ObtenerJuegos()
        {
            var juegos = new List<Juegos>()
            {
                 new Juegos {
                    Juego = "Hallo"
                    , Id = 0
                },
                new Juegos {
                    Juego = "Doom"
                    , Id = 1
                },
                new Juegos {
                    Juego = "AoE"
                    ,Id = 2
                },
                new Juegos {
                    Juego = "Oblivion"
                    ,Id = 3
                }
            };

            return juegos;
        }

        public bool GetById(int id)
        {
            var exito = false;

            try
            {
                var listaDeJuegos = ObtenerJuegos();
                var buscaId = listaDeJuegos.First(i => i.Id == id);
            }
            catch
            {
                exito = true;
            }
            return exito;
        }

        public bool MetodoAgregarJuego(string juegoNuevo)
        {
            var seCambio = true;
            var listaDeRazas = ObtenerJuegos();
            listaDeRazas.Add(new Juegos() { Juego = juegoNuevo, Id = 4 });

            return seCambio;
        }

        public bool MetodoActualizarJuegoPorNombre(string juegoEnLista, string juegoNuevo)
        {
            var exito = true;
            var listaDeJuegos = ObtenerJuegos();

            try
            {
                var elementoRemplazar = listaDeJuegos.First(i => i.Juego == juegoEnLista);
                var posicion = listaDeJuegos.IndexOf(elementoRemplazar);
                listaDeJuegos[posicion].Juego = juegoNuevo;
            }
            catch
            {
                exito = false;
                return exito;
            }

            return exito;
        }

        public bool MetodoDeleteJuegoPorPosicion(int posicion)
        {
            var exito = true;
            var listaDeJuegos = ObtenerJuegos();
            listaDeJuegos.RemoveAt(posicion);

            return exito;
        }

        public bool MetodoDeleteJuegoPorNombre(string juego)
        {
            var exito = true;
            var listaDeJuegos = ObtenerJuegos();

            try
            {
                var elementoEliminar = listaDeJuegos.First(i => i.Juego == juego);
                var id = listaDeJuegos.IndexOf(elementoEliminar);
                listaDeJuegos.RemoveAt(id);
            }
            catch
            {
                exito = false;
                return exito;
            }

            return exito;
        }

        public List<Juegos> MetodoActualizarJuegoPorPosicion(int posicion, string juegoNuevo)
        {
            var listaDeJuegos = ObtenerJuegos();
            listaDeJuegos[posicion].Juego = juegoNuevo;

            return listaDeJuegos;
        }
    }
}
