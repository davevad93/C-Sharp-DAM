// DAVIDE PRESTI
// - Ejercicio 4 -

// Partiendo del ejercicio anterior en C#, crea una clase Persona que tenga solo dos propiedades: Nombre y Edad.

// Comprueba si funcionan los métodos Mayor y Menor con ella, ¿qué ocurre?. Ahora haz que la clase derive de 
// IComparable<Persona> y de ICloneable y que invalide el ToString().

// Crea un programa que te permita saber, de dos objetos Persona distintos, cual es el mayor. Clona una persona y 
// prueba los clones con el método estático Menor

namespace ejercicio4
{
    static class Comparador<T> where T : IComparable<T>
    {
        public static bool Mayor(T p1, T p2)
        {
            return (p1.CompareTo(p2) > 0);
        }

        public static bool Menor(T p1, T p2)
        {
            return (p1.CompareTo(p2) < 0);
        }
    }
}