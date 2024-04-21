using System;

// DAVIDE PRESTI 
// - Ejercicio 8 -

// Una compañía de videojuegos te ha contratado para escribir el programa de un videojuego nuevo.
// - Deberás crear la parte del programa que calcula el número total de puntos 
//   que un jugador gana en el juego Galaxy.
// - Los jugadores acumulan puntos mediante la recolección de objetos.
// - Los objetos tienen asignados los siguientes puntos:

// - Estrella = 10 puntos.
// - Planeta = 20 puntos.
// - Asteroide = 50 puntos.
// - Cometa = 100 puntos.

// Si un jugador acumula más de 5.000 puntos, en una misma jugada, ganará un bono de 500 puntos.
// Implementa pues una jugada, donde le pidamos al usuario el nombre de un objeto 
// y el número de estos que ha recogido. Mostrando el total de puntos teniendo en cuenta los bonos.

// Nota: Usar un switch para decidir los puntos del objeto.

namespace ejercicio8
{
    class Program
    {
        static void Main(string[] args)
        {   
            Console.Write("Introduzca el nombre de un objeto: ");
            string objeto = Console.ReadLine();
            Console.Write($"\nCuantos/as {objeto}s has recogido? ");
            int cantidad = int.Parse(Console.ReadLine());

            int puntosObjetos;
            switch(objeto.ToLower())
            {
                case "estrella":
                    puntosObjetos = 10;
                    break;
                case "planeta":
                    puntosObjetos = 20;
                    break;
                case "asteroide":
                    puntosObjetos = 50;
                    break;
                case "cometa":
                    puntosObjetos = 100;
                    break;
                default:
                    puntosObjetos = 0;
                    break;
            }

            int puntuacionJugada = puntosObjetos * cantidad;
            if (puntuacionJugada > 5000)
            {
                puntuacionJugada+= 500;
            }
                        
            string linea = puntuacionJugada >= 0
                            ? $"\nHas recogido {cantidad} {objeto}s y has acumulado {puntuacionJugada} puntos."
                            : "\nERROR!";
            Console.WriteLine(linea);
        }
    }
}