using System;
using System.IO;
using System.Text.RegularExpressions;

// DAVIDE PRESTI
// - Ejercicio 9 -
// Programa que muestre el/los número/os de línea/as que contengan una subcadena pedida
// al usuario en un fichero indicado.
// Además del número de línea, nos indicará el número de apariciones de la subcadena en
// dicha línea.
// Si no encuentra la subcadena en todo el fichero, nos mostrará un mensaje de "CADENA NO
// ENCONTRADA".
// Para hacer este programa crearemos una expresión regular a partir de la cadena que
// nosotros indiquemos, que será la que se busque con las líneas del fichero.

namespace ejercicio9
{
    class Program
    {
        public static string LeeRutaFichero()
        {
            Console.Write("Introduzca la ruta del fichero: ");
            return Console.ReadLine();
        }

        public static string LeePalabraFichero()
        {
            Console.Write("\nIntroduzca la palabra a buscar: ");
            return Console.ReadLine();
        }

        public static int NumeroDeApariciones(Regex cadena, string linea)
        {
            return cadena.Matches(linea).Count;
        }

        public static void MuestraBusqueda(string palabra, int numeroLinea, int apariciones)
        {
            Console.WriteLine($"\nPalabra: {palabra} \tLínea: {numeroLinea} \tApariciones: {apariciones}");
        }

        static void Main(string[] args)
        {
            string ruta = LeeRutaFichero();
            string cadena = LeePalabraFichero();     
            try
            {
                if (!File.Exists(ruta))
                {
                    Console.WriteLine($"Fichero {ruta} inexistente.");
                }

                Regex buscar = new Regex(cadena);
                int numeroLinea = 1;
                bool encontrado = false;
                using StreamReader sr = new StreamReader(ruta);

                while (!sr.EndOfStream)
                {
                    string linea = sr.ReadLine();
                    numeroLinea++;

                    if (NumeroDeApariciones(buscar, linea) > 0)
                    {
                        MuestraBusqueda(cadena, numeroLinea, NumeroDeApariciones(buscar, linea));
                        encontrado = true;
                    }
                }

                if (!encontrado)
                {
                    Console.WriteLine("CADENA NO ENCONTRADA.");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"ERROR! {e.Message}");
            }
        }
    }
}