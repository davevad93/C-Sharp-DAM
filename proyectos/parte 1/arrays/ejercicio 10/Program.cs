using System;

// DAVIDE PRESTI
// - Ejercicio 10 -

// Introduce por teclado una secuencia de calificaciones de los alumnos de un instituto
// (números enteros entre cero y diez).
// La secuencia termina con la introducción de un número menor que cero o mayor que
// diez.
// Se supone que como máximo podemos tener 25 alumnos.
// Se trata de obtener la frecuencia de las notas (número de veces que cada nota
// aparece).
// 👉Pista: Puedes usar un array para guardar las frecuencias, relacionando la posición del
// array con la nota del alumno.

namespace ejercicio10
{
    class program
    {
        static int NumeroDeAlumnos()
        {
            int alumnos = 0;
            bool error = true;

            while (error)
            {
                Console.Write("Introduzca el número de alumnos (máximo 25): ");
                alumnos = int.Parse(Console.ReadLine());

                if (alumnos > 25 || alumnos <= 0)
                {
                    Console.WriteLine("ERROR! Datos introducidos erróneos.");
                    error = true;
                }
                else
                {
                    error = false;
                }
            }
            return alumnos;
        }
        
        static int[] NotasDeAlumnos(int[] notas, int alumnos)
        {
            int[] frecuenciaNotas = new int[11];
            notas = new int[alumnos];
            bool error = true;
            
            for (int i = 0; i < notas.Length; i++)
            {
                Console.Write("\nIntroduzca la nota del alumno: ");
                notas[i] = int.Parse(Console.ReadLine());
                error = notas[i] > 10 || notas[i] < 0;

                if (notas[i] >= 11 || notas[i] < 0)
                {
                    Console.WriteLine("\nERROR! La nota introducida no puede ser mayor que 10 o inferior a 0.");
                    break;
                }
                
                if (notas[i] == notas[i])
                {
                    frecuenciaNotas[notas[i]]++;
                    error = true;
                }
            }
            return frecuenciaNotas;                        
        }
        
        static void Main(string[] args)
        {
            int[] frecuenciaNotas = new int[11];
            int alumnos = NumeroDeAlumnos();
            int[] notas = new int[alumnos];
            frecuenciaNotas = NotasDeAlumnos(notas, alumnos);
            
            for (int i = 0; i < frecuenciaNotas.Length; i++)
            {
                if (frecuenciaNotas[i] != 0)
                {
                    if (frecuenciaNotas[i] != 1)
                    {
                        Console.WriteLine($"\n{frecuenciaNotas[i]} alumnos han sacado un {i} de nota.");
                    }
                    else
                    {
                        Console.WriteLine($"\n{frecuenciaNotas[i]} alumno ha sacado un {i} de nota.");
                    }
                    Console.WriteLine($"Frecuencia de la nota: {frecuenciaNotas[i]}");
                }
            }
        }
    }
}