namespace WebApplication1
{
    public class Perro
    {
        public string Raza { get; set; }

       public int Id { get; set; }    
     
        public string ObtieneRaza(Perro perro)
        {
            return perro.Raza;
        }

    }
}
