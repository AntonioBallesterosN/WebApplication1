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
        public bool GetId(int id)
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
        }
        public bool MetodoAgregarRaza(string razaNueva)
        {
            
            var seCambio = true;
            var listaDeRazas = ObtenerRazas();
            listaDeRazas.Add(new Gato() { Raza = razaNueva, Id = 4});
            
            return seCambio;
        }

        public bool MetodoActualizarRazaPorNombre(string razaEnLista, string razaNueva)
        {
            var exito = true;
            var listaDeRazas = ObtenerRazas();
           
            try
            {
                var elementoRemplazar = listaDeRazas.First(i => i.Raza == razaEnLista);
                var id = listaDeRazas.IndexOf(elementoRemplazar);
                var razaNuevaItem = new Gato() { Raza = razaNueva, Id = id };
                
                listaDeRazas[id] = razaNuevaItem;
            }
            catch
            {
                exito = false;
                return exito;
            }

            return exito;
        }

        public bool MetodoDeleteRazaPorPosicion(int id)
        {
            var exito = true;
            var listaDeRazas = ObtenerRazas();
            listaDeRazas.RemoveAt(id);
            

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

        public bool MetodoActualizarRazaPorPosicion(int posicion, string nuevaRaza)
        {
            var exito = true;
            var listaDeRazas = ObtenerRazas();
           
            listaDeRazas[posicion].Raza = nuevaRaza;


            throw new NotImplementedException();
        }
    }
}