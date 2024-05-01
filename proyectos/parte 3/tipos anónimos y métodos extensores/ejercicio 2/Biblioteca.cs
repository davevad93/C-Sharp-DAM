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
    class Biblioteca
    {
        public string Nombre {get;}
        public List<Libro> Libros {get;}

        public Biblioteca(string nombre, List<Libro> libros)
        {
            Nombre = nombre;
            Libros = libros;
        }

        public Libro BuscaPorISBN(string isbn)
        {
            foreach (Libro libro in Libros)
            {
                if (libro.ISBN == isbn)
                {
                    return libro;
                }
            }
            return null;
        }

        public void Presta(string dni, string isbn)
        {
            var libro = BuscaPorISBN(isbn);
            if (libro == null)
            {
                throw new BibliotecaException($"Lo siento, el libro con ISBN {isbn} no está en la biblioteca.");
            }
            
            var prestamo = new {DNI = dni, Titulo = libro.Titulo, ISBN = isbn};
            using (var sw = new StreamWriter("prestamos.txt", true))
            {
                sw.WriteLine(prestamo);
            }
        }

        public bool EstaPrestado(string isbn)
        {
            using (var lector = new StreamReader("prestamos.txt"))
            {
                string linea;
                while ((linea = lector.ReadLine()) != null)
                {
                    if (linea.Contains(isbn))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public int CuentaLibrosConNumeroDePaginasMenorA(short numPaginas)
        {
            int contador = 0;
            foreach (Libro libro in Libros)
            {
                if (libro.NumPaginas < numPaginas)
                {
                    contador++;
                }
            }
            return contador;
        }

        public void EliminaPorAutor(string autor)
        {
            for (int i = Libros.Count - 1; i >= 0; i--)
            {
                if (Libros[i].Autor == autor)
                {
                    Libros.RemoveAt(i);
                }
            }
        }
    }
}