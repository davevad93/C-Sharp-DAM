using System;

// DAVIDE PRESTI
// - Ejercicio 9 -

// Crea un menú con tres opciones:
// 1. Registrarse en el sistema.
// 2. Entrar al sistema.
// 3. Salir del programa.
// 1. Si seleccionamos la opción 'Registrarse en el sistema', aparecerá una ventana que te
// pida una contraseña, que tendrás que repetir para darla cómo válida.
// Mientras que estás escribiendo la contraseña solamente se verán los caracteres *****
// ________________________________________
// Registrarse:
// Contraseña: ****
// Comprobar Contraseña: *****
// ________________________________________
// Las contraseñas se leerán directamente en un array de caracteres de longitud máxima
// 20 y tras la validar el proceso de registro viendo que las dos contraseñas son iguales, la
// contraseña la guardaremos un array de caracteres no almacenandose ni como String
// o StringBuilder en ningún momento.
// 2. En la opción de 'Entrar al sistema', introduciremos una cadena por teclado, se
// comprobará si la cadena introducida es igual a la contraseña guardada en el array.
// Se avisará con un texto si la entrada ha sido correcta.
// ______________________________________________
// Entrar:
// Introduce Contraseña: **
// La contraseña es correcta/incorrecta
// _______________________________________________
// No podremos entrar en esta opción sin habernos registrado en el sistema y si lo hacemos
// deberemos indicarle al usuario que antes debería registrarse.
// 📌 Nota: tendremos un método llamado RecogeContraseña que leerá un texto de forma oculta
// y al que llamaremos las veces necesarias en ambas opciones.
// Para recoger contraseña utilizaremos Console.ReadKey(true) , que permite leer un carácter de
// teclado.con la opción true no se mostrará por pantalla el eco de la tecla pulsada.

namespace ejercicio9
{
    class program
    {
        static string RecogeContraseña()
        {
            bool enter = true;
            string contraseña = "";

            while (enter)
            {
                var tecla = Console.ReadKey(true);
                
                if (tecla.Key == ConsoleKey.Enter)
                {
                    enter = false;
                }

                if (tecla.Key == ConsoleKey.Backspace && contraseña.Length > 0)
                {
                    contraseña = contraseña.Remove(contraseña.Length - 1);
                } 

                if (tecla.Key != ConsoleKey.Backspace && tecla.Key != ConsoleKey.Enter)
                {
                    contraseña = contraseña + tecla.KeyChar;
                    Console.Write("*");
                }             
            }
            return contraseña;
        }

        static void Main(string[] args)
        {
            bool validar = true;
            string contraseña = "";
            char[] arrayConstraseña;
            arrayConstraseña = new char[contraseña.Length];
            string compruebaConstraseña;
            string confirmaConstraseña;
            int i = 0;

            do
            {               
                Console.Write("\n|<|>|MENÚ DE REGISTRO DE USUARIO|<|>|" +
                              "\n\n1. Registrarse en el sistema." +
                              "\n2. Entrar al sistema." +
                              "\n3. Salir del programa.");
                var opcion = Console.ReadKey(true);
                Console.Write("\n");
                
                if (opcion.KeyChar == '1')
                {                                         
                    do
                    {
                        Console.WriteLine("___________________________________________________________________________\n");
                        Console.Write("Registrarse:\n\n Constraseña: ");
                        contraseña = RecogeContraseña();
                        Console.Write("\n Comprobar constraseña: ");
                        compruebaConstraseña = RecogeContraseña();
                        Console.WriteLine("\n___________________________________________________________________________\n");
                        
                        if (contraseña.Length > 20)
                        {   
                            Console.WriteLine("ERROR! La longitud máxima de la contraseña es de 20 caracteres.");
                            Console.WriteLine("___________________________________________________________________________");
                            break;       
                        }                                                                       
                        
                        if (validar = compruebaConstraseña == contraseña)
                        {
                            Console.WriteLine("La contraseña se ha guardado correctamente.");
                            arrayConstraseña = contraseña.ToCharArray();
                            Console.WriteLine("___________________________________________________________________________");
                        }
                        else
                        {
                            Console.WriteLine("La contraseña no coincide.");
                        }
                    }
                    while (!validar);
                }
                
                else if (opcion.KeyChar == '2')
                {
                    if (contraseña != "")
                    {
                        Console.WriteLine("___________________________________________________________________________\n");
                        Console.Write("Entrar:\n\n Introduzca la constraseña: ");
                        confirmaConstraseña = RecogeContraseña();

                        while (i < arrayConstraseña.Length - 1 && validar)
                        {
                            i++;
                            validar = arrayConstraseña[i] == confirmaConstraseña[i];
                        }

                        if (validar)
                        {
                            Console.WriteLine("\n La contraseña es correcta.");
                        }
                        else
                        {
                            Console.WriteLine("\n La contraseña es incorrecta.");
                        }
                        Console.WriteLine("___________________________________________________________________________");
                    }  
                    
                    else
                    {
                        Console.WriteLine("\nPara entrar al sistema, antes hay que registrarse.");
                    }
                }
                
                else if (opcion.KeyChar != '3')
                {
                    Console.WriteLine("\nERROR! Opción no disponible.");
                }
                
                else
                {
                    Console.WriteLine("___________________________________________________________________________\n");
                    Console.WriteLine("Programa finalizado.");
                    Console.WriteLine("___________________________________________________________________________\n");
                    validar = false;
                }           
            }
            while (validar);
        }  
    }
}