using System;

// DAVIDE PRESTI
// - Ejercicio 5 -
// Crea una aplicación para gestionar la personalización de coches en un determinado taller.

// Tendrás que utilizar Enumeraciones NO excluyentes, 
// debes definir la enumeración con un mínimo de 7 colores (incluido el None).
// La aplicación permitirá añadir un color o más a la elección, 
// eliminar un color de los que ya se habían elegido y mostrar los colores elegidos.
// El programa comenzará mostrando un menú, con las tres opciónes y la que nos permita salir.
// Nota: Deberás usar el método LeeEnum, para introducir los datos que se piden al usuario 
// y tendrás que crear, como mínimo, un método para cada una de las posibles opciones del menú.

namespace ejercicio5
{
    class Program
    {
        [Flags]
        enum ColoresCoche
        {
            None = 0b_0000_0000,
            Negro = 0b_0000_0001,
            Blanco = 0b_0000_0010,
            Gris = 0b_0000_0100,
            Rojo = 0b_0000_1000,
            Naranja = 0b_0001_0000,
            Amarillo = 0b_0010_0000,
            Verde = 0b_0100_0000,
        }

        static Object LeerEnum(Type tipo, string texto, string textoError)
        {
            Object valorEnum;
            bool entradaValida;
            do
            {
                string valoresValidos = string.Join(", ", Enum.GetNames(tipo));
                string entradaUsuario;

                Console.Write($"{texto} ({valoresValidos}): ");
                entradaUsuario = Console.ReadLine();
                entradaValida = Enum.IsDefined(tipo, entradaUsuario);

                if (entradaValida)
                    valorEnum = Enum.Parse(tipo, entradaUsuario);
                else
                {
                    valorEnum = null;
                    Console.WriteLine($"{textoError}, sólo se aceptan los siguientes valores:\n{valoresValidos}\n");
                }
            }
            while (entradaValida == false);
            return valorEnum;
        }

        static ColoresCoche LeeColor()
        {
            string texto = "Selecciona un color:";
            string textoError = "\nColor seleccionado incorrecto";
            return (ColoresCoche)LeerEnum(typeof(ColoresCoche), texto, textoError);
        }

        static ColoresCoche AñadeColor(ColoresCoche estado)
        {
            estado |= LeeColor();
            return estado;
        }

        static ColoresCoche QuitaColor(ColoresCoche estado)
        {
            estado &= ~LeeColor();
            return estado;
        }

        static void MuestraColores(ColoresCoche estado)
        {
            Console.WriteLine($"Colores seleccionados: {estado} ({Convert.ToString((byte)estado, 2).PadLeft(8, '0')})\n");
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            ColoresCoche estado = default;
            bool salir = true;
            
            do
            {
                Console.WriteLine("\n<|>|<|> MENÚ COLORES <|>|<|>\n" +
                                  "\n1. Añadir color.\n2. Quitar color." +
                                  "\n3. Mostrar colores seleccionados.\nESC. Salir.\n");
                var tecla = Console.ReadKey(true);
                salir = tecla.Key == ConsoleKey.Escape;

                switch (tecla.KeyChar)
                {
                    case '1':
                            estado = AñadeColor(estado);
                            break;
                    case '2':
                            estado = QuitaColor(estado);
                            break;
                    case '3':
                            MuestraColores(estado);
                            break;
                    default:
                        if (tecla.Key == ConsoleKey.Escape)
                            Console.WriteLine("Programa finalizado.\n");
                        else
                            Console.WriteLine("ERROR! Opción inexistente.\n");
                            break; 
                }
            }
            while (!salir);
        }
    }
}