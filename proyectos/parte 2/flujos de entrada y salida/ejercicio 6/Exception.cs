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
    public class Exception : System.Exception
    {
        public Exception(string message, System.Exception inner) : base(message, inner) {}
    }
}