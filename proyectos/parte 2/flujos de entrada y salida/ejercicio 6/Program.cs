using System;
using System.IO;

// DAVIDE PRESTI
// - Ejercicio 6 -
// Crea una clase Microprocesador con tres atributos privados modelo, nucleos y frecuencia.
// La clase tendrá el constructor necesario para crear un microprocesador con todos los datos y
// la anulación del ToString para mostrar la instancia de la forma:
// Modelo: Intel Core I7
// Nucleos: 4
// Frecuencia: 3.6
// En la clase también crearemos un método ACSV que devolverá un string con los datos del
// microprocesador separados por ; , para la instancia anterior la salida sería:
// Intel Core I7;4;3.6
// Otro de los métodos será AMicroprocesador, este método será de clase y le llegará una
// cadena con el formato de la anterior, se encargará de sacar la información para crear un
// microprocesador (puedes usar el método Split de cadena) y devolverlo.
// Por otro lado, en la clase del programa principal tendremos los métodos necesarios que
// permitan:
// Devolver un array de microprocesadores con los datos recogidos por teclado.
// Guardar en un fichero llamado microprocesadores.csv cada uno de los
// microprocesadores en líneas distintas y con sus datos separados por ; , para ello
// usaremos el método de la clase Microprocesador ACSV. Este método guardará un 
// microprocesador cada vez, por lo que tendrá que abrir el fichero para añadir al final.
// Leer todo el fichero microprocesadores.csv y devolverá un array con los
// microprocesadores leídos, para ello usará el método AMicroprocesador de la clase 
// Microprocesador.
// Realiza un programa principal que permita recoger, guardar y leer de fichero y mostrar los
// microprocesadores leídos.

namespace ejercicio6
{
    class Program
    {
        private enum teclaOpcion {Introducir = 1, Mostrar = 2, Salir = 3}

        static void Menu()
        {
            Console.WriteLine($"{(int)teclaOpcion.Introducir} - Introducir Microprocesador.");
            Console.WriteLine($"{(int)teclaOpcion.Mostrar} - Mostrar Microprocesadores.");
            Console.WriteLine($"{(int)teclaOpcion.Salir} - Salir.");
        }
        static teclaOpcion AMicroprocesador()
        {
            bool valida;
            teclaOpcion opcion = default;
            do
            {
                Console.Write("\nIntroduzca una opción: ");
                valida = int.TryParse(Console.ReadLine(), out int valor);

                if (valida)
                {
                    valida = Array.IndexOf(Enum.GetValues(typeof(teclaOpcion)), (teclaOpcion)valor) > -1;
                }    
                if (valida)
                {
                    opcion = (teclaOpcion)valor;
                }    
                else
                {
                    Console.WriteLine("\nERROR! Opción no válida.");
                }    
            }
            while (!valida);
            return (teclaOpcion)opcion;
        }

        static void IntroduceMicroprocesador(string fichero)
        {
            Console.Write("\nModelo: ");
            string modulo = Console.ReadLine();
            Console.Write("Núcleos: ");
            int nucleo = int.Parse(Console.ReadLine());
            Console.Write("Frecuencia: ");
            double frecuencia = double.Parse(Console.ReadLine());
            new Microprocesador(modulo, nucleo, frecuencia).ACSV(fichero);
            Console.WriteLine("\nDatos guardados con exito.\n");
        }

        static void Main(string[] args)
        {
            const string FICHERO = "Microprocesadores.csv";
            teclaOpcion opcion = teclaOpcion.Salir;
            do
            {
                bool pausa = true;
                try
                {
                    Menu();
                    opcion = AMicroprocesador();
                    switch (opcion)
                    {
                        case teclaOpcion.Introducir:
                            IntroduceMicroprocesador(FICHERO);
                            break;
                        case teclaOpcion.Mostrar:
                            if (File.Exists(FICHERO))
                            {
                                var microprocesador = Microprocesador.AMicroprocesador(FICHERO);
                                if (microprocesador != null)
                                {
                                    for (int i = 0; i < microprocesador.Length; i++)
                                    {
                                        Console.WriteLine(microprocesador[i]);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"\nEl fichero {FICHERO} está vacío.\n");
                                }    
                            }
                            else
                            {
                                Console.WriteLine($"\nEl fichero {FICHERO} todavía no existe.\n");
                            }    
                            break;
                        case teclaOpcion.Salir:
                            Console.WriteLine("\nPrograma finalizado.");
                            pausa = false;
                            break;
                    }
                }
                catch (System.Exception e)
                {
                    while (e != null)
                    {
                        Console.WriteLine(e.Message);
                        e = e.InnerException;
                    }
                }

                if (pausa)
                {
                    Console.WriteLine("Pulsa una tecla...");
                    Console.ReadKey(true);
                    Console.Clear();
                }
            }
            while (opcion != teclaOpcion.Salir);
        }
    }
}