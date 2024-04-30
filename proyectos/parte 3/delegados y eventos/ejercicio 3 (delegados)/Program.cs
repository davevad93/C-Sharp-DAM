using System;

// DAVIDE PRESTI
// - Ejercicio 3 (Delegados) -
// Crea una aplicación con un método estático genérico Mostrar, al que le pases una matriz del tipo T y la muestre
// con una correcta tabulación. Posteriormente, prueba este método con diferentes tipos.

// Posible ejemplo de una llamada con float y otra con string ...

// 3 4 5
// 2,4 4,4 5

// SAL AGUA AZUCAR VINO
// COLA CAFE ZUMO LECHE
// Crea un delegado predefinido genérico de la BCL para el método Mostrar y comprueba su funcionamiento.

namespace ejercicio3Delegados
{
    class Program
    {
        static void Mostrar<T>(T[,] matriz)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.Write($"{matriz[i, j]}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            float[,] matrizFloat = {{3, 4, 5}, {2.4f, 4.4f, 5}};
            Mostrar(matrizFloat);

            string[,] matrizString = {{"SAL", "AGUA", "AZUCAR", "VINO"}, {"COLA", "CAFE", "ZUMO", "LECHE"}};
            Mostrar(matrizString);

            int[,] matrizInt = {{1, 2, 3}, {4, 5, 6}};
            Mostrar(matrizInt);

            bool[,] matrizBool = {{true, false, true}, {false, true, false}};
            Mostrar(matrizBool);

            decimal[,] matrizDecimal = {{0.75m, 1.50m, 3.00m}, {2.10m, 4.20m, 8.40m}};
            Mostrar(matrizDecimal);

            Action<object[,]> delegadoPredefinido = Mostrar;
            delegadoPredefinido(matrizString);
        }
    }
}