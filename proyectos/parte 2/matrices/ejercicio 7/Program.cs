using System;

// DAVIDE PRESTI
// - Ejercicio 7 -
// Escribe un programa que se encargue de controlar el aforo de un Multicine:
// El cine tendrá tres salas (A, B, C), en las cuales se pasarán diariamente tres sesiones (1ª, 2ª,
// 3ª).
// El número máximo de personas de cada una de las salas es:
// Sala A = 200 personas.
// Sala B = 150 personas.
// Sala C = 125 personas.
// Tendremos un menú con dos opciones:
// 1. Venta de entradas.
// 2. Estadística de aforo.
// Para salir del programa se tendrá que pulsar la tecla ESC.
// Cada vez que se realice una venta de entradas se pedirá:
// El número de entradas que se van a comprar.
// La sala
// La sesión a la que se quiere asistir.
// Las entradas vendidas quedarán registradas en la matriz bi-dimensional.
// Si el número de entradas sobrepasa el aforo máximo de la sala, se indicará mediante un mensaje
// por pantalla.
// En la opción de estadística de aforo, se mostrará una tabla de la siguiente manera:
//          Sesión1     Sesión2    Sesión3
// SalaA    178         100        99
// SalaB    12          50         100
// SalaC    32          101        55
// 👉Pista: puedes plantearte la solución de dos formas distinta. Inicializando todos los elementos de
// la matriz de 3X3 a 0 y en cada venta añadir, al elemento correspondiente a los indices, las entradas
// vendidas sin pasarse del afora de la sala. La otra opción sería inicializar la matriz una fila a 200, la
// otra a 150 y la última a 125, y en cada venta decrementar la cantidad vendida, controlando de no
// vender si se ha llegado a 0.

namespace ejercicio7
{
    class Program
    {
        static char PideSala()
        {
            char sala;
            bool salaCorrecta;
            
            do
            {
                Console.Write("\n¿A qué sala desea ir? (A-B-C): ");
                sala = char.Parse(Console.ReadLine());
                sala = Char.ToUpper(sala);
                
                if (sala == 'A' || sala == 'B' || sala == 'C')
                {
                    salaCorrecta = true;
                }  
                else
                {
                    Console.WriteLine("\nERROR! Sala inexistente.");
                    salaCorrecta = false;
                }
            } 
            while (!salaCorrecta);
            return sala;
        }

        static int PideSesion()
        {
            int sesion;
            bool sesionCorrecta;
            
            do
            {
                Console.Write("\n¿A qué sesión desea asistir? (1-2-3): ");
                sesion = int.Parse(Console.ReadLine());
                
                if (sesion == 1 || sesion == 2 || sesion == 3)
                {
                    sesionCorrecta = true;
                }
                else 
                {
                    Console.WriteLine("\nERROR! Sesión inexistente.");
                    sesionCorrecta = false;
                }
            } 
            while (!sesionCorrecta);
            return sesion;
        }         

        static int VendeEntradasCine(int entrada, string[][] aforo, int ventaEntradas, int fila, int columna, int maxEntradas)
        {
            Console.Write("¿Cuántas entradas quiere comprar? ");
            entrada = int.Parse(Console.ReadLine());
            char sala = PideSala();
            int sesion = PideSesion();
            
            if (sala == 'A' && sesion == 1)
            {
                fila = 1;
                columna = 1;
                maxEntradas = 200;
            }

            else if (sala == 'A' && sesion == 2)
            {
                fila = 1;
                columna = 2;
                maxEntradas = 200;
            }

            else if (sala == 'A' && sesion == 3)
            {
                fila = 1;
                columna = 3;
                maxEntradas = 200;
            }

            else if (sala == 'B' && sesion == 1)
            {
                fila = 2;
                columna = 1;
                maxEntradas = 150;
            }

            else if (sala == 'B' && sesion == 2)
            {
                fila = 2;
                columna = 2;
                maxEntradas = 150;
            }

            else if (sala == 'B' && sesion == 3)
            {
                fila = 2;
                columna = 3;
                maxEntradas = 150;
            }

            else if (sala == 'C' && sesion == 1)
            {
                fila = 3;
                columna = 1;
                maxEntradas = 125;
            }

            else if (sala == 'C' && sesion == 2)
            {
                fila = 3;
                columna = 2;
                maxEntradas = 125;
            }

            else if (sala == 'C' && sesion == 3)
            {
                fila = 3;
                columna = 3;
                maxEntradas = 125;
            }
                    
            entrada += ventaEntradas;
            if (entrada <= maxEntradas)
            {
                string venta = entrada.ToString();
                aforo[fila][columna] = venta;
            }

            else
            {
                Console.WriteLine($"\nLo siento el aforo máximo en la sala {sala} es de {maxEntradas}" +
                                  $" personas, así que no puedo venderte {entrada} entrada/s.");
            }
            return entrada;
        }
        
        static string[][] MuestraEstadistica(string[][] aforo)
        {
            for (int i = 0; i < aforo.Length; i++)
            {
                for (int j = 0; j < aforo[i].Length; j++)
                {
                    Console.Write($"{aforo[i][j], -20}");
                }
                Console.WriteLine();
            }
            
            aforo = new string[][]
            {
                new string[]{"", "Sesión 1:", "Sesión 2:", "Sesión 3:"},
                new string[]{"Sala A:", "", "", ""},
                new string[]{"Sala B:", "", "", ""},
                new string[]{"Sala C:", "", "", ""}
            };
            return aforo;
        }

        static void Main(string[] args)
        {
            int entrada = 0;
            string[][] aforo = {};
            int ventaEntradas = 0;
            int fila = 0;
            int columna = 0;
            int maxEntradas = 0;
            bool escape = true;
            aforo = MuestraEstadistica(aforo);

            do
            {
                Console.WriteLine("\n|<|>|MENÚ CINEMA|<|>|\n" +
                                  "\n1. Venta de entradas." +
                                  "\n2. Estadística de aforo." +
                                  "\nESC. Salir.\n");
                var tecla = Console.ReadKey(true);
                escape = tecla.Key == ConsoleKey.Escape;

                switch (tecla.KeyChar)
                {
                    case '1':
                        VendeEntradasCine(entrada, aforo, ventaEntradas, fila, columna, maxEntradas);
                        break;
                    case '2':
                        MuestraEstadistica(aforo);
                        break;
                    default:
                        if (tecla.Key == ConsoleKey.Escape)
                            Console.WriteLine("Programa finalizado.\n");
                        else
                            Console.WriteLine("ERROR! Opción inexistente.\n");
                        break;    
                }
            }
            while (!escape);
        }
    }    
}