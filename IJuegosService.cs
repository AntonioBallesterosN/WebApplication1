namespace WebApplication1
{
    public interface IJuegosService
    {
        List<Juegos> ObtenerJuegos();

        bool GetById(int id);

        bool MetodoAgregarJuego(string juegoNuevo);

        bool MetodoActualizarJuegoPorNombre(string juegoEnLista, string juegoNuevo);

        bool MetodoDeleteJuegoPorPosicion(int posicion);

        bool MetodoDeleteJuegoPorNombre(string juego);

        List<Juegos> MetodoActualizarJuegoPorPosicion(int posicion, string juegoNuevo);
    }
}
