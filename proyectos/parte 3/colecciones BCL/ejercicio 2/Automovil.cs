// DAVIDE PRESTI
// - Ejercicio 2 -
// Crea una clase Automovil con los datos básicos de los automóviles (marca, modelo, cilindrada, año de fabricación, etc) y los métodos necesarios para poder usarla con comodidad.
// Crea una clase Program con una serie de métodos que nos permitan trabajar con una lista genérica de automóviles.
// Necesitaremos un Método AñadeAutomovil que a partir de una lista y un automóvil, añadirá este a la lista.
// EliminaAutomovil que eliminará el automóvil con el índice i que se haya pasado como argumento.
// Crea un método AutomovilesPorAñoFabricacion, que te permita encontrar en la lista los coches con una determinada fecha de fabricación y que retorne una nueva lista con esos datos.
// Otro método AutomovilesPorAñoFabricacionYColor que devuelva una sublista con los coches de la lista que sean de un determinado color y una fecha pasados ambos como parámetros.
// Método que permita mostrar el contenido de la lista.

namespace ejercicio2
{
    class Automovil 
    {
        public enum Color {Negro, Azul, Rojo, Blanco, Plata, Amarillo, Marron, Verde}
        public string Marca {get; set;}
        public string Modelo {get; set;}
        public int Cilindrada {get; set;}
        public int AñoFabricacion {get; set;}
        public Color ColorAuto {get; set;}

        public Automovil(string marca, string modelo, int cilindrada, int añoFabricacion, Color color) 
        {
            Marca = marca;
            Modelo = modelo;
            Cilindrada = cilindrada;
            AñoFabricacion = añoFabricacion;
            ColorAuto = color;
        }     
    }
}