using System;

// DAVIDE PRESTI 
// - Ejercicio 13 - 

// Pide un número, por ejemplo el 4, y saca en pantalla 1223334444.
// Nota: Deber usar bucles for para hacerlo.

namespace ejercicio13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Introduzca un número: ");
            int numero = int.Parse(Console.ReadLine());
            int i, j;
                       
            for (i = 0; i <= numero; i++)
            {
                for (j = 0; j < i; j++)
                {
                    Console.Write(i);
                }      
            }              
        }
    }
}