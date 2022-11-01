namespace WebApplication1
{
    public interface IGatoService
    {
        List<Gato> ObtenerRazas();
        //interfaces nunca se especifica nivel de accesibilidad

        bool GetId(int id);

        bool MetodoAgregarRaza(string razaNueva);

        bool MetodoActualizarRazaPorNombre(string razaEnLista, string razaNueva);

        bool MetodoDeleteRazaPorPosicion(int id);

        bool MetodoDeleteRazaPorNombre(string raza);

        bool MetodoActualizarRazaPorPosicion(int posicion, string nuevaRaza);
    }
}
