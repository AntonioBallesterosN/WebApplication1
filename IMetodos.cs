namespace WebApplication1
{
    public interface IMetodosGato
    {
        List<IGato> ListaRaza { get; set; }

        public List<string> ObtenerLista(List<IGato> _listaraza);

        public List<string> MetodoAgregarRaza(string raza, List<IGato> _listaraza);

        public List<string> MetodoActualizarRazaPorPosicion(string razaNueva, int id, List<IGato> _listaraza);

        public bool MetodoActualizarRazaPorNombre(string razaEnLista, string razaNueva, List<IGato> _listaraza);

        public List<string> MetodoDeleteRazaPorPosicion(int id, List<IGato> _listaraza);

        public bool MetodoDeleteRazaPorNombre(string raza, List<IGato> _listaraza);

        //public int ExtraerPosicionDeLista(string raza, List<IGato> _listaraza);

        //public string ExtraerElementoDeLista(int id, List<string> _listaraza);
    }
}
