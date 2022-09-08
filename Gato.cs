namespace WebApplication1
{
    public class Gato: IGato
    {
        public string Raza { get; set; }    

        public string Color { get; set; }

        public string Tamaño { get; set; }

        public string ObtieneRaza(Gato gato)
        {
            return gato.Raza;
        }

        public string ObtieneColor(Gato gato)
        {
            return gato.Color;
        }

        public string ObtieneTamaño(Gato gato)
        {
            return gato.Tamaño;
        }
    }
}
