using System;
using System.IO;

// DAVIDE PRESTI
// - Ejercicio 3 -
// Vamos a crear algunos comandos similares a los del S.O., que nos ayuden a entender
// mejor el funcionamiento de las clases DirectoryInfo , FileInfo y sus homólogas de utilidad.
// Para ello deberemos crear distintos programas, de forma que cada uno haga una de las
// siguientes funciones. El nombre de cada proyecto será el nombre del comando y todos irán
// en una solución llamada ejercicio3 :

// 5. Comando copiaFicheros: Se le pasa dos rutas:
// 1. La primera de un directorio válido.
// 2. la segunda de un directorio que no tiene porque existir.
// El comando se encargará de copiar todos los ficheros que hay en la primera ruta a la
// segunda, creando la carpeta si fuera necesario. Además, deberás controlar las posibles
// excepciones.
// Este comando podrá, además, ejecutarse con la opción de añadir un filtro a la copia (solo
// se copiarán los archivos que cumplan el filtro, eso lo podemos hacer con la sobrecarga
// del método EnumerateFile ).
// Ejemplo del comando para copiar los ficheros que contengan en su nombre windows,
// desde la carpeta logs a la carpeta copia:
// copiaFicheros c:\logs c:\copia *windows*
// 📌 Nota: La ejecución y el paso de información al programa se realizará a través de la línea
// de comandos.
// La explicación está en el primer ejercicio del tema anterior de excepciones.

namespace copiaFicheros
{
    class Program
    {
        private static void CopiaFicheros(string destino, FileSystemInfo[] ficheros)
        {
            foreach (FileSystemInfo fichero in ficheros)
            {
                Console.WriteLine(fichero.Attributes);
                string origen = fichero.FullName;
                string nombreFichero = Path.GetFileName(origen);
                string destinoFichero = Path.Combine(destino, nombreFichero);
                File.Copy(origen, destinoFichero, true);
                Console.WriteLine($"\nRealizando copia de {origen} a {destino}...\n");
            }
        }
        
        static void Main(string[] args)
        {
            string rutaOrigen = default;
            string rutaDestino = default;
            try
            {
                if (args.Length == 2)
                {
                    rutaOrigen = args[0];
                    rutaDestino = args[1];
                    DirectoryInfo contenidoCarpeta = new DirectoryInfo(rutaOrigen);
                    DirectoryInfo carpetaDestino = new DirectoryInfo(rutaDestino);
                    
                    if (!carpetaDestino.Exists)
                    {
                        carpetaDestino.Create();
                    }

                    FileSystemInfo[] ficheros = contenidoCarpeta.GetFileSystemInfos();
                    CopiaFicheros(rutaDestino, ficheros);
                    Console.WriteLine("\nCopia realizada con éxito.\n");
                }
                else
                {
                    Console.WriteLine("\nDebe introducir una ruta de origen y otra de destino para poder copiar los ficheros.\n");
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