using System;

// DAVIDE PRESTI
// - Ejercicio 7 -

// Escribe un programa que genere la secuencia de números:
// 1, 2, 1, 2, 3, 1, 2, 3, 4, 1, 2, 3, 4, 5, ..., 1, 2, 3, ... N

namespace ejercicio7
{
    class Program
    {
        static void Main(string[] args)
        {
            int numero;
            int i, j = 0;
            string linea;
            
            do
            {
                Console.Write("\nIntroduzca un número: ");
                numero = int.Parse(Console.ReadLine()); 

                for (i = 1; i < numero; i++)
                {
                    int secuencia;
                    for (j = 0; j <= i; j++)
                    {
                        secuencia = 1 + (j);
                        linea = $"{secuencia}";
                        Console.Write($"{linea}, "); 
                    }  
                }
            }
            while(numero != 0 || numero != 1);
        }
    }
}