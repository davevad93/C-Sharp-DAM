using System;

// DAVIDE PRESTI
// - Ejercicio 2 (Delegados) -
// Crea un tipo delegado denominado Infinitivo para métodos que no reciban, ni devuelvan nada. Define ahora 
// los métodos Ser, Correr, Ver, Pensar, Comer los cuales mostrarán por consola los infinitivos en inglés de dichos 
// verbos.

// Crea un programa principal donde se instancie un objeto del delegado definido y …

// 1. Le asociemos con el operador += los métodos Ser, Correr y Ver y realicemos una llamada al delegado, para 
// que se llamen los tres métodos de forma consecutiva.
// 2. Desasocia ahora con el operador -= los métodos Ser y Ver y asocia Pensar y Comer y vuelva ha hacer una 
// llamada.

namespace ejercicio2Delegados
{
    delegate void Infinitivo();

    class Program
    {
        static void Ser()
        {
            Console.Write("To be ");
        }

        static void Correr()
        {
            Console.Write("To run ");
        }

        static void Ver()
        {
            Console.Write("To see ");
        }

        static void Pensar()
        {
            Console.Write("To think ");
        }

        static void Comer()
        {
            Console.Write("To eat ");
        }
        
        static void Main(string[] args)
        {
            Infinitivo Verbo = null;
            Verbo += Ser;
            Verbo += Correr;
            Verbo += Ver;
            Verbo();
            Console.WriteLine();

            Verbo -= Ser;
            Verbo -= Ver;
            Verbo += Pensar;
            Verbo += Comer;
            Verbo();
        }
    }
}