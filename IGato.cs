namespace WebApplication1
{
    public interface IGato
    {
        string Raza { get; set; }

        string Color { get; set; }

        string Tamaño { get; set; }

        string ObtieneColor(Gato gato);

    }
}
