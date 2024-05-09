using System;
using System.Text;

// DAVIDE PRESTI
// - Ejercicio 2 -

// Programa para practicar con StringBuilder (obligatorio su uso). El programa deberá recoger
// una cadena con un texto acabado en '.' y que pasaremos a codificar u ofuscar. Para ello
// crearemos tres tipos de codificación, cada una la realizaremos en un método diferente y se
// usará StringBuilder para desarrollarla. Consisten en lo siguiente:
// 1. Codificación especular, es la famosa manera que tenía Leonardo Da Vinci de escribir
// volviendo las palabras del revés, de forma que es más sencillo su lectura mediante un
// espejo.
// 👉Pista: puedes leer el texto hasta un espacio en blanco (fin de palabra), guardando la
// posición de inicio de palabra (carácter después de espacio o primero). Y hacer la sustitución
// entre los dos indices.
// 2. Codificación ofuscación cambiando carácteres de puntuación, esta manera de
// ofuscar la frase será mediante el cambio de los carácteres de puntuación (, : . ; ? ¿ ! ¡),
// por algunos carácteres especiales generados aleatoriamente.
// 👉Pista: puedes usar una cadena para guardar los carácteres especiales y el método
// Contains para saber si un caracter está entre ellos. Para generar los carácteres aleatorios
// puedes usar el rango de ASCII entre 224-238.
// 3. Codificación ofuscación quitando espacios en blanco, en este caso solamente se
// eliminarán los espacios en blanco que hayan en la frase.
// Un ejemplo de ejecución sería el siguiente:
// Introduce la frase a ofuscar:
// La verdadera felicidad cuesta poco; si es cara, no es de buena clase.
// aL aredadrev dadicilef atseuc ;ocop is se ,arac on se ed aneub esalc
// aL aredadrev dadicilef atseuc ëocop is se íarac on se ed aneub esalc
// aLaredadrevdadicilefatseucâocopisseçaraconseedaneubesalc

namespace ejercicio2
{
    class program
    {
        static string LeeFrase()
        {
            Console.Write("\nIntroduzca la frase a ofuscar: ");
            string frase = Console.ReadLine();
            return frase;
        }

        static void InvierteTexto(StringBuilder texto, int inicio, int fin)
        {
            StringBuilder textoInvertido = new StringBuilder(fin - inicio + 1);

            for (int i = fin; i >= inicio; i--)
            {
                textoInvertido.Append(texto[i]);
            }

            for (int i = inicio; i <= fin; i++)
            {
                texto[i] = textoInvertido[i - inicio];
            }
        }

        static string CodificacionEspecular(string texto)
        {
            StringBuilder txt = new StringBuilder(texto);
            int inicio = 0;
            int fin;

            for (int i = 0; i < texto.Length; i++)
            {
                if (texto[i] == ' ')
                {
                    fin = i - 1;
                    InvierteTexto(txt, inicio, fin);
                    inicio = i + 1;
                }
            }
            InvierteTexto(txt, inicio, txt.Length - 1);
            return txt.ToString();
        }

        static string OfuscaPuntuacion(string texto)
        {
            const string caracteres = ",.:!?¿;¿";
            StringBuilder txt = new StringBuilder(texto);
            Random caracter = new Random();
            const int INICIO_VALOR_ASCII = 224;
            const int FIN_VALOR_ASCII = 238;            
            
            for (int i = 0; i < texto.Length; i++)
            {
                if (caracteres.Contains(txt[i]))
                {
                    txt[i] = (char)caracter.Next(INICIO_VALOR_ASCII, FIN_VALOR_ASCII);
                }
            }
            return txt.ToString();
        }

        static string OfuscaEspacios(string texto)
        {
            StringBuilder txt = new StringBuilder(texto);

            for (int i = 0; i < txt.Length; i++)
            {
                if (txt[i] == ' ')
                {
                    txt.Remove(i--, 1);
                } 
            }
            return txt.ToString();
        }

        static void Main(string[] args)
        {
            string texto = LeeFrase();
            Console.WriteLine("\n" + texto);
            Console.WriteLine(CodificacionEspecular(texto));
            Console.WriteLine(OfuscaPuntuacion(CodificacionEspecular(texto)));
            Console.WriteLine(OfuscaEspacios(OfuscaPuntuacion(CodificacionEspecular(texto))) + "\n");
        }
    }   
}