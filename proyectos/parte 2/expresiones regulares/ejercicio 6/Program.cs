using System;
using System.Text.RegularExpressions;

// DAVIDE PRESTI
// - Ejercicio 6 -
// Programa que compruebe con una expresión regular, si un número introducido es un
// número complejo.
// 1. Para que hacer este ejercicio, deberías usar el siguiente la patrón para identificar un número real.
//    string patronReal = @"[+-]?((\d+)|(\d*[.,]\d+))([eE][+-]?\d+)?"; 
// 2. Un numero complejo en su forma binomial se representará como a + bi o a + bj
//    siendo a y b números reales.
// Ejemplos
// de de entrada de números reales correctos:
// -2,3 + 5e -2j
// 7i
// 2E+5 + 2,3i
// 3 - 5i
// ✋ Importante:
// Para ser considerado el ejercicio como correcto se debería dividir el patrón 
// en varias partes evitando repetir el patrón de número real del ejercicio 1.

namespace ejercicio6
{
    class Program
    {
        static bool EsComplejo(string cadena)
        {
            cadena = EliminaEspacios(cadena);
            if (cadena.Length == 0)
            {
                return false; 
            }
 
            string patronReal = @"[+-]?(\d+(?:(?:[.,]\d+)?(?:[eE][+-]\d+)?";
            string patronReal2 = @"[+-]))?(\d+(?:(?:[.,]\d+)?(?:[eE]";
            string patronImaginario = @"[+-]\d+(?:[.,]\d+)?)?)?)?[iIjJ]"; 
            string numeroComplejo = "^" + patronReal + patronReal2 + patronImaginario + "$";

            Regex complejo = new Regex(numeroComplejo);
            if (complejo.IsMatch(cadena))
            {
                return true;
            }  
            else
            {
                return false;
            }  
        }

        static string EliminaEspacios(string cadena)
        {
            Regex espacio = new Regex(@"\s+");
            cadena = espacio.Replace(cadena, "");
            return cadena;
        }
        
        static void Main(string[] args)
        {
            Console.Write("Introduzca un número real: ");
            string numero = Console.ReadLine();

            if (EsComplejo(numero))
            {
                Console.WriteLine($"\n{numero} es complejo.\n");
            }
            else
            {
                Console.WriteLine($"\n{numero} no es complejo.\n");
            }
        }
    }
}        