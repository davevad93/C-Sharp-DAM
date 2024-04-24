using System;
using System.IO;
using System.Text;

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
    public class Microprocesador
    {
        readonly private string modelo;
        readonly private int nucleos;
        readonly private double frecuencia;
        
        public string GetModelo()
        {
            return modelo;
        }
        public int GetNucleos()
        {
            return nucleos;
        }
        public double GetFrecuencia()
        {
            return frecuencia;
        }

        public string ACSV(string fichero)
        {
            using FileStream stream = new FileStream(fichero, FileMode.Append, FileAccess.Write);
            using StreamWriter sw = new StreamWriter(stream, Encoding.UTF8);

            if (stream.Length == 0)
            {
                sw.WriteLine($"Modelo;Núcleo;Frecuencia");
            }    

            sw.WriteLine($"{GetModelo()};{GetNucleos()};{GetFrecuencia()}");
            sw.Flush();
            string datos = $"{GetModelo()};{GetNucleos()};{GetFrecuencia()}";
            return datos;    
        }

        private static Microprocesador AMicroprocesador(StreamReader sr)
        {
            string[] atributos = sr.ReadLine().Split(new char[] {';'});
            return new Microprocesador(atributos[0], int.Parse(atributos[1]), double.Parse(atributos[2]));
        }

        public static Microprocesador[] AMicroprocesador(string fichero)
        {
            Microprocesador[] microprocesador = default;
            using FileStream stream = new FileStream(fichero, FileMode.Open, FileAccess.Read);
            using StreamReader sr = new StreamReader(stream, Encoding.UTF8);
            sr.ReadLine();

            int contador = 0;
            while (!sr.EndOfStream)
            {
                if (microprocesador != null)
                {
                    Array.Resize(ref microprocesador, microprocesador.Length + 1);
                }
                else
                {
                    Array.Resize(ref microprocesador, 1);
                }

                microprocesador[contador] = AMicroprocesador(sr);
                contador += 1;
            }
            return microprocesador;
        }

        public Microprocesador(string modelo, in int nucleo, in double frecuencia)
        {
            this.modelo = modelo;
            this.nucleos = nucleo;
            this.frecuencia = frecuencia;
        }
        public override string ToString()
        {
            return $"\nModelo: {GetModelo()}\nNúcleos: {GetNucleos()}\nFrecuencia: {GetFrecuencia()}\n";
        }
    }
}