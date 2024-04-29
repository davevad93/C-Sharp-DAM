using System;

// DAVIDE PRESTI
// - Ejercicio 4 -

// Partiendo del ejercicio anterior en C#, crea una clase Persona que tenga solo dos propiedades: Nombre y Edad.

// Comprueba si funcionan los métodos Mayor y Menor con ella, ¿qué ocurre?. Ahora haz que la clase derive de 
// IComparable<Persona> y de ICloneable y que invalide el ToString().

// Crea un programa que te permita saber, de dos objetos Persona distintos, cual es el mayor. Clona una persona y 
// prueba los clones con el método estático Menor

namespace ejercicio4
{
    class Program
    {
        static void Main(string[] args)
        {
            Persona p1 = new Persona("Ezio Auditore", 25);
            Persona p2 = new Persona("Altaïr Ibn-La'Ahad", 50);
            Console.WriteLine(Comparador<Persona>.Mayor(p1, p2));
            Console.WriteLine(Comparador<Persona>.Menor(p1, p2));
            Persona p3 = (Persona)p1.Clone();
            Console.WriteLine(Comparador<Persona>.Menor(p1, p3));
        }
    }
}