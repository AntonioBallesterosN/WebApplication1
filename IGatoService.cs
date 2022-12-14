namespace WebApplication1
{
    public interface IGatoService
    {
        List<Gato> ObtenerRazas();
      
        bool GetById(int id);

        bool MetodoAgregarRaza(string razaNueva);

        bool MetodoActualizarRazaPorNombre(string razaEnLista, string nuevaRaza);

        bool MetodoDeleteRazaPorPosicion(int posicion);

        bool MetodoDeleteRazaPorNombre(string raza);

        List<Gato> MetodoActualizarRazaPorPosicion(int posicion, string nuevaRaza);
    }
}
