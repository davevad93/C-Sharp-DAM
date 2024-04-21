using System;

// DAVIDE PRESTI
// - Ejercicio 8 -

// Un número se dice que es capicúa si leído de derecha a izquierda da el mismo resultado
// que leído de izquierda a derecha.
// Por ejemplo, los números 22, 343, 5665 o 12321 son capicúas.
// Elabora un programa que lea desde teclado un número entero mayor de 9 
// y devuelva si el número es capicúa o no.

namespace ejercicio8
{
    class Program
    {
        static void Main(string[] args)
        {
            int numero, n, resto, capicua = 0;
            string linea;
            Console.Write("\nIntroduzca un número mayor que 9: ");
            numero = int.Parse(Console.ReadLine());
            
            if (numero < 10)
            {
                linea = $"\nERROR! Introduzca un número mayor de 9.";
            }
            
            else 
            {
                n = numero;
                while (n != 0)
                {
                    resto = n % 10;
                    capicua = capicua * 10 + resto;
                    n = n / 10;
                }

                if (numero == capicua)
                {
                    linea = $"\n{numero} es un número capicúa.";
                }

                else
                {
                    linea = $"\n{numero} no es un número capicúa.";
                }
            }
            Console.WriteLine(linea);
        }
    }
}