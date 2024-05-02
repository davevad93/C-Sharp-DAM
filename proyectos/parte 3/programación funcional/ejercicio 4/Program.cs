using System;
using System.Collections.Generic;
using System.Linq;

// DAVIDE PRESTI
// - Ejercicio 4 -
// Vamos ha realizar una serie de operaciones funcionales usando funciones-λ con el patrón Map – Filter – Fold (Select – Where – Aggregate en C#)

// Partiremos de la siguiente lista de números reales:

// List<double> reales = new List<double> 
// { 
// 	0.5, 1.6, 2.8, 3.9, 4.1, 5.2, 6.3, 7.4, 8.1, 9.2 
// };
// Vamos a realizar las siguientes operaciones:

// Mostrar la lista usando el método ForEach(Action<T> action) de lista. Pasando a la función-λ action, una clausura de la variable string texto, en la que iremos componiendo su contenido separado por un espacio en blanco.

// Cuenta aquellos elementos cuya parte decimal es menor que 0.5

// Map: Paso del valor real a su parte decimal. Ej: 2.8 → 0.8
// Filter: Filtro aquellas partes decimales que cumplen el predicado: d < 0.5
// Fold: Contar los elementos en la secuencia resultante.
// Calcular la suma de todos los valores de la secuencia cuya parte entera sea múltiplo de 3.

// Map: Mapea el valor real a un objeto anónimo con la parte entera y el propio valor real de la secuencia. Ej: 2.8 → new { e = 2, r = 2.8 }
// Filter: Filtro aquellas partes enteras que cumplen el predicado: o.e % 3 == 0
// Fold: Suma todos los o.r de la secuencia resultante.
// Calcular el máximo valor de la secuencia cuya parte decimal es mayor que 0.5

// Map: Mapea el valor real a un objeto anónimo con la parte decimal y el propio valor real de la secuencia. Ej: 2.8 → new { d = 0.8, r = 2.8 }
// Filter: Filtro aquellas partes decimales que cumplen el predicado: o.d > 0.5
// Fold: Me quedo con el máximo de todos los o.r de la secuencia resultante.
// Ampliación: Muestra aquellos elementos de la secuencia cuya parte entera es un valor primo.
// 💡 Idea: Seguramente has de hacer más de un Filter e incluso otro Filter dentro de uno de ellos. Además, para crear un predicado que me diga si un número primo de forma funcional (pero poco eficiente) puedes hacer lo siguiente ...

// Generar una secuencia entre 2 y la parte entera menos uno con Enumerable.Range()
// Filtrar aquellos valores divisibles por la parte entera.
// Preguntar si la secuencia resultante tiene 0 elementos.
// Una vez completadas todas las operaciones. Al ejecutar el programa la salida por pantalla del programa deberá ser ...

// Elementos: 0,5 1,6 2,8 3,9 4,1 5,2 6,3 7,4 8,1 9,2
// Número elementos con parte decimal < 0,5 = 6
// Suma elementos con parte entera múltiplo de 3 = 19,4
// Máximo cuya parte decimal > 0,5 = 3,9
// Elementos parte entera es primo: 2,8 3,9 5,2 7,4

namespace ejercicio4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> reales = new List<double> 
            {
                0.5, 1.6, 2.8, 3.9, 4.1, 5.2, 6.3, 7.4, 8.1, 9.2
            };

            string texto = "";
            reales.ForEach(n => texto += n.ToString() + " ");
            Console.WriteLine($"Elementos: {texto}");

            int contador = reales.Select(n => n - Math.Floor(n)).Where(n => n < 0.5).Count();
            Console.WriteLine($"Número elementos con parte decimal < 0,5 = {contador}");

            double suma = reales.Select(n => new {e = (int)Math.Floor(n), r = n})
                            .Where(n => n.e % 3 == 0)
                            .Aggregate(0.0, (s, n) => s + n.r);
            Console.WriteLine($"Suma elementos con parte entera múltiplo de 3 = {suma.ToString()}");

            double max = reales.Select(n => new {d = n - Math.Floor(n), r = n})
                            .Where(n => n.d > 0.5)
                            .Aggregate(Double.MinValue, (s, n) => Math.Max(s, n.r));
            Console.WriteLine($"Máximo cuya parte decimal > 0,5 = {max.ToString()}");

            var primos = reales.Select(Math.Floor)
                            .Distinct()
                            .Where(n => {if (n < 2) return false;
                             return !Enumerable.Range(2, (int)Math.Sqrt(n) - 1).Any(i => n % i == 0);})
                            .Join(reales, p => p, r => Math.Floor(r), (p, r) => r);
            Console.WriteLine($"Elementos parte entera es primo: {string.Join(" ", primos)}");
        }
    }
}