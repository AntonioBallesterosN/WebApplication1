namespace WebApplication1
{
    public interface IGato
    {
        string Raza { get; set; }

        string Color { get; set; }

        string Tamaño { get; set; }

        public string ObtieneRaza(Gato gato);

        public string ObtieneColor(Gato gato);

        public string ObtieneTamaño(Gato gato);
 
    }
}
