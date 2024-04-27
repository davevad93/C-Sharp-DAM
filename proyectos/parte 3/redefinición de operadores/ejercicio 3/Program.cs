using System;

// DAVIDE PRESTI
// - Ejercicio 3 -
// Para cierta implementación que no viene al caso, el departamento de diseño ha detectado la necesidad de crear un nuevo tipo de números a los que ha denominado "números curiosos". Un número curioso se caracteriza por tres coordenadas reales.
// Sobre los números curiosos interesa realizar las siguientes operaciones:

// 1. Suma
// 2. Resta

// Crea la clase NumeroCurioso con los atributos, propiedades y métodos que creas necesarios para su correcta implementación y prueba.
// Redefine los operadores necesarios para poder realizar la suma y resta de dos números curiosos.

namespace ejercicio3
{
  class Program
    {
        static void Main(string[] args)
        {
            NumeroCurioso n1 = new NumeroCurioso(1, 0, 1);
            NumeroCurioso n2 = new NumeroCurioso(0, 1, 1);

            Console.WriteLine($"Número curioso 1: {n1}");
            Console.WriteLine($"Número curioso 2: {n2}");

            NumeroCurioso suma = n1 + n2;
            Console.WriteLine($"Suma: {suma}");

            NumeroCurioso resta = n1 - n2;
            Console.WriteLine($"Resta: {resta}");
        }
    }
}