using System;

// DAVIDE PRESTI  
// - Ejercicio 7 -

// Gestión de un hotel

// Se pedirá el número de noches y si quieren habitación individual ('I') o habitación doble ('D').
// Si el número de noches es mayor de 2 y la habitación es individual cobraremos 25€ 
// pero si la habitación es doble cobraremos 40€.
// Si el número de noches es menor o igual a 2 y la habitación individual cobraremos 27€, 
// pero si la habitación es doble cobraremos 44€.

// Nota: Realiza el ejercicio con switch - when 

namespace ejercicio7
{
    class Program
    {
        static void Main(string[] args)
        {   
            Console.Write("Cuántas noches quiere alojarse en el hotel? ");
            int noches = int.Parse(Console.ReadLine());
            Console.Write("\nPuede elegir entre una habitación doble pulsando la tecla \"D\"" + 
                          "\no una habitación individual pulsando la tecla \"I\": ");
            string habitacion = Console.ReadLine();
                      
            switch(habitacion.ToUpper())
            {
                case "I" when noches <= 2:
                    Console.WriteLine("\nEl precio de la habitación es de 27 euros por noche.");
                    break; 

                case "I" when noches > 2:
                    Console.WriteLine("\nEl precio de la habitación es de 25 euros por noche."); 
                    break;

                case "D" when noches <= 2:
                    Console.WriteLine("\nEl precio de la habitación es de 44 euros por noche."); 
                    break;

                case "D" when noches > 2:
                    Console.WriteLine("\nEl precio de la habitación es de 40 euros por noche."); 
                    break;

                default:
                    Console.WriteLine("\nERROR!");
                    break;
            }           
        }
    }
}