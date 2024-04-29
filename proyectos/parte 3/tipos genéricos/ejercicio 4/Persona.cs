// DAVIDE PRESTI
// - Ejercicio 4 -

// Partiendo del ejercicio anterior en C#, crea una clase Persona que tenga solo dos propiedades: Nombre y Edad.

// Comprueba si funcionan los métodos Mayor y Menor con ella, ¿qué ocurre?. Ahora haz que la clase derive de 
// IComparable<Persona> y de ICloneable y que invalide el ToString().

// Crea un programa que te permita saber, de dos objetos Persona distintos, cual es el mayor. Clona una persona y 
// prueba los clones con el método estático Menor

namespace ejercicio4
{
    class Persona : IComparable<Persona>, ICloneable
    {
        public string Nombre {get; set;}
        public int Edad {get; set;}

        public Persona(string nombre, int edad)
        {
            Nombre = nombre;
            Edad = edad;
        }

        public int CompareTo(Persona persona)
        {
            return this.Edad.CompareTo(persona.Edad);
        }

        public object Clone()
        {
            Persona persona = new Persona(this.Nombre, this.Edad);
            return persona;
        }

        public override string ToString()
        {
            string info = $"Nombre: {Nombre}\nEdad: {Edad}";
            return info;
        }
    }
}