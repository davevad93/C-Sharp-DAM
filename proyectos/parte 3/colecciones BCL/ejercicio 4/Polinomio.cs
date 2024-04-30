using System.Text.RegularExpressions;

// DAVIDE PRESTI
// - Ejercicio 4 -
// Crea una clase Polinomio que guarde los datos de un polinomio en un diccionario genérico ordenado.
// 9^7 - 3^3 - 7^+5
// Por ejemplo el polinomio se guardaría en una propiedad privada automática de forma equivalente a esta ...
// private SortedDictionary<int, int> Monomios { get; set; }
// // Guardando el polinomio en un diccionario de la siguiente forma ...
// Monomios = new SortedDictionary<int, int>() { {0, 5}, {1, -7}, {3, -3}, {7, 9} };

// Donde cada monomio (c^e) se guardan en orden inverso, la "clave" es el exponente e` y el "valor" el coeficiente c.
// El constructor de la clase polinomio lo recibirá una cadena de la siguiente forma: "9x7-3x3-7x+5" y su método string ToString() lo mostrará de forma análoga.
// Define un método de clase estático y publico llamado Suma donde entren dos objetos polinomios en forma devuelva otro con el resultado de la suma de tal manera que si en el programa principal quiero hacer la siguiente suma ...
// (9^7 - 3^3 - 7^+5) + (4^2-1) = 9^7 - 3^3 + 4^2 - 7^+4
// Tendré que escribir el siguiente código ...
// Polinomio suma = Polinomio.Suma(new Polinomio("9x7-3x3-7x+5"), new Polinomio("4x2-1"));
// Console.WriteLine(suma);

// y su ejecución mostrará ... 9x7-3x3+4x2-7x+4
// Recuerda que internamente tendremos en cada objeto polinomio una colección equivalente a las siguientes...
// // polinomio 1
// new SortedDictionary<int, int>(){{ 0, 5 }, { 1, -7 }, { 3, -3 }, { 7, 9 }};
// // polinomio 2
// new SortedDictionary<int, int>(){{ 0, -1 }, { 2, 4 }};
// // suma
// new SortedDictionary<int, int>() {{ 0, 4 }, { 1, -7 }, { 2, 4 }, { 3, -3 }, { 7, 9 }};


// 💡 Pista:
// Para inicializar el diccionario con el polinomio en el constructor que recibe una cadena con el polinomio, habrá diferentes propuestas. Pero lo más lógico sería usar expresiones regulares.
// ¿Cómo extraer lo monomios de una cadena con un polinomio de entrada usando una expresión regular?
// Lo más lógico es hacer un match de los diferentes monomios con la forma c^e en la cadena de entrada.
// Una propuesta de expresión regular sería la siguiente ...
// 1. Definimos un grupo para el coeficiente que puede estar (c^e) o no (^e). Además, si hay coeficiente este puede ser un signo solo o tener valor numérico -^e (c = -1), -3^e (c = -3), +^e (c = 1), +3^e o 3^e (c = 3). 
// Una posibilidad sería string grupoCoeficiente = @"(<grupoCoeficiente>[+-]?\d*)?"; aunque admita la cadena vacía nos valdría como simplificación. 
// 2. Definimos un grupo para el incógnita que puede estar (c^e) o no (c) Una posibilidad sería string grupoIncognita = @"(<grupoIncognita>[xX])?"; Su interpretación sería: Si no hay incógnita x o X entonces el exponente es 0 y en caso contrário es mayor que cero. (No admitiremos negativos). 
// 3. Definimos un grupo para el exponente que puede estar (c^e) o no (c, c^) Una posibilidad sería string grupoExponente = @"(<grupoExponente>[1-9]|\d*)?"; Su interpretación sería: Si no hay exponente entonces este puede ser 0 o 1 dependiendo de si hay incógnita o no y si lo hay tomará el valor entero del grupo. 
// 4. Por tanto el patrón para ir buscando los monomios en la cadena e ir inicializando el polinomio quedaría ... 
// string patronMonomio = $"{grupoCoeficiente}{grupoIncognita}{grupoExponente}"; 
// 🚀 Ampliación: Redefine el operador + y úsalo en lugar de la función suma. 

namespace ejercicio4
{
    class Polinomio
    {
        private SortedDictionary<int, int> Monomios {get; set;}

        public Polinomio(string polinomio)
        {
            Monomios = new SortedDictionary<int, int>();
            string grupoCoeficiente = @"(?<grupoCoeficiente>[+-]?\d*)?";
            string grupoIncognita = @"(?<grupoIncognita>[xX])?";
            string grupoExponente = @"(?<grupoExponente>[1-9]|\d*)?";
            string patronMonomio = $"{grupoCoeficiente}{grupoIncognita}{grupoExponente}";
            Regex regex = new Regex(patronMonomio);
            Match match = regex.Match(polinomio);

            while (match.Success)
            {
                if (match.Value != "")
                {
                    var stringCoeficiente = match.Groups["grupoCoeficiente"].Value;
                    var stringIncognita = match.Groups["grupoIncognita"].Value.Length > 0;
                    var stringExponente = match.Groups["grupoExponente"].Value;
                    int coeficiente;

                    switch (stringCoeficiente)
                    {
                        case "":
                        case "+":
                            coeficiente = 1;
                            break;
                        case "-":
                            coeficiente = -1;
                            break;
                        default:
                            coeficiente = int.Parse(stringCoeficiente);
                            break;
                    }

                    int exponente;
                    switch (stringExponente)
                    {
                        case "":
                            exponente = stringIncognita ? 1 : 0;
                            break;
                        default:
                            exponente = int.Parse(stringExponente);
                            break;
                    }
                    Monomios.Add(exponente, coeficiente);
                }
                match = match.NextMatch();
            }
        }

        public override string ToString()
        {
            string polinomio = "";
            foreach (KeyValuePair<int, int> monomio in Monomios)
            {
                string signo = monomio.Value >= 0 ? "+" : "-";
                string coeficiente = Math.Abs(monomio.Value) == 1 ? "" : Math.Abs(monomio.Value).ToString();
                string incognita = monomio.Key == 0 ? "" : "x";
                string exponente = monomio.Key <= 1 ? "" : monomio.Key.ToString();
                polinomio += $"{signo}{coeficiente}{incognita}{exponente}";
            }
            return polinomio[0] == '+' ? polinomio.Substring(1) : polinomio;
        }

        public static Polinomio Suma(Polinomio p1, Polinomio p2)
        {
            foreach (var monomio in p2.Monomios)
            {
                if (p1.Monomios.TryGetValue(monomio.Key, out int valor))
                {
                    p1.Monomios[monomio.Key] = valor + monomio.Value;
                }
                else
                {
                    p1.Monomios[monomio.Key] = monomio.Value;
                }
            }
            return p1;
        }


        public static Polinomio operator +(Polinomio p1, Polinomio p2)
        {
            Polinomio resultado = new Polinomio("");
            foreach (KeyValuePair<int, int> monomio in p1.Monomios)
            {
                resultado.Monomios[monomio.Key] = monomio.Value;
            }

            foreach (KeyValuePair<int, int> monomio in p2.Monomios)
            {
                if (resultado.Monomios.ContainsKey(monomio.Key))
                {
                    resultado.Monomios[monomio.Key] += monomio.Value;
                }
                else
                {
                    resultado.Monomios[monomio.Key] = monomio.Value;
                }
            }
            return resultado;
        }
    }
}