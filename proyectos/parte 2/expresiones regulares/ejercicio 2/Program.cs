using System;
using System.Text.RegularExpressions;

// DAVIDE PRESTI
// - Ejercicio 2 -
// Se nos pide hacer un programa en C# que compruebe el formato de entrada 
// de un número de cuenta por teclado, utilizando expresiones regulares.
// Además debe indicar, tras la entrada, que dígitos corresponden a la entidad, cuales a la sucursal, 
// los dígitos de control y el número de cuenta, para esto utilizaremos la captura con grupos. 
// Comprueba además, si el número de cuenta es válido calculando los dígitos de control 
// que debería tener, y comprobando si coinciden con los de la introducida. 
// Puedes buscar por Internet como se calcula el dígito de control de una cuenta bancaria.

namespace ejercicio2 
{ 
    class Program 
    { 
        static void ValidaCuenta(string cuenta, string textoError) 
        { 
            string patronCuenta = @"^(?<Entidad>\d{4})[\s-](?<Sucursal>\d{4})[\s-](?<DC>\d{2})[\s-](?<Cuenta>\d{10})$";
 
            Match coincidir = Regex.Match(cuenta, patronCuenta); 
            if (coincidir.Success) 
            { 
                string entidad = coincidir.Groups[1].Value; 
                string sucursal = coincidir.Groups[2].Value; 
                string digitosControl = coincidir.Groups[3].Value; 
                string numCuenta = coincidir.Groups[4].Value; 
 
                Console.WriteLine("\nEntidad: {0}", entidad); 
                Console.WriteLine("\nSucursal: {0}", sucursal); 
                Console.WriteLine("\nDígitos de control: {0}", digitosControl); 
                Console.WriteLine("\nNúmero de cuenta: {0}", numCuenta); 
                 
                int dc1 = CalculaDC1(entidad + sucursal); 
                int dc2 = CalculaDC2(numCuenta); 
                    
                if (dc1.ToString() == digitosControl[0].ToString() && dc2.ToString() == digitosControl[1].ToString()) 
                { 
                    Console.WriteLine("\nEl número de cuenta es válido."); 
                } 
                else 
                { 
                    Console.WriteLine("\nEl número de cuenta no es válido."); 
                } 
            } 
            else 
            { 
                Console.WriteLine(textoError); 
            } 
        } 
 
        static int CalculaDC1(string cuenta) 
        { 
            int[] pesos = {4, 8, 5, 10, 9, 7, 3, 6}; 
            int suma = 0; 
            
            for (int i = 0; i < pesos.Length; i++) 
            { 
                suma += pesos[i] * int.Parse(cuenta.Substring(i, 1)); 
            } 
 
            int resto = 11 - (suma % 11); 
            if (resto == 11) 
            { 
                resto = 0; 
            } 
            else if (resto == 10) 
            { 
                resto = 1; 
            } 
            return resto; 
        } 
        static int CalculaDC2(string cuenta) 
        { 
             
            int[] pesos = {1, 2, 4, 8, 5, 10, 9, 7, 3, 6}; 
            int suma = 0; 
 
            for (int i = 0; i < pesos.Length; i++) 
            { 
                suma += pesos[i] * int.Parse(cuenta.Substring(i, 1)); 
            } 
 
            int resto = 11 - (suma % 11); 
            if (resto == 11) 
            { 
                resto = 0; 
            } 
            else if (resto == 10) 
            { 
                resto = 1; 
            } 
            return resto; 
        } 
 
        static void Main(string[] args) 
        { 
            Console.WriteLine("\nIntroduzca un número de cuenta bancaria (XXXX-XXXX-XX-XXXXXXXXXX):"); 
            ValidaCuenta(Console.ReadLine(), @"ERROR! El formato es incorrecto."); 
        }       
    }     
}