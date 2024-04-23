using System;
using System.IO;

// DAVIDE PRESTI
// - Ejercicio 3 -
// Vamos a crear algunos comandos similares a los del S.O., que nos ayuden a entender
// mejor el funcionamiento de las clases DirectoryInfo , FileInfo y sus homólogas de utilidad.
// Para ello deberemos crear distintos programas, de forma que cada uno haga una de las
// siguientes funciones. El nombre de cada proyecto será el nombre del comando y todos irán
// en una solución llamada ejercicio3 :

// 1. Comando listaCarpeta: Se encargará de mostrar el contenido del directorio actual si no
// se le indica ruta, o del directorio que se indique en la ruta. Sino existe el directorio, se
// capturará la excepción mostrando un mensaje de error.
// Puedes usar la funcionalidad de las enumeraciones excluyentes para conocer el tipo de
// elemento:
// recuerda, podemos saber que elemento es un archivo si hacemos algo como lo siguiente
// a.Attributes & FileAttributes.Archive==FileAttributes.Archive

namespace listaCarpeta
{
    class Program
    {
        static void Main(string[] args)
        {
            string ruta = default;
            try
            { 
                if (args.Length == 0)
                {
                    ruta = Directory.GetCurrentDirectory();
                }
                else if (args.Length == 1)
                {
                    ruta = args[0];
                }
                else
                {
                    Console.WriteLine("\nSe puede introducir sólo 1 ruta válida.\n");
                }                  
                
                DirectoryInfo contenidoCarpeta = new DirectoryInfo(ruta);
                FileSystemInfo[] infoCarpeta = contenidoCarpeta.GetFileSystemInfos();

                foreach (FileSystemInfo info in infoCarpeta)
                {
                    bool esCarpeta;
                    if (info.Attributes == FileAttributes.Directory)
                    {
                        esCarpeta = true;
                    }
                    else
                    {
                        esCarpeta = false;
                    }

                    string infos = String.Format($"{info.Name,30}\t{(esCarpeta ? "Carpeta" : "Archivo")} {info.CreationTime}");
                    Console.WriteLine(infos);
                }
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("\nERROR! Directorio inexistente.\n");
            }
        }
    }
}