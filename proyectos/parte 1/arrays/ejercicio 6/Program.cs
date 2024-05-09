using System;

// DAVIDE PRESTI
// - Ejercicio 6 -

// Crea un array de 10 elementos, visualiza el elemento mayor de la serie y la posición que
// ocupa. Si hay varios iguales, sólo el primero.

namespace ejercicio6
{
    class Program
    {
        static int[] CreaArray(int tamaño)
        {
            int[] array = new int[tamaño];

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"Introduzca un valor [{i}]: ");
                array[i] = int.Parse(Console.ReadLine());
            }
            return array;
        }

        static void VisualizaArray(int[] array)
        {
            Console.Write("\nLos valores del array son: ");
            foreach (var elemento in array)
            {
                Console.Write(elemento + ", ");
            }      
        }

        static (int, int) VisualizaMayorYPosicion(int[] array)
        {
            int mayor = 0;
            int posicion = 0;
            
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > mayor)
                {
                    mayor = array[i];
                    posicion = i;
                }
            }
            Console.WriteLine($"\n\nValor mayor: {mayor}\nPosición: {posicion}\n");
            return (mayor, posicion);  
        }

        static void Main(string[] args)
        {
            int[] array = CreaArray(10);
            VisualizaArray(array);
            VisualizaMayorYPosicion(array);           
        }
    }
}