using System;

// DAVIDE PRESTI
// - Ejercicio 8 -

// Implementa un programa en C#, que dado un número entero sin signo introducido por
// teclado, me diga si es capicúa. Un ejemplo de ejecución sería...
// Número: 1234321
// Es capicúa.
// Nota: Puedes usar el siguiente código para leer un número en forma de array de caracteres.
// char[] numero = Console.ReadLine().ToCharArray();


namespace ejercicio8
{
    class Program
    {
        static int[] CreaArray(int tamaño)
        {
            int[] array = new int[tamaño];

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"Introduzca el valor [{i}]: ");
                array[i] = int.Parse(Console.ReadLine());
            }
            return array;
        }

        static void VisualizaArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i].ToString());
            }
        }        

        static bool CompruebaSiEsCapicua(int[] array)
        {
            bool capicua = true;
            int i = 0;
            int j = array.Length - 1;
            
            while (i <= j && capicua)
            {
                capicua = (array[i++] == array[j--]);
            }
            return capicua;
        }

        static void Main(string[] args)
        {
            Console.Write("\nIntroduzca el tamaño del array: ");
            int tamaño = int.Parse(Console.ReadLine());
            int[] array = CreaArray(tamaño);
            
            if (CompruebaSiEsCapicua(array))
            {
                Console.Write("\nNúmero: ");
                VisualizaArray(array);
                Console.Write("\nEs capicúa.\n\n");
            }
            else
            {
                Console.Write("\nNúmero: ");
                VisualizaArray(array);
                Console.Write("\nNo es capicúa.\n\n");
            }
        }
    }
}