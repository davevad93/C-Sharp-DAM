using System;
using System.Text;

// DAVIDE PRESTI
// - Ejercicio 3 -

// El programa a realizar es una versión del famoso juego del ahorcado. Para ello el programa
// en primer lugar, pedirá al usuario la palabra secreta y el máximo de fallos permitido..
// Introduce la palabra a adivinar: BUCLE
// Introduce el número máximo de fallos: 3
// Tras introducir estos datos, la pantalla se borrará y comenzaremos con el juego.
// Mostrando en cada iteración los huecos o aciertos de la palabra secreta, así como las
// letras falladas hasta el momento.
// El usuario irá introduciendo letras hasta que acierte la palabra o supere el número de
// fallos.
// Tras introducir estos datos, la pantalla se borrará y comenzaremos con el juego.
// Mostrando en cada iteración los huecos o aciertos de la palabra secreta, así como las
// letras falladas hasta el momento.
// El usuario irá introduciendo letras hasta que acierte la palabra o supere el número de
// fallos.
// 👉Pista: la rama del DEM que se encarga de pedir letra no repetida, solamente estará
// recogiendo carácteres al usuario hasta que introduzca uno no repetido. Ese carácter no lo
// guardará en ningún sitio. Los métodos que se encargan de añadir la letra a los StringBuilders
// correspondientes son AñadeLetraALetrasParaMostrar o AñadeLetraALetrasFalladas (aunque
// se tenga que volver a recorrer las cadenas).
// Tips a seguir en la resolución del ejercicio:
// 1. Tanto la palabra secreta, como las letras introducidas, las pasaremos a mayúsculas para
// no tener problemas a la hora de buscarlas y compararlas.
// 2. Utiliza StringBuilder para guardar las letras acertadas y las falladas.
// 3. Sigue el siguiente DEM a la hora de diseñar tus módulos o funciones:

// Una posible propuesta de algunos interfaces para modularizar el DEM de arriba puede ser…
// string PidePalabraAAdivinar()
// int PideMaximoFallos()
// bool EstaLetraEnLetras(char letra, string letras) //Puedes usar IndexOf
// char PideLetraNoRepetida(
// string palabraParcialmenteAdivinada,
// string letrasFalladas)
// void MuestraEstadoJuego(
// string palabraParcialmenteAdivinada,
// string letrasFalladas)
// void AñadeLetraALetrasPalabraAMostrar(
// string palabraAAdivinar,
// in char letra,
// StringBuilder palabraParcialmenteAdivinada)
// bool FinDeJuego(
// int numFallos, int maxFallos,
// string palabraAAdivinar, string palabraParcialmenteAdivinada,
// out string mensajeSiFin)
// void Jugar(string palabraAAdivinar, int maximoFallos)

namespace ejercicio3
{
    class program
    {
        static string PidePalabraAAdivinar()
        {
            Console.Write("\nIntroduzca una palabra a adivinar: ");
            string palabra = Console.ReadLine();
            return palabra.ToUpper();
        }

        static int PideMaximoFallos()
        {
            Console.Write("Introduzca el número máximo de fallos: ");
            int fallos = int.Parse(Console.ReadLine());
            Console.Clear();
            return fallos;
        }

        static char PideLetraNoRepetida(string palabraParcialmenteAdivinada, string letrasFalladas)
        {
            Console.Write("\nIntroduzca una letra: ");
            char letra = char.Parse(Console.ReadLine());
            EstaLetraEnLetrasIntroducidas(letra, letrasFalladas, palabraParcialmenteAdivinada);
            return char.ToUpper(letra);
        }
        
        static void MuestraEstadoJuego(string palabraParcialmenteAdivinada, string letrasFalladas)
        {
            Console.Write("\nPalabra: ");
            for (int i = 0; i < palabraParcialmenteAdivinada.Length; i++)
            {
                Console.Write($"{palabraParcialmenteAdivinada[i]}");
            }
            
            Console.Write("\nFallos: ");
            for (int i = 0; i < letrasFalladas.Length; i++)
            {
                Console.Write($"{letrasFalladas[i]}");
            }    
        }           

