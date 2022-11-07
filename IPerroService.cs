namespace WebApplication1
{
    public interface IPerroService
    {
        List<Perro> ObtenerRazas();

        bool GetById(int id);

        bool MetodoAgregarRaza(string razaNueva);

        bool MetodoActualizarRazaPorNombre(string razaEnLista, string nuevaRaza);

        bool MetodoDeleteRazaPorPosicion(int posicion);

        bool MetodoDeleteRazaPorNombre(string raza);

        List<Perro> MetodoActualizarRazaPorPosicion(int posicion, string nuevaRaza);
    }
}
