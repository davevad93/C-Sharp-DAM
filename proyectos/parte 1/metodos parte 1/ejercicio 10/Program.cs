using System;

// DAVIDE PRESTI
// - Ejercicio 10 -

// Programa que implementará un juego con las siguientes características:
// 1. El programa pedirá que introduzcas el número de participantes a jugar.
// 2. Cada participante tirará 3 veces un dado con valores entre 1 y 100 (electrónico se entiende),sumándose el valor de las 3 jugadas. 
//    Ganará el participante que obtenga mayor puntuación según las siguientes reglas:
//    ◦ Si el nº obtenido es múltiplo de 3 o de 5 sumará 10 pts.
//    ◦ Si el nº obtenido es múltiplo de 4 o de 6 sumará 5 pts.
//    ◦ Si el nº obtenido es mayor de 80 sumará 2 pts.
//    ◦ Si el nº obtenido es mayor de 50 sumará 1 pts.
//    ◦ Si el nº obtenido es menor de 50 restará 2 pts.
//    ◦ Si el nº obtenido es menor de 20 restará 1 pts.
// 3. El DEM para el juego será más o menos el siguiente.
//
//                       ------------------------------------ Main -------------------------------------------
//                      \/             \/                      \/                        \/                  \/
//                 Presentacion   Pide Numero                 Juego               Comprueba Total          Muestra
//                    Juego       Participantes        --- Participante ---       Con Mejor Puntuacion     Ganador
//                                                    \/                  \/ 
//                                                   Tira               Calcula
//                                                   Dado               Puntos

namespace ejercicio10
{
    class Program
    {
        static void PresentacionJuego()
        {
            Console.Write("\n|<|>|JUEGO DE LOS DADOS|<|>|" +
                          "\n\n¡Hola y bienvenidos al juego!" +
                          "\nCada jugador tirará 3 veces un dado con valores entre 1 y 100, sumándose el valor de las 3 jugadas." +
                          "\nGanará el jugador que obtenga la mayor puntuación según las siguientes reglas:" +
                          "\nSi el nº obtenido es múltiplo de 3 o de 5 sumará 10 puntos." +
                          "\nSi el nº obtenido es múltiplo de 4 o de 6 sumará 5 puntos. " +
                          "\nSi el nº obtenido es mayor de 80 sumará 2 puntos." +
                          "\nSi el nº obtenido es mayor de 50 sumará 1 punto." +
                          "\nSi el nº obtenido es menor de 50 restará 2 puntos." +
                          "\nSi el nº obtenido es menor de 20 restará 1 punto." +
                          "\n¡Suerte y que gane el MAYOR!");
        }
        
        static int PideNumeroParticipantes()
        {
            Console.Write("\n\nIntroduzca el número de jugadores: ");
            int participantes = int.Parse(Console.ReadLine());
            return participantes;
        }
        
        static int TiraDado()
        {
            return new Random().Next(1, 101);
        }
        
        static int CalculaPuntos(int dado)
        {
            int puntos = 0;
            if (dado % 3 == 0 || dado % 5 == 0)
            {
                puntos += 10;
            }
            if (dado % 4 == 0 || dado % 6 == 0)
            {
                puntos += 5;
            }
            if (dado > 80)
            {
                puntos += 2;
            }
            if (dado > 50)
            {
                puntos += 1;
            }
            if (dado < 50)
            {
                puntos -= 2;
            }
            if (dado < 20)
            {
                puntos -= 1;
            }
            return puntos;
        }
        
        static int JuegoParticipante(int jugador)
        {
            int puntos = 0;
            Console.WriteLine($"\nJugador número {jugador}:\n");
            for (int i = 0; i < 3; i++)
            {
                int dado = TiraDado();
                puntos += CalculaPuntos(dado);
                Console.WriteLine($"|Dado: {dado} ===> Puntos: {puntos}|");
            }
            return puntos;
        }
        
        static bool MejorPuntuacionActual(int puntuacion, int maxPuntuacion)
        {
            return puntuacion > maxPuntuacion;
        }

        static void MuestraGanador(int jugador, int puntos)
        {
            Console.Write($"\nEl ganador del juego es el jugador número {jugador}, con un total de {puntos} puntos.\n");
        }
        
        static void Main(string[] args)
        {
            int mejorJugador = 0;
            int maxPuntuacion = -1;
            PresentacionJuego();
            int numParticipantes = PideNumeroParticipantes();
            for (int i = 1; i <= numParticipantes; i++)
            {
                int puntos = JuegoParticipante(i);
                Console.Write($"\nPuntuación total jugador {i}: {puntos}\n");
                if (MejorPuntuacionActual(puntos, maxPuntuacion))
                {
                    maxPuntuacion = puntos;
                    mejorJugador = i;
                }
            }
            MuestraGanador(mejorJugador, maxPuntuacion);
        }
    }
}