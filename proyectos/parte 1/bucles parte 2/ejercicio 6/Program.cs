using System;

// DAVIDE PRESTI
// - Ejercicio 6 -

// Programa la generación de una tabla de verdad con unos y ceros con un bucle for anidado.

// Las operaciones que mostrará la tabla serán por tanto operaciones de bit.
// Para ello el usuario deberá introducir por teclado un carácter con el cual nos indicará la tabla a generar (&, |, ^).
// La decisión de la tabla a mostrar, debe ser mediante una instrucción switch con el carácter.
// En el caso de tratarse de una operación no válida avisaremos de tal hecho y finalizaremos la ejecución.
// Un ejemplo de salida por pantalla puede ser el siguiente:

// Introduce una operación de bit (&, |, ^): &
// 0 & 0 = 0
// 0 & 1 = 0
// 1 & 0 = 0
// 1 & 1 = 1

namespace ejercicio6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("\nIntroduzca una operación de bit (&, |, ^): "); 
            char caracter = char.Parse(Console.ReadLine());  
            int opAND, opOR, opXOR; 
            string error = ""; 
             
            switch (caracter) 
            { 
                case '&':                 
                    for (int i = 0 ; i <= 1; i++) 
                    {              
                        for (int j = 0 ; j <= 1; j++) 
                        {  
                            opAND = i & j; 
                            Console.WriteLine($"\n{i} & {j} = {opAND}");                        
                        }  
                    } 
                    break; 
 
                case '|': 
                    for (int i = 0 ; i <= 1; i++) 
                    {                
                        for (int j = 0 ; j <= 1; j++) 
                        { 
                            opOR = i | j; 
                            Console.WriteLine($"\n{i} | {j} = {opOR}");                        
                        }  
                    } 
                    break; 
                
                case '^': 
                    for (int i = 0 ; i <= 1; i++) 
                    {                
                        for (int j = 0 ; j <= 1; j++) 
                        { 
                            opXOR = i ^ j; 
                            Console.WriteLine($"\n{i} ^ {j} = {opXOR}");                        
                        }  
                    } 
                    break; 
                     
                default: 
                    error = "\nERROR! El carácter introducido no es válido."; 
                    break; 
            } 
            Console.WriteLine(error); 
        }
    }
}