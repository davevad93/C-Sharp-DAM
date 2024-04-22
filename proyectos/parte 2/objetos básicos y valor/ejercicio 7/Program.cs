using System;

// DAVIDE PRESTI
// - Ejercicio 7 -
// Debes definir un tipo valor que represente un Naipe de la baraja Española de 48 cartas. 
// El tipo estará compuesto por dos miembros: un valor y un palo, 
// este último sera de tipo enumerado con los siguientes valores posibles: Oros, Copas, Bastos, Espada.
// Crea un método en la clase principal que utilizando el tipo Naipe nos devuelva una baraja con las 48 cartas, 
// usa una matriz Naipe[,] baraja= new Naipe[4,12] e inicialízala suponiendo que cada fila representa un palo.
// Crea un método que nos mezcle la baraja para que queden sus cartas desordenadas.
// Crea un programa que muestre el resultado de la utilización de los métodos anteriores.
// 📌 Nota: Vuelve a repasar los apuntes donde se explica la creación del Tipo Valor 
// y sigue las normas que se explican para este tipo.

namespace ejercicio7
{

  class Program
    {
        static Naipe[,] CreaBaraja()
        {
            Console.WriteLine("\nOrdenando la baraja por palo y orden numérico...\n ");
            const int NUMERO_PALO = 4;
            const int NUMERO_CARTAS_PALO = 12; 
            Palo[] palos = (Palo[])Enum.GetValues(typeof(Palo));
            Naipe[,] baraja = new Naipe[NUMERO_PALO, NUMERO_CARTAS_PALO];
            for (int i = 0; i < NUMERO_PALO; i++)
            {
                for (int j = 0; j < NUMERO_CARTAS_PALO; j++)
                {
                    baraja[i, j] = new Naipe(palos[i], j + 1);
                }
            }
            return baraja;
        }

        static void MezclaBaraja(Naipe[,] baraja, string[] barajaStringArray)
        {
            Console.WriteLine("Resultado de la mezcla de la baraja:\n");
            string[] barajaStringArrayDesordenado = new string [baraja.Length];
            int minPosicionArrayCartas = 0;
            int maxPosicionArrayCartas = 48;
            int numeroTotalCartas = 48;
            int[] numeros = new int[numeroTotalCartas];
            bool repetido;
            int indice = 0;

            while (indice < numeros.Length)
            {

                repetido = false;
                Random seed = new Random();
                int poscionAleatoria = 0;
                poscionAleatoria = seed.Next(minPosicionArrayCartas, maxPosicionArrayCartas);

                for (int i = 0; i < indice; i++)
                {
                    if (numeros[i] == poscionAleatoria)
                    {
                        repetido = true;
                    }
                }

                if (!repetido)
                {
                    numeros[indice] = poscionAleatoria;
                    indice++;
                }
            }

            for (int j = 0; j < numeros.Length; j++)
            {
                barajaStringArrayDesordenado[numeros[j]] = barajaStringArray[j];   
            }
            for (int k = 0; k < barajaStringArrayDesordenado.Length; k++)
            {
                Console.WriteLine(barajaStringArrayDesordenado[k]);
            }
        }        

        static void Main(string[] args)
        {
            Naipe[,] baraja = new Naipe[4, 12];
            string[] barajaStringArray = new string[baraja.Length];
            int contador = 0;
            baraja = CreaBaraja();
            foreach (var cartas in baraja)
            {
                Console.WriteLine($"{cartas.Palos.ToString()} {cartas.Valor}");
                barajaStringArray[contador] = $"{cartas.Palos.ToString()} {cartas.Valor}";
                contador++;
            }
            Console.WriteLine("\n");
            MezclaBaraja(baraja, barajaStringArray);
        } 
    }
}