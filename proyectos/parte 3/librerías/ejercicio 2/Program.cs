using System;

// DAVIDE PRESTI
// - Ejercicio 2 -
// En este ejercicio vas a crear una librería que podrá ser usada para la realización de cálculos estadísticos. Para 
// ello tendrás que crear una clase de utilidad Promedio dentro del espacio de nombres Estadistica, con los 
// siguientes métodos de clase:

// 1. Media, Mayor, Menor, Rango, Mediana: a todos estos les llegará un array de doubles y devolverán un double 
//    con el resultado de la operación aplicada, dependiendo del método. Consultar en Internet como se hacen los 
//    distintos cálculos estadísticos.
// 2. Moda: método al que le llega el array de doubles y un parámetro de salida moda, para sacar el resultado. 
//    Además el método también indicará si hay o no moda (puede ser que no exista una moda en una serie de 
//    números), mediante la devolución de un boolean.

// Nota: Para crear el archivo .dll tendrás que compilar el proyecto con dotnet build

namespace Estadistica
{
    public class Promedio
    {
        public static double Media(double[] numeros)
        {
            double suma = 0;
            foreach (double numero in numeros)
            {
                suma += numero;
            }
            return suma / numeros.Length;
        }

        public static double Mayor(double[] numeros)
        {
            double mayor = numeros[0];
            foreach (double numero in numeros)
            {
                if (numero > mayor)
                {
                    mayor = numero;
                }
            }
            return mayor;
        }

        public static double Menor(double[] numeros)
        {
            double menor = numeros[0];
            foreach (double numero in numeros)
            {
                if (numero < menor)
                {
                    menor = numero;
                }
            }
            return menor;
        }

        public static double Rango(double[] numeros)
        {
            return Mayor(numeros) - Menor(numeros);
        }

        public static double Mediana(double[] numeros)
        {
            int cantidadNum = numeros.Length;
            int mitad = cantidadNum / 2;
            Array.Sort(numeros);

            if (cantidadNum % 2 == 0)
            {
                return (numeros[mitad - 1] + numeros[mitad]) / 2;
            }
            else
            {
                return numeros[mitad];
            }
        }

        public static bool Moda(double[] numeros, out double moda)
        {
            int reiteracion = 0;
            moda = numeros[0];
            for (int i = 0; i < numeros.Length; i++)
            {
                int contador = 0;
                for (int j = i + 1; j < numeros.Length; j++)
                {
                    if (numeros[i] == numeros[j])
                    {
                        contador++;
                    } 
                }
                if (contador > reiteracion)
                {
                    reiteracion = contador;
                    moda = numeros[i];
                }
            }
            if (reiteracion == 0)
            {
                return false;
            } 
            else
            {
                return true;
            } 
        }

        static void Main(string[] args)
        {
            ;
        }
    }
}