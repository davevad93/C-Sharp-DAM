using System;

// DAVIDE PRESTI
// - Ejercicio 9 -

// Escribe un programa para jugar a adivinar números. El programa tiene que seguir los siguientes pasos:
// 1. Calcular de forma aleatoria el número a adivinar por el jugador. 
//    El número debe hallarse entre 0 y 50 (ambos inclusive).
// 2. Preguntar un número al jugador y dar una pista
//    indicando si el número introducido es mayoro menor que el número a adivinar.
// 3. Si el jugador acierta el número, la partida terminará indicando la cantidad de tentativas
//    hechas por este jugador para acertar.
// 4. Habrá un máximo de tentativas dependiendo del nivel elegido para jugar:
//    fácil =10, medio = 6, difícil = 4.
// 5. El programa preguntará si se desea seguir jugando. 
//    Si se responde que sí el juego seguirá pidiendo un nuevo nivel y generando otro número, 
//    si se responde ESC se saldrá del programa. 
//    Cualquier otra respuesta no será válida y se pedirá que se vuelva a responder.
// Nota: Será necesario realizar los métodos y el paso de parámetros que consideres adecuado para una correcta programación.

namespace ejercicio9
{
    class Program
    {
        static int CalculaNumero()
        {
            return new Random().Next(0, 51);
        }

        static int EligeNivel()
        {
            string nivel;
            int tentativas = 0;
            
            do
            {
                Console.Write("\nElige el nivel del juego [fácil, medio o difícil]: ");
                nivel = Console.ReadLine();
            }
            while (nivel != "facil" && nivel != "medio" && nivel != "dificil");

            if (nivel == "facil")
            {
                tentativas = 10;
            }
            
            else if (nivel == "medio")
            {
                tentativas = 6;
            }
            
            else if (nivel == "dificil")
            {
                tentativas = 4;
            }
            return tentativas;
        }
        
        static void IniciaJuego()
        {
            int tentativas = 0;
            int adivinarNumero;
            int maxTentativas = EligeNivel();
            int numero = CalculaNumero();
            Console.WriteLine("\n|<|>|Adivina un número entre 0 y 50|<|>|");
            
            do
            {
                Console.Write("\nIntroduzca un número: ");
                adivinarNumero = int.Parse(Console.ReadLine());

                if (adivinarNumero < numero)
                {
                    Console.WriteLine("\nEl número a adivinar es mayor, inténtalo otra vez.");
                }
                
                else if (adivinarNumero > numero)
                {
                    Console.WriteLine("\nEl número a adivinar es menor, inténtalo otra vez.");
                }
                ++tentativas;
            }
            while (adivinarNumero != numero && tentativas < maxTentativas);

            if (adivinarNumero == numero)
            {
                Console.WriteLine($"\nCongratulaciones! Es el número {numero} y lo has adivinado en {tentativas} tentativas.");
            }
            
            else
            {
                Console.WriteLine("\nEl número introducido no es correcto y no te quedan más tentativas... Sigue jugando para intentarlo otra vez.");
            }
            ContinuaJuego();
        }

        static bool ContinuaJuego()
        {
            bool escape;
            char caracter;
            do
            {
                Console.WriteLine("\nQuieres continuar con el juego?\n1 - Sí (y)\n2 - No (Esc)");
                var tecla = Console.ReadKey();
                escape = tecla.Key == ConsoleKey.Escape;
                caracter = tecla.KeyChar;
            }
            while (!escape && caracter != 'y');

            if (caracter == 'y')
            {
                IniciaJuego();
            }
            
            else
            {
                Console.WriteLine("\nHas pulsado 'Esc', programa finalizado.");
            }
            return escape;
        }
        
        static void Main(string[] args)
        {
            IniciaJuego();
        }
    }
}