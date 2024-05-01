// DAVIDE PRESTI
// - Ejercicio 4 -
// Vamos a crear un par de métodos extensores de la clase List<T> implementada por
// Microsoft en System.Collections.Generic .
// Para ello define el namespace System.Collections.Generic.ListExtensions y dentro de él
// crea las clases que estimes oportunas para que ...
// Tener un método extensor SecuenciaAleatoria que reciba el número de elementos N a
// generar y devuelva una lista de elementos del mismo tipo con N elementos de la lista
// original escogidos de forma aleatoria y no repetidos.
// Tener un método extensor SecuenciaAleatoriaConRepeticiones que reciba el número de
// elementos N a generar y devuelva lo mismo que el anterior pero admitiendo repeticiones.
// Prueba tus métodos extensores con el siguiente código ...
// try
// {
// List<int> numeros = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
// Console.WriteLine(string.Join(", ", numeros.SecuenciaAleatoria(5)));
// Console.WriteLine(string.Join(", ", numeros.SecuenciaAleatoriaConRepeticiones(5)));
// Console.WriteLine(string.Join(", ", numeros.SecuenciaAleatoriaConRepeticiones(15)));
// Console.WriteLine(string.Join(", ", numeros.SecuenciaAleatoria(15)));
// }
// catch (ListExtensionException e)
// {
// Console.WriteLine(e.Message);
// }
// También deberemos tener en cuenta que ...
// 1. No se deben repetir las secuencias.
// 2. No debes repetir código en la implementación de tus métodos extensores.
// 3. numeros.SecuenciaAleatoriaConRepeticiones(15) no debe producir excepciones aunque
// la lista de números sea menor que la nueva secuencia > porque admite repeticiones.
// 4. numeros.SecuenciaAleatoria(15) debe producir excepción porque tiene menos elementos
// en la secuencia a elegir que los solicitados.

namespace System.Collections.Generic.ListExtensions
{
    public class ListExtensionException : Exception
    {
        public ListExtensionException(string mensaje) : base(mensaje)
        {
        }
    }
}