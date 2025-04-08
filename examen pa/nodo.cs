using System.Collections.Generic;

namespace ArbolGenealogico
{
    public class Nodo
    {
        public string Nombre { get; set; }
        public List<Nodo> Padres { get; set; }

        public Nodo(string nombre)
        {
            Nombre = nombre;
            Padres = new List<Nodo>();
        }
    }
}
