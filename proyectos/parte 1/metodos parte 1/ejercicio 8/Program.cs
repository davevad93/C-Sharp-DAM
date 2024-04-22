using System;

// DAVIDE PRESTI
// - Ejercicio 8 -

// Escribe un método llamado Lee que que obtenga los siguientes datos de un usuario: número de
// departamento, coste por hora y horas trabajadas. Usarás tuplas para resolverlo
// Escribe un método llamado Salario que para calcular el salario semanal multiplique el coste por
// hora por el número de horas trabajadas.
// Escribe un método llamado Muestra que muestre el salario semanal, el número del
// departamento, el coste por hora y las horas trabajadas. Podéis fijaros en el siguiente DEM:
//
//                                    ----- Main -----
//                                   \/      \/      \/
//                                  Lee   Salario  Muestra

namespace ejercicio8
{
    class Program
    {
        static (int numeroDepartamento, double costeHora, int horasTrabajadas) Lee()
        {
            Console.Write("\nIntroduzca el número del departamento: ");
            int numeroDepartamento = int.Parse(Console.ReadLine());
            Console.Write("\nIntroduzca el coste de la hora: ");
            double costeHora = double.Parse(Console.ReadLine());
            Console.Write("\nIntroduzca las horas trabajadas: ");
            int horasTrabajadas = int.Parse(Console.ReadLine());
            return (numeroDepartamento, costeHora, horasTrabajadas);
        }
        
        static double Salario(double costeHora, int horasTrabajadas)
        {
            double salarioSemanal = costeHora * horasTrabajadas;
            return salarioSemanal;
        }

        static void Muestra(double salarioSemanal, int numeroDepartamento, double costeHora, int horasTrabajadas)
        {
            Console.Write($"\nBuenos días señor/a empleado/a, su salario semanal es de {salarioSemanal} euro/s, su número de departamento es el {numeroDepartamento} " +
                          $"\ny su salario por hora es de {costeHora} euro/s por trabajar un total de {horasTrabajadas} hora/s durante una semana.\n\n");            
        }

        static void Main(string[] args)
        {
            (int numeroDepartamento, double costeHora, int horasTrabajadas) = Lee();
            double salarioSemanal = Salario(costeHora, horasTrabajadas);
            Muestra(salarioSemanal, numeroDepartamento, costeHora, horasTrabajadas);
        }
    }
}