using System;
using ArbolGenealogico;

namespace ArbolGenealogicoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Arbol arbol = new Arbol();
            int opcion = 0;
            do
            {
                Console.WriteLine("\nGestión de Árbol Genealógico");
                Console.WriteLine("1. Crear el miembro raíz");
                Console.WriteLine("2. Insertar un nuevo miembro (agregar padre a un miembro)");
                Console.WriteLine("3. Recorrer árbol en preorden");
                Console.WriteLine("4. Encontrar padres de un miembro");
                Console.WriteLine("5. Salir");
                Console.Write("Selecciona una opción: ");
                opcion = Convert.ToInt32(Console.ReadLine());
                try
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.Write("Ingresa el nombre del miembro raíz: ");
                            string nombreRaiz = Console.ReadLine();
                            arbol.CrearRaiz(nombreRaiz);
                            Console.WriteLine("Raíz creada exitosamente.");
                            break;
                        case 2:
                            Console.Write("Ingresa el nombre del miembro al cual agregarle un padre: ");
                            string miembroBusqueda = Console.ReadLine();
                            Console.Write("Ingresa el nombre del nuevo miembro (el padre): ");
                            string nombreNuevo = Console.ReadLine();
                            arbol.InsertarMiembro(miembroBusqueda, nombreNuevo);
                            Console.WriteLine("Nuevo miembro agregado correctamente.");
                            break;
                        case 3:
                            Console.WriteLine("\nRecorrido en Preorden:");
                            if (arbol.Raiz != null)
                                arbol.PreOrden(arbol.Raiz, 0);
                            else
                                Console.WriteLine("El árbol está vacío.");
                            break;
                        case 4:
                            Console.Write("Ingresa el nombre del miembro del que deseas ver los padres: ");
                            string nombreBusqueda = Console.ReadLine();
                            var padres = arbol.ObtenerPadres(nombreBusqueda);
                            if (padres.Count == 0)
                                Console.WriteLine("Este miembro no tiene padres registrados en el árbol.");
                            else
                            {
                                Console.WriteLine("Padres de " + nombreBusqueda + ":");
                                foreach (string padre in padres)
                                    Console.WriteLine("- " + padre);
                            }
                            break;
                        case 5:
                            Console.WriteLine("Saliendo...");
                            break;
                        default:
                            Console.WriteLine("Opción inválida. Inténtalo de nuevo.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (opcion != 5);
        }
    }
}
