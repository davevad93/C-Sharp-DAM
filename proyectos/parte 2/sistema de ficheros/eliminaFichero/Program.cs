using System;
using System.IO;

// DAVIDE PRESTI
// - Ejercicio 3 -
// Vamos a crear algunos comandos similares a los del S.O., que nos ayuden a entender
// mejor el funcionamiento de las clases DirectoryInfo , FileInfo y sus homólogas de utilidad.
// Para ello deberemos crear distintos programas, de forma que cada uno haga una de las
// siguientes funciones. El nombre de cada proyecto será el nombre del comando y todos irán
// en una solución llamada ejercicio3 :

// 4. Comando eliminaFichero: Se le pasa una ruta y elimina un fichero y tendrás que
// controlar si se indica más de una entrada o capturar las excepciones de ruta inválida.

namespace eliminaFichero
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
                    File.Delete(ruta);
                    Console.WriteLine("\nFichero eliminado con éxito.\n");
                }
                else
                {
                    Console.WriteLine("\nSe puede eliminar sólo 1 fichero dentro de una ruta válida.\n");
                }                               
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("\nERROR! Ruta inexistente.\n");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("\nERROR! Fichero inexistente.\n");
            }
        }
    }
}