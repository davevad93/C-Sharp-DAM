using System;

// DAVIDE PRESTI
// - Ejercicio 3 -
// Crea un método genérico llamado LeeEnum, que permitirá recoger un string del usuario hasta que coincida con un elemento de la enumeración X. 
// El método tendrá que comprobar si la string introducida por el usuario pertenece a la enumeración, 
// si pertenece devolverá el elemento de la enumeración que coincida, si nó mostrará todos los elementos de la enumeración y volverá a pedir el string al usuario.
// Este método tendrá la siguiente signatura:

// public static Object LeerEnum(Type tipo, string texto, string textoError);
// Donde:

// tipo: El tipo de la enumeración obtenido con la función typeof(IdentificadorEnumeracion).
// texto: El texto que se muestra para pedir al usuario que introduzca el valor de la enumeración.
// textoError: El texto que se mostrará si el valor que se introduce no pertenece a la enumeración.
// Modifica el Ejercicio 2 para usar el método LeeEnum a la hora de recoger el tipo de Abono a comprar.

// 👉Pista: Este método utilizará Enum.IsDefined para comprobar si el valor pertenece a la enumeración, 
// Enum.Parse para convertir el string a tipo Enum y Enum.GetNames para crear el array que se mostrará en caso de que el dato sea erróneo.

namespace ejercicio3
{
    class Program
    {
        enum TipoAbono
        {
            QuinceDias = 70, 
            TreintaDias = 60, 
            FamiliasNumerosas = 50,
            TerceraEdad = 30, 
            Discapacidad = 20, 
            Juvenil = 65, 
            Infantil = 35, 
            Turistico = 90
        }

        static Object LeerEnum(Type tipo, string texto, string textoError)
        {
            Object valorEnum = null;
            bool entradaValida;
            do
            {
                Console.Write(texto);
                string entradaUsuario = Console.ReadLine();
                entradaValida = Enum.IsDefined(tipo, entradaUsuario);

                if (entradaValida)
                {
                    valorEnum = Enum.Parse(tipo, entradaUsuario);
                }
                    
                else
                {
                    Console.Write(textoError);
                    string salida = "\nSólo se aceptan abonos de tipo:\n" + string.Join(", ", Enum.GetNames(tipo));
                    Console.WriteLine(salida);
                }
            }
            while (entradaValida == false);
            return valorEnum;
        }

        static int LeeDias()
        {
            int numeroDias;
            const int MINIMO_DIAS = 7;
            const int MAXIMO_DIAS = 60;

            do
            {
                Console.Write("\nPara cuántos días quiere el abono? ");
                numeroDias = int.Parse(Console.ReadLine());
                if (numeroDias >= 7 && numeroDias <= 60) return numeroDias;
                Console.WriteLine($"\nERROR! Valor no válido, los abonos deben ser de {MINIMO_DIAS} a {MAXIMO_DIAS} días.");
            } 
            while (true);
        }

        static int Dias(TipoAbono abono)
        {
            return abono switch
            {
                TipoAbono.QuinceDias => 15,
                TipoAbono.TreintaDias => 30,
                _ => LeeDias()
            };
        }        

        static string CalculaCoste(TipoAbono abono, int numeroDias)
        {
            string salida = "\nEl total del precio del abono es de " ;
            salida += abono switch 
            {
                TipoAbono.QuinceDias => (70f / 100f * numeroDias).ToString(),
                TipoAbono.TreintaDias => (60f / 100f * numeroDias).ToString(),
                TipoAbono.FamiliasNumerosas => (50f / 100f * numeroDias).ToString(),
                TipoAbono.TerceraEdad => (30f / 100f * numeroDias).ToString(),
                TipoAbono.Discapacidad => (20f / 100f * numeroDias).ToString(),
                TipoAbono.Juvenil => (65f / 100f * numeroDias).ToString(),
                TipoAbono.Infantil => (35f / 100f * numeroDias).ToString(),
                TipoAbono.Turistico => (90f / 100f * numeroDias).ToString(),
                _ => (120f / 100f * numeroDias).ToString()
            };
            return salida;
        }

        static void Main(string[] args)
        {
            string textoPrueba = "\nIntroduzca el tipo de abono: ";
            string textoError = "\nERROR! Tipo de abono inexistente.\n";
            TipoAbono abono = (TipoAbono)LeerEnum(typeof(TipoAbono), textoPrueba, textoError);
            Console.WriteLine($"{CalculaCoste(abono, LeeDias())} euros.\n");
        }
    }
}