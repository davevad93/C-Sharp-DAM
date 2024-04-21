using System;

// DAVIDE PRESTI 
// - Ejercicio 10 -

// Programa que determina si dos números enteros positivos son amigos
// Dos números son amigos si la suma de los divisores del primer número excepto él mismo, 
// es igual al segundo numero, y viceversa. 
// Puedes saber un poco más de la historia de esta relación entre números leyendo la entrada en la Wikipedia.

namespace ejercicio10

{
    class Program
    {
        static void Main(string[] args)
        {
            string linea;
            int numero1, numero2, i;
            int sumaAmigo1 = 0;
            int sumaAmigo2 = 0;

            Console.Write("\nIntroduzca un número entero y positivo: ");
            numero1 = int.Parse(Console.ReadLine());
            Console.Write("\nIntroduzca otro número entero y positivo: ");
            numero2 = int.Parse(Console.ReadLine());
    
            for (i = 1; i < numero1; i++)
            {
                if (numero1 % i == 0)
                {
                    sumaAmigo1 += i;
                }
            }

            for (i = 1; i < numero2; i++)
            {
                if (numero2 % i == 0)
                {
                    sumaAmigo2 += i;
                }
            }

            if (numero1 <= 0 || numero2 <=0)
            {
                linea = ($"\nERROR! Los números introducidos no pueden ser menor o igual que 0.\n");
            }

            else if (sumaAmigo1 == numero2 && sumaAmigo2 == numero1)
            {
                linea = $"\nEl número {numero1} y el número {numero2} son números amigos.\n";
            }
            
            else
            {
                linea = $"\nEl número {numero1} y el número {numero2} no son números amigos.\n";
            }
            Console.WriteLine(linea);
        }
    }
}