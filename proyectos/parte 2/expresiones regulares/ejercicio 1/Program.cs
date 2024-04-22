using System;
using System.Text.RegularExpressions;

// DAVIDE PRESTI
// - Ejercicio 1 -
// Crea expresiones regulares para comprobar el formato de las siguientes entradas.
// 1. Una fecha larga. Formato válido DD<sep>MM<sep>AAAA
// <sep> → Separadores ‘ ‘, ‘/‘ o ‘-‘;
// Se permitirán separadores diferentes, en una misma fecha.
// 2. Una matrícula. Formatos válidos LL<sep>DDDD<sep>LL y DDDD<sep>LLL
// <sep> → Separadores ‘ ‘ o ‘-‘;
// 3. Un número real con exponente.
// Correctos: 12,34E12 → -, 34e-1 → 0,34E+22
// 📌 Nota: Comprobar sólo el formato y no la corrección. IMPORTANTE, no crear la expresión
// que solo sea válida para los ejemplos planteados.

namespace ejercicio1
{
    class Program
    {
        static void ValidaFormato(string patron, string texto)
        {            
            Console.Write(texto);
            string cadena = Console.ReadLine();
            
            Regex validar = new Regex(patron);          
            if (validar.IsMatch(cadena)) 
            {
                Console.WriteLine("\nEl formato es correcto.");
            }    
            else 
            {
                Console.WriteLine("\nEl formato es incorrecto.");
            }   
        }

        static void Main(string[] args)
        {
            string matriculaAntigua = @"([a-zA-Z]{2}[\s-]\d{4}[\s-][a-zA-Z]{2})";
            string matriculaNueva = @"(\d{4}[\s-][a-zA-Z]{3})";
            string patronMatricula = "^" + matriculaAntigua + "|" + matriculaNueva + "$";
            ValidaFormato(@"^(0[1-9]|[12][0-9]|3[01])[- /](0[1-9]|1[012])[- /](19|[2-9][0-9])\d\d$", "\nIntroduzca una fecha (DD-MM-AAAA): ");
            ValidaFormato(@"[+-]?((\d+)|(\d*[.,]\d+))([eE][+-]?\d+)?" ,"\nIntroduzca un número real con exponente: ");    
            ValidaFormato(patronMatricula,"\nIntroduzca una matrícula: ");  
        }
    }
}