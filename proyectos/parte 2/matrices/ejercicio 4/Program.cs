using System;

// DAVIDE PRESTI
// - Ejercicio 4 -
// Tenemos una tabla dentada de caracteres char[][] paises , que tiene almacenados los nombres
// de 20 países.
// Se pide diseñar un programa que realice, tantas veces como sea requerido por el usuario, las
// siguientes operaciones:
// 1. Buscar un país.
// 2. Mostrar países.
// 3. Ordenar países.
// 4. Añadir prefijo a un país.
// Otras consideraciones...
// El prefijo estará formado por 2 caracteres, habrá un espacio en blanco entre el nombre y el
// prefijo. Para añadir el prefijo a la fíla correspondiente del país, puedes redimensionar la fila de
// la dentada usando el método:
// Array.Resize(ref paises[paisEncontrado], paises.Length+3)
// Para ordenar la dentada alfabéticamente, utilizaremos el método de ordenación de la burbuja
// (hay un ejemplo en los apuntes). Para comparar cadenas alfabéticamente debes usar el
// método CompareTo de cadena.
// 👉Pista: para programar este ejercicio podemos pasar de array de char a string o viceversa,
// cuando lo necesitemos. Recordar que para pasar de string a array de char usaremos
// cadena.TocharArray() y de array de char a string con new String(array)

namespace ejercicio4
{
    class Program
    {
        static bool BuscaPais(char[][] paises, char[] pais, out int i)
        {
            bool comprobarPais = false;
            i = -1;

            for (int j = 0; j < paises.Length; j++)
            {
                string paisUno = new String(paises[j]);
                string paisDos = new String(pais);
                
                if (paisUno.ToLower() == paisDos.ToLower())
                {
                    comprobarPais = true;
                    i = j;
                }
            }
            return comprobarPais;
        }

        static void OrdenaPaises(char[][] paises)
        {
            for (int i = 0; i < paises.Length; i++)
            {
                for (int j = 0; j < paises.Length; j++)
                {
                    if (new String(paises[j]).CompareTo(new String(paises[i])) > 0)
                    {
                        char[] pais = (char[])paises[i].Clone();
                        paises[i] = paises[j];
                        paises[j] = pais;
                    }
                }
            }
        }        

        static char[] VerificarPrefijo(char[] pais, char[] prefijo)
        {
            Array.Resize(ref pais, pais.Length + 3);
            pais[pais.Length - 1] = prefijo[1];
            pais[pais.Length - 2] = prefijo[0];
            pais[pais.Length - 3] = ' ';
            
            if (pais == null || prefijo == null || prefijo.Length != 2)
            {
                Console.WriteLine("ERROR! Datos introducidos érroneos.");
            }
            return pais;
        }

        static void AñadePrefijo(char[][] paises)
        {
             Console.Write("Introduzca el nombre del país para añadirle el prefijo: ");
             string pais = Console.ReadLine();
             string paisBuscado = pais;
             int posicion;
             
             if (BuscaPais(paises, pais.ToCharArray(), out posicion) == true)
             {
                Console.Write("Introduzca el prefijo del país: ");
                string prefijo = Console.ReadLine();
                paises[posicion] = VerificarPrefijo(paises[posicion], prefijo.ToCharArray());
             }
             
             else
             {
                Console.WriteLine($"{paisBuscado} no está en la lista.");
             } 

        }     

        static void MuestraPaises(char[][] paises)
        {
            for (int i = 0; i < paises.GetLength(0); i++)
            {    
                Console.WriteLine(new String(paises[i]));
            }    
        }

        static void Main(string[] args)
        {
            char[][] paises =
                {
                    "España".ToCharArray(),
                    new char[] { 'U','r','u','g','u','a','y' },
                    new char[] { 'B','u','l','g','a','r','i','a' },
                    new char[] { 'J','a','p','o','n' },
                    new char[] { 'O','m','a','n', },
                    new char[] { 'R','u','s','i','a' },
                    new char[] { 'V','e','n','e','z','u','e','l','a' },                    
                    new char[] { 'P','o','r','t','u','g','a','l' }, 
                    new char[] { 'I','t','a','l','i','a' },                                                           
                    new char[] { 'C','o','l','o','m','b','i','a' },
                    new char[] { 'Z','i','m','b','a','b','u','e' },                    
                    new char[] { 'M','a','r','r','u','e','c','o','s' },
                    new char[] { 'D','i','n','a','m','a','r','c','a' },
                    new char[] { 'Q','a','t','a','r' },                    
                    new char[] { 'H','u','n','g','r','i','a' },
                    new char[] { 'G','r','e','c','i','a' },
                    new char[] { 'N','i','g','e','r','i','a' },
                    new char[] { 'K','e','n','i','a' },
                    new char[] { 'Y','e','m','e','n' },                    
                    new char[] { 'T','a','i','l','a','n','d','i','a' },
                    new char[] { 'F','r','a','n','c','i','a' },
                    new char[] { 'A','r','g','e','n','t','i','n','a' },
                    new char[] { 'L','a','o','s' },
                    new char[] { 'S','e','r','b','i','a' }                    
                };

            bool escape = true;     
            do
            {
               
                Console.WriteLine("\n1. Buscar un país." +
                                  "\n2. Mostrar países." +
                                  "\n3. Ordenar países." +
                                  "\n4. Añadir prefijo a un país." +
                                  "\nESC. Salir.\n");
                var tecla = Console.ReadKey(true);
                escape = tecla.Key == ConsoleKey.Escape;
                
                switch (tecla.KeyChar)
                {
                    case '1':
                        Console.Write("Introduzca el nombre del país: ");
                        string pais = Console.ReadLine();
                        string paisBuscado = pais;
                        int posicion;
                        if (BuscaPais(paises, pais.ToCharArray(), out posicion))
                        {
                            Console.WriteLine($"{paisBuscado} está en la lista y ocupa la posición {posicion}.");
                        }
                        else
                        {
                            Console.WriteLine($"{paisBuscado} no está en la lista.");
                        }
                        break;
                    case '2':
                        MuestraPaises(paises);
                        break;
                    case '3':
                        OrdenaPaises(paises);
                        break;
                    case '4':
                        AñadePrefijo(paises);
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