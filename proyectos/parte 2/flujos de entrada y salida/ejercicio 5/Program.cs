using System;
using System.IO;
using System.Text;

// Davide Presti
// - Ejercicio 5 - 
// Escribe un programa que cree un fichero de texto de nombre datos.txt , que se encuentre en
// la carpeta datos del directorio raíz de la unidad C:.
// El programa deberá comprobar si la carpeta existe y si no es así la creará.
// En ese fichero iremos guardando carácter a carácter lo que se introduzca por teclado
// usando un adaptador BinaryWriter .
// Finalizaremos la introducción de caracteres al pulsar la tecla ESC .

namespace ejercicio5
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] caracter = new char[1];
            string ruta = @"C:\datos";
            bool continuar = true;

            if (!Directory.Exists(ruta))
            {
                Directory.CreateDirectory(ruta);
                Console.WriteLine($"\nDirectorio creado con exito. {Directory.GetCreationTime(ruta)}\n");
            }
            else
            {
                Console.WriteLine($"\nAtención... El directorio ya existe y se creó en la fecha {Directory.GetCreationTime(ruta)}\n");
            }

            FileStream file = new FileStream(@"C:\datos\datos.txt", FileMode.Create, FileAccess.ReadWrite);
            BinaryWriter binaryWriter = new BinaryWriter(file, Encoding.UTF8);
           
            Console.Write("Introduzca un texto aquí: ");

            while (continuar)
            {
                var tecla = Console.ReadKey(true);
                if (tecla.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("\n\nPrograma finalizado.\n");
                    continuar = false;
                }
                if (tecla.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    binaryWriter.Write("\n");
                }
                if (tecla.Key == ConsoleKey.Backspace && caracter.Length > 0 && file.Length > 0) 
                { 
                    Console.Write("\b \b"); 
                    file.SetLength(file.Length - 1); 
                }
                if (tecla.Key != ConsoleKey.Backspace && tecla.Key != ConsoleKey.Escape && tecla.Key != ConsoleKey.Enter)
                {
                    caracter = new char[1];
                    caracter[0] = tecla.KeyChar;
                    Console.Write(caracter[0]);
                    binaryWriter.Write(caracter[0]);
                    binaryWriter.Flush();
                }
            }
            binaryWriter.Close();
        }
    }
}