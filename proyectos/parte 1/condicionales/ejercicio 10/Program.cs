using System;

// DAVIDE PRESTI
// - Ejercicio 10 -

// Modifica el programa anterior de forma que ahora además, se deba tener en cuenta la nota de prácticas para realizar la média, siendo ambas exactas.
// El resultado será una nota numérica que puede tener decimales, además tanto en las prácticas como en los exámenes solo se podrán evaluar con tres notas (4, 7, 10).

// Con todo esto y las siguientes valoraciones, calcula la nota numérica final:

// Si la nota del examen es 4, la nota será la misma que la del examen independientemente de la de las prácticas.
// Si la nota del examen es 7 y la de prácticas es mayor o igual a 7 la nota será la media entre ambas
// Si la nota del examen es 7 y la de prácticas es 4 la nota final será 5
// Si la nota del examen es 10 y la de prácticas menor o igual a 7 la nota final será 9
// Si la nota del examen es 10 y la de prácticas es 10, la nota final será 11
// Se indicará nota incorrecta en caso de introducir una nota no permitida y podemos usar una ternaria y la variable notaFinal nullable.

// Nota: Para hacer este ejercicio deberás usar la expresión switch de C#8 con tuplas

namespace ejercicio10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Introduzca su nota de examen: ");
            int examen = int.Parse(Console.ReadLine());
            Console.Write("\nIntroduzca su nota de prácticas: ");
            int practicas = int.Parse(Console.ReadLine());

            double? notaFinal; 
            switch (examen)
            {
                case 4 when practicas == 4 || practicas == 7 || practicas == 10:
                notaFinal = 4;
                break;

                case 7 when practicas == 7 || practicas == 10:
                notaFinal = (examen + practicas);
                notaFinal = notaFinal / 2;
                break;

                case 7 when practicas == 4:
                notaFinal = 5;
                break;

                case 10 when practicas == 7 || practicas == 4:
                notaFinal = 9;
                break;

                case 10 when practicas == 10:
                notaFinal = 11;
                break;

                default:
                notaFinal = null;
                break;
            }
            notaFinal = notaFinal ?? 0;
            string linea = notaFinal >= 4
                            ? $"\nTu nota final es {notaFinal}"
                            : $"\nERROR! Nota incorrecta.";
            Console.WriteLine(linea);
        }
    }
}