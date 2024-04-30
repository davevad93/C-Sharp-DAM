using System;
using System.Collections.Generic;

// DAVIDE PRESTI
// - Ejercicio 2 -
// Crea una clase Automovil con los datos básicos de los automóviles (marca, modelo, cilindrada, año de fabricación, etc) y los métodos necesarios para poder usarla con comodidad.
// Crea una clase Program con una serie de métodos que nos permitan trabajar con una lista genérica de automóviles.
// Necesitaremos un Método AñadeAutomovil que a partir de una lista y un automóvil, añadirá este a la lista.
// EliminaAutomovil que eliminará el automóvil con el índice i que se haya pasado como argumento.
// Crea un método AutomovilesPorAñoFabricacion, que te permita encontrar en la lista los coches con una determinada fecha de fabricación y que retorne una nueva lista con esos datos.
// Otro método AutomovilesPorAñoFabricacionYColor que devuelva una sublista con los coches de la lista que sean de un determinado color y una fecha pasados ambos como parámetros.
// Método que permita mostrar el contenido de la lista.

namespace ejercicio2
{
    public class Program 
    {
        static void AñadeAutomovil(List<Automovil> listaAutos, Automovil automovil) 
        {
            listaAutos.Add(automovil);
        }

        static void EliminaAutomovil(List<Automovil> listaAutos, int i) 
        {
            Console.WriteLine($"Eliminando de la lista el automóvil en el índice {i}...\n");
            listaAutos.RemoveAt(i);
        }
        static List<Automovil> AutomovilesPorAñoFabricacion(List<Automovil> listaAutos, int añoFabricacion) 
        {
            List<Automovil> lista = new List<Automovil>();
            foreach (Automovil automovil in listaAutos) 
            {
                if (automovil.AñoFabricacion == añoFabricacion) 
                {
                    lista.Add(automovil);
                }
            }
            return lista;
        }

        static List<Automovil> AutomovilesPorAñoFabricacionYColor(List<Automovil> listaAutos, int añoFabricacion, Automovil.Color color) 
        {
            List<Automovil> lista = new List<Automovil>();
            foreach (Automovil automovil in listaAutos) 
            {
                if (automovil.AñoFabricacion == añoFabricacion && automovil.ColorAuto == color) 
                {
                    lista.Add(automovil);
                }
            }
            return lista;
        }

        static void MuestraAutomoviles(List<Automovil> listaAutos) 
        {
            foreach (Automovil automovil in listaAutos) 
            {
                Console.WriteLine($"Marca: {automovil.Marca}");
                Console.WriteLine($"Modelo: {automovil.Modelo}");
                Console.WriteLine($"Cilindrada: {automovil.Cilindrada}");
                Console.WriteLine($"Año de fabricación: {automovil.AñoFabricacion}");
                Console.WriteLine($"Color: {automovil.ColorAuto}");
                Console.WriteLine();
            }
        }

        static void Main(string[] args) 
        {
            try
            {
                List<Automovil> listaAutos = new List<Automovil>
                {
                    new Automovil("Alfa Romeo", "Giulia", 2100, 2004, Automovil.Color.Negro),
                    new Automovil("Fiat", "Panda 4x4", 1250, 2010, Automovil.Color.Azul),
                    new Automovil("Ferrari", "Testarossa Coupe", 3800, 1984, Automovil.Color.Rojo),
                    new Automovil("Ford", "Mustang", 3500, 1990, Automovil.Color.Blanco),
                    new Automovil("Mercedes-Benz", "C-2000", 2200, 2000, Automovil.Color.Plata),
                    new Automovil("Chevrolet", "C-20", 1500, 1995, Automovil.Color.Amarillo),
                    new Automovil("Seat", "Ibiza 2000", 1400, 2002, Automovil.Color.Negro)
                };
                Console.WriteLine("\nLISTA DE AUTOMÓVILES:\n");
                MuestraAutomoviles(listaAutos);

                AñadeAutomovil(listaAutos, new Automovil("Renault", "R8", 1100, 1972, Automovil.Color.Marron));
                AñadeAutomovil(listaAutos, new Automovil("Peugeot", "104", 1000, 1988, Automovil.Color.Verde));
                Console.WriteLine("NUEVA LISTA DE AUTOMÓVILES:\n");
                MuestraAutomoviles(listaAutos);

                EliminaAutomovil(listaAutos, 2);
                Console.WriteLine("LISTA DE AUTOMÓVILES ACTUALIZADA:\n");
                MuestraAutomoviles(listaAutos);

                Console.WriteLine("LISTA DE AUTOMÓVILES DE LOS AÑOS 90:\n");
                MuestraAutomoviles(AutomovilesPorAñoFabricacion(listaAutos, 1990));
                MuestraAutomoviles(AutomovilesPorAñoFabricacion(listaAutos, 1995));

                Console.WriteLine("LISTA DE AUTOMÓVILES DE LOS AÑOS 2000 Y DE COLOR NEGRO:\n");
                MuestraAutomoviles(AutomovilesPorAñoFabricacionYColor(listaAutos, 2002, Automovil.Color.Negro));
                MuestraAutomoviles(AutomovilesPorAñoFabricacionYColor(listaAutos, 2004, Automovil.Color.Negro));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }        
    }
}