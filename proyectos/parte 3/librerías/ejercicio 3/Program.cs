using System;
using Estadistica;

// DAVIDE PRESTI
// - Ejercicio 3 -
// Crea un proyecto con una referencia a la librería del ejercicio anterior, y que permita probar todos los métodos de 
// esta. Una posible solución podría ser:

// 3, 7, 5, 7, 4, 3
// Media 4,83
// Mediana 6
// Moda 3
// Rango 4

namespace ejercicio3
{
    class Program
    {
        static void Main(string[] args)
        {
            double moda;
            double[] numeros = {3, 7, 5, 7, 4, 3};
            Console.WriteLine(string.Join(", ", numeros));
            double media = Promedio.Media(numeros);
            Console.WriteLine($"Media: {media:F2}");
            double mayor = Promedio.Mayor(numeros);
            Console.WriteLine($"Mayor: {mayor}");
            double menor = Promedio.Menor(numeros);
            Console.WriteLine($"Menor: {menor}");
            double mediana = Promedio.Mediana(numeros);
            Console.WriteLine($"Mediana: {mediana}");
            double rango = Promedio.Rango(numeros);
            bool hayModa = Promedio.Moda(numeros, out moda);
            if (hayModa) Console.WriteLine($"Moda: {moda}"); 
            else Console.WriteLine("No hay moda.");
            Console.WriteLine($"Rango: {rango}"); 
        }
    }
}