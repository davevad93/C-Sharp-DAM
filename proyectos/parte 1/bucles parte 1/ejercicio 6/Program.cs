using System;

// DAVIDE PRESTI
// - Ejercicio 6 -

// Programa que lee una secuencia de números no nulos,
// terminada con la introducción de un 0, y muestra el mayor de la secuencia.

namespace ejercicio6
{
    class Program
    {
        static void Main(string[] args)
        {      
            int numero;
            int mayor = 0;
            string linea;
            
            do
            { 
                Console.WriteLine("Introduzca un número:");
                numero = int.Parse(Console.ReadLine());
                
                if (numero > mayor)
                {
                    mayor = numero;    
                }  
            }
            while (numero != 0);
            linea = $"\nEl número mayor de la secuencia es {mayor}.\n";
            Console.WriteLine(linea);
        }
    }
}