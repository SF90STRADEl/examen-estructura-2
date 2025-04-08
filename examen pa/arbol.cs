using System;
using System.Collections.Generic;

namespace ArbolGenealogico
{
    public class Arbol
    {
        public Nodo Raiz { get; set; }

        public Arbol()
        {
            Raiz = null;
        }

        public void CrearRaiz(string nombre)
        {
            if (Raiz == null)
                Raiz = new Nodo(nombre);
            else
                throw new InvalidOperationException("La raíz ya existe.");
        }

        public Nodo BuscarNodo(Nodo nodo, string nombre)
        {
            if (nodo == null)
                return null;
            if (nodo.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase))
                return nodo;
            foreach (Nodo padre in nodo.Padres)
            {
                Nodo resultado = BuscarNodo(padre, nombre);
                if (resultado != null)
                    return resultado;
            }
            return null;
        }

        public void InsertarMiembro(string nombreBusqueda, string nombreNuevo)
        {
            if (Raiz == null)
                throw new InvalidOperationException("El árbol está vacío.");
            Nodo nodoBusqueda = BuscarNodo(Raiz, nombreBusqueda);
            if (nodoBusqueda == null)
                throw new Exception("El miembro no fue encontrado en el árbol.");
            Nodo nuevoNodo = new Nodo(nombreNuevo);
            nodoBusqueda.Padres.Add(nuevoNodo);
        }

        public void PreOrden(Nodo nodo, int nivel)
        {
            if (nodo == null)
                return;
            Console.WriteLine(new string(' ', nivel * 4) + nodo.Nombre);
            foreach (Nodo padre in nodo.Padres)
                PreOrden(padre, nivel + 1);
        }

        public List<string> ObtenerPadres(string nombre)
        {
            if (Raiz == null)
                throw new InvalidOperationException("El árbol está vacío.");
            Nodo nodoBusqueda = BuscarNodo(Raiz, nombre);
            if (nodoBusqueda == null)
                throw new Exception("El miembro no fue encontrado en el árbol.");
            List<string> padres = new List<string>();
            foreach (Nodo padre in nodoBusqueda.Padres)
                padres.Add(padre.Nombre);
            return padres;
        }
    }
}
