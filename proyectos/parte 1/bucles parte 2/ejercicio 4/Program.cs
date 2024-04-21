using System;

// DAVIDE PRESTI
// - Ejercicio 4 -

// Igual que el anterior pero para este otro triángulo.
// Un ejemplo de salida por pantalla puede ser el siguiente:
// 3
// 58
// 703
// 9258

// 💡 Tip: Fíjate que el primer número de cada fila sigue una cuenta creciente de números
// impares empezando en 3 y los números en la columna se incrementan de 3 en 3 a partir del
// primer número impar de la fila.
// Como sucedía en el ejercicio anterior, fíjate en las dos últimas filas, que cuando la cuenta
// supera 10 lo que realmente visualicemos es el resto (módulo) de dividir por 10 la cuanta que
// será un valor entre 0 y 9.

namespace ejercicio4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("\nIntroduzca el número de filas: ");
            int filas = int.Parse(Console.ReadLine());
            int columna = 1; 
            int i, j = 0;    
            
            for (i = 0; i < filas; ++i)
            {
                columna += 2;
                int valor;
                for ( j = 0; j <= i; ++j)
                {
                    valor = (columna + 3 * j) % 10;
                    Console.Write(valor);
                }
                Console.Write("\n");
            }
        }
    }    
}