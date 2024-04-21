using System;

// DAVIDE PRESTI 
// - Ejercicio 8 -

// Programa que obtenga el cociente y el resto de dos números enteros positivos mediante restas
// calcular n / 2 haga n -= 2 mientras n >= 2 y cuente el número de restas.

namespace ejercicio8
{
    class Program
    {
        static void Main(string[] args)
        {   
            string linea;
            int dividendo, divisor, cociente, resto;
            int contador = 0;
            int restoSecuencia = 0;

            Console.Write("\nIntroduzca un número: ");
            dividendo = int.Parse(Console.ReadLine());
            Console.Write("Introduzca otro número: ");
            divisor = int.Parse(Console.ReadLine());

            if (divisor > dividendo || divisor == 0)
            {
                linea = $"\nERROR! El segundo número no puede ser mayor que el primero " + 
                        $"y tampoco puede ser igual a 0.\n";
            }

            else
            {
                cociente = dividendo / divisor;
                resto = dividendo % divisor;
                linea = $"\nLa comprobación de {dividendo} / {divisor} es la siguiente: " +
                        $"El cociente es {cociente} y el resto es {resto}.";

                Console.WriteLine(linea);

                while (dividendo >= divisor )
                {
                    dividendo -= divisor;
                    contador++;
                }
            
                restoSecuencia = dividendo;
                linea = $"Haciendo restas sucesivas, el resto es {restoSecuencia}, " +
                        $"el coeficiente es {contador} y el número de restas que realiza es {contador}.\n";
            }
            Console.WriteLine(linea);
        }
    }
}