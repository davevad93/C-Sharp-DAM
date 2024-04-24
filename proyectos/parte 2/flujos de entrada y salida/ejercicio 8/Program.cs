using System;
using System.IO;

// DAVIDE PRESTI
// - Ejercicio 8 -
// Programa que permita buscar una palabra en uno o más ficheros de texto (introducidos en la
// línea de comandos).
// Se necesitará un método BuscaEnFichero(string ruta, string palabra) , que extraerá las
// líneas del fichero y llamará a la función BuscaEnCadena(string cadena, string palabra) que
// comprobará si las cadenas son iguales.
// En la línea de comandos introducirás la palabra y los nombres de fichero a buscar y te
// mostrará un mensaje para cada fichero, en el que te indicará si ha sido encontrada en ese
// fichero.

namespace ejercicio8
{
    class Program
    {
        public static bool BuscaEnCadena(string cadena, string palabra)
        {
            if (cadena.IndexOf(palabra) > -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void BuscaEnFichero(string ruta, string cadena)
        {
            StreamReader sr = null;
            try
            {
                if (!File.Exists(ruta))
                {
                    Console.WriteLine($"Fichero {ruta} inexistente.");
                }
                else
                {
                    sr = new StreamReader(ruta);
                }

                string palabra;
                int numeroLinea = 1;

                while ((palabra = sr.ReadLine()) != null)
                {
                    numeroLinea++;
                    if (BuscaEnCadena(palabra, cadena))
                    {
                        Console.WriteLine($"{ruta} Se ha encontrado la palabra {palabra}.");
                    }
                    else
                    {
                        Console.WriteLine($"{ruta} No se han encontrado resultados de {cadena}.");
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"ERROR! {e.Message}");
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }
        }
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("ERROR! Parámetros incorrectos, la forma correcta es: <cadena> <ficheros>\n");
            }
            else
            {
                for (int i = 1; i < args.Length; i++)
                {
                    BuscaEnFichero(args[i], args[0]);
                }
            }
        }
    }
}