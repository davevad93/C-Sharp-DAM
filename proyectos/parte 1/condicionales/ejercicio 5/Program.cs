using System;

// DAVIDE PRESTI 
// - Ejercicio 5 -

// Se pide una cantidad y su precio. Hay que hallar el total aplicando un tanto por ciento de descuento 
// según la cantidad comprada.

// CANTIDAD	DESCUENTO
// 0-10	    0%
// 11-30	5%
// 31-50	10%
// +50	    15%

namespace ejercicio5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Qué cantidad es? ");
            int cantidad = int.Parse(Console.ReadLine());
            Console.Write("\nQué precio tiene el producto? ");
            int precio = int.Parse(Console.ReadLine());

            string linea;
            if (cantidad >= 0 && cantidad < 11)
            {
                precio *= cantidad;
                linea = $"\nEl precio es de {precio} euros.";
            }
            
            else if (cantidad >= 11 && cantidad < 31)
            {   
                double total = precio * cantidad;
                total = total * 95 / 100;
                linea = $"\nEl precio es de {total:F2} euros.";
            }
            
            else if (cantidad >= 31 && cantidad < 51)
            {   
                double total = precio * cantidad;
                total = total * 90 / 100;
                linea = $"\nEl precio es de {total:F2} euros.";
            }
            
            else if (cantidad >= 51)
            {   
                double total = precio * cantidad;
                total = total * 85 / 100;
                linea = $"\nEl precio es de {total:F2} euros.";
            }
            
            else 
            {
                linea = "\nERROR!";
            }
            Console.WriteLine(linea);            
        }
    }
}