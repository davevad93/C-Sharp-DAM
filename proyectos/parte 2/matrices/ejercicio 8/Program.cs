using System;

// DAVIDE PRESTI
// - Ejercicio 8 -
// Realiza un programa para crear un array de array de arrays de enteros.
// Para ello deberás crear una array de dos elementos, donde cada elemento será una tabla
// dentada de enteros.
// El programa pedirá cuantas filas tiene y el número de elementos de cada fila, para cada una de
// las tablas dentadas.
// Reservará la memoria para cada una y rellenará la fila con los elementos generados de forma
// aleatoria.
// Posteriormente se mostrará el array de dos matrices dentadas de la siguiente forma:
// 1,2,3,4 13,14,15,16
// 5,6,7 17,18,19,20
// 9,10,11,12 21,22
// 👉Pista: La tabla se creará de la siguiente manera int[][][] m = new int[2][][]. Recuerda que las
// tablas se dimensionan con la palabra reservada new, y deberás redimensionar tanto, el número de
// filas de cada tabla como el número de columnas que tiene cada fila.

namespace ejercicio8
{
    class Program
    {
        static int GeneraNumeroAleatorio()
        {
            int numeroAleatorio = new Random().Next(0, 100);
            return numeroAleatorio;
        }

        static void RellenaFilas(int[][][] arrayTriple)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < arrayTriple[i].Length; j++)
                {
                    for (int k = 0; k < arrayTriple[i][j].Length; k++)
                    {
                        int numeroAleatorio = GeneraNumeroAleatorio();
                        arrayTriple[i][j][k] = numeroAleatorio;
                    }
                }
            }
        }

        static void RedimensionaColumnasArray(int[][][] arrayTriple)
        {
            for (int i = 0; i < arrayTriple.Length; i++)

                for (int j = 0; j < arrayTriple[i].Length; j++)
                {
                    Console.Write($"\nIntroduzca el número de columnas para la fila {j} de la tabla {i}: ");
                    int columna = int.Parse(Console.ReadLine());
                    arrayTriple[i][j] = new int[columna];
                }
        }

        static void PideFilas(int[][][] arrayTriple)
        {
            for (int i = 0; i < 2; i++)
            {
                Console.Write($"\nIntroduzca el número de filas de la tabla dentada {i}: ");
                int filas = int.Parse(Console.ReadLine());
                arrayTriple[i] = new int[filas][];
            }
        }

        static void ImprimePosicion(in int valor, in int i, in int j, in int k, in int tamañoMaximoFila)
        {
            int matriz = 0;
            const int MAXIMO_DE_DIGITOS = 3;
            int columna = k * MAXIMO_DE_DIGITOS;
            matriz = tamañoMaximoFila * (MAXIMO_DE_DIGITOS + 1) * i;
            Console.SetCursorPosition(columna + matriz, j);
            Console.Write($"{valor, MAXIMO_DE_DIGITOS:D}\n");
        }

        static void MuestraTabla(int[][][] arrayTripleVacio)
        {
            Console.Clear();
            const int TAMAÑO_MAXIMO_FILA = 6;

            for (int i = 0; i < arrayTripleVacio.Length; i++)
            {
                for (int j = 0; j < arrayTripleVacio[i].Length; j++)
                {
                    for (int k = 0; k < arrayTripleVacio[i][j].Length; k++)
                    {
                        ImprimePosicion(arrayTripleVacio[i][j][k], i, j, k, TAMAÑO_MAXIMO_FILA);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            int[][][] arrayTripleVacio = new int[2][][];
            PideFilas(arrayTripleVacio);
            RedimensionaColumnasArray(arrayTripleVacio);
            RellenaFilas(arrayTripleVacio);
            MuestraTabla(arrayTripleVacio);
        }
    }
}   