namespace WebApplication1
{
    public class MetodosGato : IMetodosGato
    {
        public List<IGato> ListaRaza { get; set; } = new List<IGato>();

        public List<string> ObtenerLista(List<IGato> _listaraza)
        {
            ListaRaza = _listaraza;
            var obtenerItemRazaDeLista = ListaRaza.Select(x => x.Raza).ToList();
            return obtenerItemRazaDeLista;
        }

        public List<string> MetodoAgregarRaza(string razaNueva, List<IGato> _listaraza)
        {

            ObtenerLista(_listaraza);
           
            ListaRaza.Add(new Gato() { Raza = razaNueva});
            var obtenerItemRazaDeLista = ListaRaza.Select(x => x.Raza).ToList();
            
            return obtenerItemRazaDeLista;
        }
        public List<string> MetodoActualizarRazaPorPosicion(string razaNueva, int id, List<IGato> _listaraza)
        {
            ObtenerLista(_listaraza);
            //busca coincidencias
            //var elementoRemplazar = ListaRaza.First(i => i.Id == id);
            ////devuelve el Id de la coincidencia 
            //var indexItem = ListaRaza.IndexOf(elementoRemplazar);
            
            var razaNuevaItem = new Gato() { Raza = razaNueva, Id = id };
            ListaRaza[id] = razaNuevaItem;
            var obtenerItemRazaDeLista = ListaRaza.Select(x => x.Raza).ToList();

            //ListaRaza.RemoveAt(id);
            //ListaRaza.Add(new Gato() { Raza = razaNueva, Id = id, });
            //var obtenerItemRazaDeLista = ListaRaza.Select(x => x.Raza).ToList();C

            return obtenerItemRazaDeLista;
        }

        public bool MetodoActualizarRazaPorNombre(string razaEnLista, string razaNueva, List<IGato> _listaraza)
        {
            var exito = true;

            ObtenerLista(_listaraza);
            
            try
            {
                //busca en la lista coincidencias 
                var elementoRemplazar = ListaRaza.First(i => i.Raza == razaEnLista);
                //devuelve la posicion del elemento con el que hay coincidencia 
                var id = ListaRaza.IndexOf(elementoRemplazar);
                //var intId = Int32.Parse(id.ToString());
                var razaNuevaItem = new Gato() { Raza = razaNueva, Id = id };
                //sustituye el elemento donde existe coincidencia "raza en lista" con el nuevo elemento que se indica en  "razaNuevaItem"
                ListaRaza[id] = razaNuevaItem;
            }
            catch
            {
                exito = false;
                return exito;
            }
            
            return exito;
        }

        public List<string> MetodoDeleteRazaPorPosicion(int id, List<IGato> _listaraza)
        {
            ObtenerLista(_listaraza);
           
            ListaRaza.RemoveAt(id);        
            var obtenerItemRazaDeLista = ListaRaza.Select(x => x.Raza).ToList();

            return obtenerItemRazaDeLista;    
        }

        public bool MetodoDeleteRazaPorNombre(string raza, List<IGato> _listaraza)
        {
            var exito = true;

            ObtenerLista(_listaraza);

            try
            {
                var elementoEliminar = ListaRaza.First(i => i.Raza == raza);
                var id = ListaRaza.IndexOf(elementoEliminar); 
                ListaRaza.RemoveAt(id);
            }
            catch
            {
                exito = false;
                return exito;
            }

            return exito;
        }
        //public bool MetodoDeleteRazaPorNombre(string raza, List<IGato> _listaraza)
        //{
        //    var exito = true;

        //    ObtenerLista(_listaraza);

        //    int posicion = ExtraerPosicionDeLista(raza, _listaraza);

        //    if (posicion == 4)
        //    {
        //        exito = false;
        //        return exito;
        //    }

        //    ListaRaza.RemoveAt(posicion);

        //    return exito;
        //}

        //public int ExtraerPosicionDeLista(string raza, List<IGato> _listaraza)
        //{
        //    var filtro = _listaraza.Where(x => x.Raza == raza).ToList();

        //    if (!filtro.Any())
        //    {
        //        return 4;
        //    }

        //    var listaRaza = ListaRaza.Select(x => x.Raza).ToList();
        //    int id = listaRaza.IndexOf(raza);

        //    return id;
        //}

        //public string ExtraerElementoDeLista(int id, List<string> _listaraza)
        //{
        //    string elemento = _listaraza[id].ToString();
        //    return elemento;
        //}
    }
}
