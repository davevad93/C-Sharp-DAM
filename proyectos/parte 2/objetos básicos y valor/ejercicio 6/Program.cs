using System;

// DAVIDE PRESTI
// - Ejercicio 6 -
// A partir del primer ejercicio y teniendo en cuenta la relación entre las clases, crea las claseEmpresa.
// 📌Nota:
// El método DatosEmpresa de Empresa devolverá la información de la empresa sin los empleados, 
// mientras que ACadena incluirá los empleados.
// Una posible salida sería:
// La Empresa S.L
// María Soto del Rio
// Calle el Pozo, 34 Bajo
// El empleado María Soto del Rio con dni: 23453456L tiene un salario 1920 y su categoria es: Gerente
// El empleado Juanma Perez Ortiz con dni: 14568712G tiene un salario 1440 y su categoria es: Administrativos
// El empleado Pedro Martinez Sancho con dni: 12346123K tiene un salario 1440 y su categoria es: Administrativos

namespace ejercicio6
{
  class Program
    {
        static void Main(string[] args)
        {
            Empleado Empleado1 = new Empleado("23453456L", "María Soto del Rio", 1980);
            Empleado Empleado2 = new Empleado("14568712G", "Juanma Perez Ortiz", 1993);
            Empleado Empleado3 = new Empleado("12346123K", "Pedro Martinez Sancho", 1988);
            Empresa empresa = new Empresa("La Empresa S.L", "C23456732A", "Calle el Pozo, 34 Bajo", "23453456L", "María Soto del Rio", 1980, Empleado1);
            empresa.Contrata("14568712G", "Juanma Perez Ortiz", 1993, "Administrativo", Empleado2);
            empresa.Contrata("12346123K", "Pedro Martinez Sancho", 1988, "Administrativo", Empleado3);
            Console.WriteLine($"{empresa.ACadena()}\n");
        }
    }
}