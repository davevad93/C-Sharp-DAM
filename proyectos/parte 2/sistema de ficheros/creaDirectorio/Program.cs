using System;
using System.IO;

// DAVIDE PRESTI
// - Ejercicio 3 -
// Vamos a crear algunos comandos similares a los del S.O., que nos ayuden a entender
// mejor el funcionamiento de las clases DirectoryInfo , FileInfo y sus homólogas de utilidad.
// Para ello deberemos crear distintos programas, de forma que cada uno haga una de las
// siguientes funciones. El nombre de cada proyecto será el nombre del comando y todos irán
// en una solución llamada ejercicio3 :

// 2. Comando creaDirectorio: Se le pasa una ruta y te crea un directorio y tendrás que
// controlar si se indica más de una entrada o capturar las excepciones de ruta inválida.

namespace creaDirectorio
{
    class Program
    {
        static void Main(string[] args)
        {
            string ruta = default;
            try
            {
                if (args.Length == 1) 
                {
                    ruta = args[0];   
                    Directory.CreateDirectory(ruta);
                    Console.WriteLine($"\nDirectorio creado con éxito {Directory.GetCreationTime(ruta)}.\n");                    
                }    
                else
                {
                    Console.WriteLine("\nSe puede crear sólo 1 directorio dentro de una ruta válida.\n");
                }
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("\nERROR! Ruta inexistente.\n");
            }
        }
    }
}