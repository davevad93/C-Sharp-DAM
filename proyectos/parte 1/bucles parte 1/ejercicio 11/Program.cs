using System;

// DAVIDE PRESTI 
// - Ejercicio 11 -

// Realiza un programa que sea capaz de sumar, restar, multiplicar y dividir.
// El programa presentará un menú con las cuatro operaciones que puede realizar.
// Saldrá del programa con la tecla ESC.

// Tip: Para controlar que se ha pulsado la tecla ESC podemos usar la instrucción Console.ReadKey()
// en un esquema similar a la siguiente propuesta dentro del bucle...


namespace ejercicio11
{
    class Program
    {
        static void Main(string[] args)
        {
            bool escape = false;
            char opcion;
            string linea;
            int numero1, numero2;
            double resultado;
            
            while (!escape) 
            {
                Console.WriteLine("\n|>|>| MENÚ PROGRAMA |<|<|");
                Console.WriteLine("\n1 - Sumar\n2 - Restar\n3 - Multiplicar\n4 - Dividir\nEsc - Salir\n");
                var tecla = Console.ReadKey();
                escape = tecla.Key == ConsoleKey.Escape;
                opcion = tecla.KeyChar;
                resultado = opcion;

                if (!escape)
                {
                    if (opcion != '1' && opcion != '2' && opcion != '3' && opcion != '4' )
                    {
                        linea = "\nERROR! elija otra opción (1-4).";
                    }
                    
                    else
                    {
                        Console.Write("\nIntroduzca un número: ");
                        numero1 = int.Parse(Console.ReadLine());
                        Console.Write("Introduzca otro número: ");
                        numero2 = int.Parse(Console.ReadLine());

                        if (opcion == '1')
                        {
                            double suma = numero1 + numero2;
                            resultado = suma;
                            linea = $"\n{numero1} + {numero2} = {resultado}";
                        }

                        else if (opcion == '2')
                        {
                            double resta = numero1 - numero2;
                            resultado = resta;
                            linea = $"\n{numero1} - {numero2} = {resultado}";
                        }

                        else if (opcion == '3')
                        {
                            double multiplicacion = numero1 * numero2;
                            resultado = multiplicacion;
                            linea = $"\n{numero1} * {numero2} = {resultado}";
                        }
                        
                        else if (numero1 == 0 || numero2 == 0)
                        {
                            linea = "\nERROR! No se puede dividir entre cero.";
                        }
                        
                        else
                        {
                            double division = numero1 / numero2;
                            resultado = division;
                            linea = $"\n{numero1} / {numero2} = {resultado}";
                        }
                    }
                }
                
                else
                {
                    linea = "Has pulsado 'Esc', programa finalizado.";
                }
                Console.WriteLine(linea);   
            }   
        }
    }
}   