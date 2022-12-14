namespace WebApplication1
{
    public class GatoService : IGatoService
    {
        public List<Gato> ObtenerRazas()
        {
            var gatos = new List<Gato>()
            {
                new Gato {
                    Raza = "Persa"
                    , Id = 0
                },
                new Gato {
                    Raza = "Bengala"
                    , Id = 1
                },
                new Gato {
                    Raza = "Siames"
                    ,Id = 2
                },
                new Gato {
                    Raza = "Esfinge"
                    ,Id = 3
                }
            };

            return gatos;
        }

        //Cambiar nombre de metodo por GetById 
        //coregido
        public bool GetById(int id)
        {
            var exito = false;

            try
            {
                var listaDeRazas = ObtenerRazas();
                var buscaId = listaDeRazas.First(i => i.Id == id);
            }
            catch
            {
                exito = true;  
            }
            return exito;
        }//Dejar un espVacio en blanco entre cada metodo
        //corregido
        public bool MetodoAgregarRaza(string razaNueva)
        {
            //Corregir tomando de ejemplo metodo linea 109 ??
            var seCambio = true;
            var listaDeRazas = ObtenerRazas();
            listaDeRazas.Add(new Gato() { Raza = razaNueva, Id = 4});
            
            return seCambio;
        }

        public bool MetodoActualizarRazaPorNombre(string razaEnLista, string nuevaRaza)
        {
            //Corregir tomando de ejemplo metodo linea 109 
            //corregido
            var exito = true;
            var listaDeRazas = ObtenerRazas();
           
            try
            {
                var elementoRemplazar = listaDeRazas.First(i => i.Raza == razaEnLista);
                var posicion = listaDeRazas.IndexOf(elementoRemplazar);
                listaDeRazas[posicion].Raza = nuevaRaza;
            }
            catch
            {
                exito = false;
                return exito;
            }

            return exito;
        }
        //Cambiar nombre de parametro
        //corregido
        public bool MetodoDeleteRazaPorPosicion(int posicion)
        {
            var exito = true;
            var listaDeRazas = ObtenerRazas();
            listaDeRazas.RemoveAt(posicion);
            
            return exito;
        }

        public bool MetodoDeleteRazaPorNombre(string raza)
        {
            var exito = true;
            var listaDeRazas = ObtenerRazas();

            try
            {
                var elementoEliminar = listaDeRazas.First(i => i.Raza == raza);
                var id = listaDeRazas.IndexOf(elementoEliminar);
                listaDeRazas.RemoveAt(id);
            }
            catch
            {
                exito = false;
                return exito;
            }

            return exito;
        }

        public List<Gato> MetodoActualizarRazaPorPosicion(int posicion, string nuevaRaza)
        {
            //Eliminar variable que no se usa
            //Cambiar tipo bool por Gato
            //Concluir metodo
            //coregido
           
            var listaDeRazas = ObtenerRazas();
            listaDeRazas[posicion].Raza = nuevaRaza;
            
            return listaDeRazas;
        }
    }
}