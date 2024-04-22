using System;

// DAVIDE PRESTI
// - Ejercicio 5 -

// Escribe un programa que lea un número en base 10 (decimal) y que posteriormente muestre un menú que nos permita
// convertirlo a base 2 (binario), base 8 (octal) o base 16 (hexadecimal).
// Crea un método llamado PasaABinario, otro llamado PasaAOctal y otro llamado PasaAHexadecimal para realizar
// dichas operaciones.
// Todos los métodos devolverán un string que contendrá los dígitos resultantes de la conversión.
// 👁 Nota 1: No se puede usar el método Convert existente ya en C#.
// 👁 Nota 2: Evita el código repetido.
// 🔍 Algunas pistas para resolver el ejercicio:
// 1. Si no sabes como es el proceso de conversión matemático, puedes consultar el proceso de decimal a binario en el
// siguiente enlace: Decimal a binario
// Para el resto de sistemas es análogo solo que dividiendo entre 8 y 16 respectivamente.
// 2. En todos los casos obtendremos restos enteros entre 0 a 15 que deberemos pasar a cadena o a caracter.
// Una de las opciones es pasar a cadena. En este caso cuando el valor esté entre 0 a 9 generaremos una cadena
// con "0", "1" ... o , "9" por ejemplo con $"{resto}". Sin embargo, cuando el valor este entre 10 y 15, generaremos
// una cadena con los caracteres "A", "B", ... o ,"F" y eso se puede hacer, por ejemplo, con un expresión switch.
// De tal manera que podríamos tener una expresión del tipo ...
// string textoResto = resto < 10
// ? $"{resto}"
// : resto switch { 10 => "A", 11 => "B", 12 => "C", 13 => "D", 4 => "E", 15 => "F", _ => "?" };
// Mas eficiente y tradicional de programadores de C y C++ es usar la tabla UTF-8 o su subconjunto ASCII para en
// lugar de pasar a cadena pasar a carácter. El planteamiento sería el siguiente:
// El carácter '0' internamente se guarda con el valor 48 (Decimal) y el resto de caracteres que representan
// dígitos decimales van seguidos en esa tabla. Por tanto, si cuando el resto es menor que 10 hago...
// const int INiCIO_CARACTER_0 = 48;
// char simbolo = (char)(INICIO_CARACTER_0 + resto);
// El carácter mayúscula 'A' se guarda internamente con el valor 65 y la 'B', 'C',..., 'F' van seguidos en esa tabla
// luego...
// Puedes utilizar este último planteamiento si lo consideras más adecuado.

namespace ejercicio5
{
    class Program
    {
        static string ConvierteCadena(int valor, int baseNum)
        {
            const int INICIO_CARACTER_0 = 48;
            const int INICIO_CARACTER_A_F = 55; 
            string cadenaConLaConversion = "";          
            
            if (valor == 0)
            {
                cadenaConLaConversion = "0";
            }
    
            while (valor > 0)
            {
                int resto = valor % baseNum;
                valor /= baseNum;
                char simbolo = (char)(INICIO_CARACTER_0 + resto);

                if (resto >= 10)
                {
                    simbolo = (char)(INICIO_CARACTER_A_F + resto);
                }
                cadenaConLaConversion = simbolo + cadenaConLaConversion;
            }
            return cadenaConLaConversion;
        }

        static string PasaABinario(int valor)
        {
            return ConvierteCadena(valor, 2);
        }

        static string PasaAOctal(int valor)
        {
            return ConvierteCadena(valor, 8);
        }

        static string PasaAHexadecimal(int valor)
        {
            return ConvierteCadena(valor, 16);
        }

        static void SeleccionaConversion()
        {
            Console.Write("\nIntroduzca un valor en base 10 o decimal: ");
            int valor = int.Parse(Console.ReadLine());
            
            int opcion;
            do
            {
                Console.Write("\nSelecciona una opción de conversion:\n" +
                              "\n1 - Convertir a valor binario." +
                              "\n2 - Convertir a valor octal." +
                              "\n3 - Convertir a valor hexadecimal.\n\n");
                opcion = int.Parse(Console.ReadLine());

                if (opcion == 1)
                {
                    string valorBinario = PasaABinario(valor);
                    Console.Write($"\nEl número {valor} en binario es: {valorBinario}\n\n");                    
                }

                if (opcion == 2)
                {
                    string valorOctal = PasaAOctal(valor);
                    Console.Write($"\nEl número {valor} en octal es: {valorOctal}\n\n");                    
                }

                if (opcion == 3)
                {
                    string valorHexadecimal = PasaAHexadecimal(valor);
                    Console.Write($"\nEl número {valor} en hexadecimal es: {valorHexadecimal}\n\n");                    
                }
            }
            while (opcion != 1 && opcion != 2 && opcion != 3);         
        }

        static void Main(string[] args)
        {
            SeleccionaConversion();
        }
    }
}