namespace WebApplication1
{
    public class Perro:IPerro
    {
        public string Raza { get; set; }

        public string Color { get; set; }

        public string Tamaño { get; set; }

        public string ObtieneRaza(Perro perro)
        {
            return perro.Raza;
        }

        public string ObtieneColor(Perro perro)
        {
            return perro.Color;
        }

        public string ObtieneTamaño(Perro perro)
        {
            return perro.Tamaño;
        }
    }
}