        static bool EstaLetraEnLetras(char letra, string letras)
        {
            bool letraIntroducida = true;
            letras.IndexOf(letra);

            if (letras.IndexOf(letra) > -1)
            {
                letraIntroducida = true;
                Console.WriteLine($"La letra {letra} ha sido introducida anteriormente, introduzca otra letra.");
            }

            else
            {
                letraIntroducida = false;
            }
            return letraIntroducida;
        }

        static void EstaLetraEnLetrasAcertadas(char letra, string palabraParcialmenteAdivinada)
        {
            EstaLetraEnLetras(letra, palabraParcialmenteAdivinada);
        }

        static void EstaLetraEnLetrasFalladas(char letra, string letrasFalladas)
        {
            EstaLetraEnLetras(letra, letrasFalladas);
        }

        static void EstaLetraEnLetrasIntroducidas(char letra, string letrasFalladas, string palabraParcialmenteAdivinada)
        {
            EstaLetraEnLetrasAcertadas(letra, palabraParcialmenteAdivinada);
            EstaLetraEnLetrasFalladas(letra, letrasFalladas);
        }

        static bool AñadeLetraALetrasPalabraAMostrar(string palabraAAdivinar, char letra, StringBuilder palabraParcialmenteAdivinada)
        {
            bool posicion = false;

            for (int i = 0; i < palabraAAdivinar.Length; i++)
            {
                if (palabraAAdivinar[i] == letra)
                {
                    palabraParcialmenteAdivinada[i] = letra;
                    posicion = true;
                }
            }
            return posicion;
        }

        static void AñadeLetraALetrasFalladas(string palabraAAdivinar, in char letra, StringBuilder letrasFalladas)
        {
            if (letrasFalladas.ToString().Contains(letra))
            {
                letrasFalladas = null;
            }

            else
            {
                letrasFalladas.Append(letra + "");
            }
        }

        static void HaAcertadoYaLaPalabra()
        {
            Console.WriteLine("\nEnhorabuena, has acertado la palabra.");
        }

        static void HaLLegadoAlMaximoDeFallos()
        {
            Console.WriteLine("\nLo siento, has llegado al máximo de fallos permitido.");
        }

        static bool FinDeJuego(int numFallos, int maxFallos, string palabraAAdivinar, string palabraParcialmenteAdivinada)
        {
            if (palabraAAdivinar == palabraParcialmenteAdivinada)
            {
                HaAcertadoYaLaPalabra();
            }

            if (numFallos > maxFallos)
            {
                HaLLegadoAlMaximoDeFallos();
            }
            return (numFallos <= maxFallos && !(palabraAAdivinar == palabraParcialmenteAdivinada));
        }

        static void Jugar(string palabraAAdivinar, int maximoFallos)
        {
            int fallos = 0;
            StringBuilder palabraParcialmenteAdivinada = new StringBuilder(palabraAAdivinar.Length);
            StringBuilder letrasFalladas = new StringBuilder(maximoFallos);

            for (int i = 0; i < palabraAAdivinar.Length; ++i)
            {
                palabraParcialmenteAdivinada.Append("_");
            }
            Console.WriteLine(palabraParcialmenteAdivinada.ToString() + "\n");

            do
            {
                char letra = PideLetraNoRepetida(palabraParcialmenteAdivinada.ToString(), letrasFalladas.ToString() + "\n");

                if (!AñadeLetraALetrasPalabraAMostrar(palabraAAdivinar, letra, palabraParcialmenteAdivinada))
                {
                    ++fallos;
                    AñadeLetraALetrasFalladas(palabraAAdivinar, letra, letrasFalladas);
                }
                MuestraEstadoJuego(palabraParcialmenteAdivinada.ToString(), letrasFalladas.ToString());
            }
            while (FinDeJuego(fallos, maximoFallos, palabraAAdivinar, palabraParcialmenteAdivinada.ToString()));
        }   

        static void Main(string[] args)
        {
            Jugar(PidePalabraAAdivinar(), PideMaximoFallos());
        }     
    }
}