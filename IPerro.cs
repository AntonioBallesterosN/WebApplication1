namespace WebApplication1
{
    public interface IPerro
    {
        string Raza { get; set; }

        int Id { get; set; }    

        public string ObtieneRaza(Perro perro);

       
    }
}
