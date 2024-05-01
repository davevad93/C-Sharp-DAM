using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// DAVIDE PRESTI
// - Ejercicio 2 -

// Vamos a crear una clase denominada Biblioteca que tendrá como propiedades: un Nombre
// de tipo string y una lista genérica de libros Libros .
// Su contractor recibirá el nombre y la lista de libros que hemos creado en el ejercicio
// anterior.
// 📌 Nota: Usa la clase Libro creada en el ejercicio anterior.
// Crea un método público denominado BuscaPorISBN que reciba una cadena con el ISBN y
// devuelva el primer libro con ese ISBN o null si no lo encuentra.
// Primero vamos a practicar con el concepto 'de tipos anónimos' para guardar solo los
// datos referentes a un préstamo de un Libro en un fichero. Sin definir una nueva clase
// o tipo Préstamo.
// Para ello, vamos a crear un método público en la clase Biblioteca denominado
// Presta . Este método recibirá dos string : dni del socio ISBN del libro a > prestar.
// Buscaremos el ISBN en la lista de libros y si lo encontramos, crearemos un nuevo
// objeto anónimo var préstamo con las propiedades DNI , Titulo e ISBN .
// 📌 Nota: En caso de no existir el lSBN en la biblioteca generaremos una
// BliblitecaException con el mensaje correspondiente.
// Por último, añadiremos a un fichero denominado prestamos.txt la cadena resultado
// de pasar a ToString este objeto anónimo seguida de un salto de línea.
// 📌 Nota: Gestionaremos el acceso al fichero con una o más sentencias using.
// Crea otro método público EstaPrestado al que se le pasará el ISBN de un libro y
// devolverá un Booleano que nos indicará si el libro se encuentra prestado o no,
// 📌 Nota: Gestionaremos el acceso al fichero con una o más sentencias using . Además,
// se puede usar, por ejemplo, el método Contains de la clase string.
// Crea un método público CuentaLibrosConNumeroDePaginasMenorA que reciba un valor
// entero y te devuelva la cantidad de líbros con un número de páginas menor a ese valor
// entero.
// Crea un método público EliminaPorAutor que reciba el nombre de un autor y borre de la
// biblioteca aquellos libros de ese autor.
// Redefine el método ToString() en Libro creando un tipo anónimo con Libro ,
// Autor , e ISBN y devolviendo su ToString.

namespace ejericio2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var libros = new List<Libro>()
                {
                    new Libro("Don Quijote de la Mancha", "Miguel de Cervantes", 765, "9788441405298"),
                    new Libro("El camino", "Miguel Delibes", 187, "9788467023664"),
                    new Libro("Cien años de soledad", "Gabriel García Márquez", 448, "9788420471839"),
                    new Libro("La Regenta", "Leopoldo Alas Clarín", 182, "9788484326977"),
                    new Libro("Los mejores cuentos de Clarín", "Leopoldo Alas Clarín", 145, "9788431533441")
                };
                Biblioteca biblioteca = new Biblioteca("EL RINCÓN DE LEER", libros);
                biblioteca.Presta("22111333", "9788420471839");
                biblioteca.Presta("22111333", "9788431533441");
                Console.WriteLine(biblioteca.EstaPrestado("9788420471839"));
                Console.WriteLine(biblioteca.EstaPrestado("22111444"));
                Console.WriteLine(biblioteca.BuscaPorISBN("9788431533441"));
                Console.WriteLine(biblioteca.BuscaPorISBN("97884551533441"));
                Console.WriteLine(biblioteca.CuentaLibrosConNumeroDePaginasMenorA(400));            
                Console.WriteLine(biblioteca.BuscaPorISBN("9788467023664"));
                biblioteca.EliminaPorAutor("Miguel Delibes");
                Console.WriteLine(biblioteca.BuscaPorISBN("9788467023664"));
            }
            catch (BibliotecaException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}