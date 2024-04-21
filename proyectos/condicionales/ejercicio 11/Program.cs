using System;

// DAVIDE PRESTI
// - Ejercicio 11 -

// Una empresa factura a sus clientes el último día de cada mes.

// Si el cliente paga del 1 al 10 del mes siguiente se le hace un descuento 
// de 50 centimos o del 10%, el que sea mayor.
// Si paga entre los días 11 y 20 no se le aplica ningún descuento.
// Si paga después del día 20 se le penaliza con 1 euro o el 5%, lo que sea mayor.
// Se desea un programa que lea los datos del cliente: nombre, dirección, CIF y el importe de la factura. 
// Tras ello, confeccione una carta dirigida al cliente informándole que tiene una factura pendiente de ...
// € y lo que deberá pagar según realice el pago del 1 al 10, del 11 al 20 o después del 20.

namespace ejercicio11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nombre del cliente: ");
            string nombre = Console.ReadLine();
            Console.Write("CIF del cliente: ");
            string cif = Console.ReadLine();
            Console.Write("Dirección del cliente: ");
            string direccion = Console.ReadLine();
            Console.Write("Importe a pagar del cliente: ");
            double importe = double.Parse(Console.ReadLine());

            string carta;
            double descuento = importe * 0.1;
            
            if (descuento < 0.5)
            {
                descuento = 0.5;
            }
            
            double penalizacion = importe * 0.05;
            if (penalizacion < 1)
            {
                penalizacion = 1;
            }
            	
            carta = $"\nEstimado/a {nombre} con CIF {cif} y domicilio en {direccion}, " +
                    $"\nse le informa que tiene una factura pendiente de {importe:F2} euros, " + 
                    $"\nsi usted paga entre los días 1 y 10 se le aplicará un descuento y su factura será de {importe-descuento:F2} euros," +
                    $"\nsi paga entre los días 11 y 20 no se le aplicará ningún descuento y si paga después del 20, " +
                    $"\nse le aplicará una penalización y su factura sería de un total de {importe + penalizacion:F2} euros.";
            Console.WriteLine(carta);
        }          
    }
}
