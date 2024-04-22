// DAVIDE PRESTI
// - Ejercicio 7 -
// Debes definir un tipo valor que represente un Naipe de la baraja Española de 48 cartas. 
// El tipo estará compuesto por dos miembros: un valor y un palo, 
// este último sera de tipo enumerado con los siguientes valores posibles: Oros, Copas, Bastos, Espada.
// Crea un método en la clase principal que utilizando el tipo Naipe nos devuelva una baraja con las 48 cartas, usa una matriz Naipe[,] baraja= new Naipe[4,12] e inicialízala suponiendo que cada fila representa un palo.
// Crea un método que nos mezcle la baraja para que queden sus cartas desordenadas.
// Crea un programa que muestre el resultado de la utilización de los métodos anteriores.
// 📌 Nota: Vuelve a repasar los apuntes donde se explica la creación del Tipo Valor 
// y sigue las normas que se explican para este tipo.

namespace ejercicio7
{
  struct Naipe
    {
        public readonly Palo Palos;
        public readonly int Valor;
        
        public Naipe(Palo palos, int valor)
        {
            Valor = valor;
            Palos = palos;
        }         
    }
}