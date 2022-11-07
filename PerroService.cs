namespace WebApplication1
{
    public class PerroService: IPerroService
    {
        public List<Perro> ObtenerRazas()
        {
            var perros = new List<Perro>()
            {
                new Perro {
                    Raza = "SharPei"
                    , Id = 0
                },
                new Perro {
                    Raza = "Pug"
                    , Id = 1
                },
                new Perro {
                    Raza = "Chihuahua"
                    ,Id = 2
                },
                new Perro {
                    Raza = "Xolo"
                    ,Id = 3
                }
            };

            return perros;
        }

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
        }

        public bool MetodoAgregarRaza(string razaNueva)
        {
            var seCambio = true;
            var listaDeRazas = ObtenerRazas();
            listaDeRazas.Add(new Perro() { Raza = razaNueva, Id = 4 });

            return seCambio;
        }

        public bool MetodoActualizarRazaPorNombre(string razaEnLista, string nuevaRaza)
        {
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

        public List<Perro> MetodoActualizarRazaPorPosicion(int posicion, string nuevaRaza)
        {
            var listaDeRazas = ObtenerRazas();
            listaDeRazas[posicion].Raza = nuevaRaza;

            return listaDeRazas;
        }
    }
}
