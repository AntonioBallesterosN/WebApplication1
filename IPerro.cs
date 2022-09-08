namespace WebApplication1
{
    public interface IPerro
    {
        string Raza { get; set; }

        string Color { get; set; }

        string Tamaño { get; set; }

        public string ObtieneRaza(Perro perro);

        public string ObtieneColor(Perro perro);

        public string ObtieneTamaño(Perro perro);

    }
}
