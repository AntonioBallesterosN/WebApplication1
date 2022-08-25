namespace WebApplication1
{
    public class Gato: IGato
    {
        public string Raza { get; set; }    

        public string Color { get; set; }

        public string Tamaño { get; set; }

        public string ObtieneColor(Gato gato)
        {
            return gato.Color;
        }
    }
}
