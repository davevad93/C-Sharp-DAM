using System;

// DAVIDE PRESTI
// - Ejercicio 7 -

// Construye un programa que dados tres números enteros correspondientes a la hora, minutos y
// segundos actuales, calcula la hora (en el mismo formato) que será un segundo más tarde. 
// Para ello, se deben diseñar dos métodos:
// • HoraASegundos que dados tres argumentos de entrada correspondientes a hora, minutos y
//   segundos, devuelva la conversión de dicha hora a segundos desde las 00:00:00.
// • SegundosAHora, que dado un argumento de entrada correspondiente a una hora en segundos
//   desde las 00:00:00, la convierta en horas, minutos y segundos y la devuelva.
//   Devolverás la información mediante parámetros de salida.
// Nota: El algoritmo debe leer la hora en formato HH, MM y SS, después transformarla a segundos (con HoraASegundos),
// sumarle uno a dichos segundos y después volver a transformarla en HH, MM y SS (con SegundosAHora).

namespace ejercicio7
{
    class Program
    {
        static int HoraASegundos(int horas, int minutos, int segundos)
        {
            int totalSegundos = horas * 60 * 60 + minutos * 60 + segundos;
            return totalSegundos;
        }

        static (int horas, int minutos, int segundos) SegundosAHora(int totalSegundos)
        {
            int horas = totalSegundos / (60 * 60);
            int minutos = totalSegundos % (60 * 60) / 60;
            int segundos = totalSegundos % (60 * 60) % 60;
            return (horas, minutos, segundos);
        }
       
        static void Main(string[] args)
        {
            Console.Write("\nIntroduzca las horas: ");
            int horas = int.Parse(Console.ReadLine());
            Console.Write("\nIntroduzca los minutos: ");
            int minutos = int.Parse(Console.ReadLine());
            Console.Write("\nIntroduzca los segundos: ");
            int segundos = int.Parse(Console.ReadLine());

            if (horas < 24 && horas >= 0 && minutos >= 0 && minutos < 60 && minutos >= 0 && minutos < 60 && segundos >= 0 && segundos < 60)
            {
                int totalSegundos = HoraASegundos(horas, minutos, segundos);
                Console.Write($"\n(El total de segundos de la hora introducida [{horas:D2}:{minutos:D2}:{segundos:D2}] " + 
                              $"es de {HoraASegundos(horas, minutos, segundos)} segundos)." +
                              $"\n|HH:MM:SS|\n {horas:D2}:{minutos:D2}:{segundos:D2}");

                totalSegundos++;
                (horas, minutos, segundos) = SegundosAHora(totalSegundos);
                Console.Write($"\n\n|HH:MM:SS|\n {horas:D2}:{minutos:D2}:{segundos:D2}\n\n");
            }
            
            else
            {
                 Console.Write("\nERROR! La hora introducida no es válida.\n");
            }
        }
    }
}