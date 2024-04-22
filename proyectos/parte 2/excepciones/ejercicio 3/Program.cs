using System;

// DAVIDE PRESTI
// - Ejercicio 3 -
// Modifica el programa anterior para crear nuestro propio tipo de excepción derivada de
// Exception . La excepción se llamará ParametroNoValidoException , y le definiremos 2
// constructores:
// 1. Vacío.
// 2. Pasándole el mensaje de error que a su vez pasará a la clase base.
// Deberás lanzar esta excepción en lugar de la escogida en el punto anterior. La capturarás
// donde capturabas la anterior.

namespace ejercicio3
{
    class ParametroNoValidoException : Exception
    {
        public ParametroNoValidoException()
        {
        }

        public ParametroNoValidoException(string message) : base(message)
        {
        }
    }
    class Program
    {
        static double LogaritmoBase10(double n)
        {
            if (n <= 0)
            {
                throw new ParametroNoValidoException($"\nNo se puede calcular el logaritmo de un número menor o igual a cero.\n");
            }
            return Math.Log10(n);
        }

        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 1)
                {
                    double valor = double.Parse(args[0]);
                    Console.WriteLine($"\nEl logaritmo de {valor} en base 10 es: {LogaritmoBase10(valor)}\n");
                }
                else
                {
                    Console.WriteLine($"\nERROR! El programa solo admite un argumento.\n");
                }
                    
            }
            catch (FormatException)
            {
                Console.WriteLine($"\nERROR! Parámetro introducido {args[0]} inválido.\n");
            }
            catch (ParametroNoValidoException e)
            {
                Console.WriteLine($"\nERROR! {e.Message}\n");
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nERROR! {e.Message}\n");
            }
        }
    }
}