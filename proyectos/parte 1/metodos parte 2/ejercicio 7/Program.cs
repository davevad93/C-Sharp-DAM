using System;

// DAVIDE PRESTI
// - Ejercicio 7 - 

// El calendario Gregoriano actual obedece a la reforma del calendario juliano que ordenó el papa Gregorio XIII en
// 1582. Se decidió, después de algunas modificaciones, que en lo sucesivo fuesen bisiestos todos los años múltiplos de
// cuatro, pero que de los años seculares (los acabados en dos ceros) sólo fuesen bisiestos aquellos que fuesen múltiplos
// de cuatrocientos.
// En base a estos conceptos, deberemos construir un programa que dada una fecha (día, mes y año), nos devuelva
// como resultado el correspondiente día de la semana en texto (Lunes, Martes, Miércoles, etc.).
// ✋ Importante: La estructura del programa estará formada, además de por el método main, los métodos estáticos
// (Piensa cual sería el DEM lógico para estas definiciones):
// (int dia, int mes, int año) LeeFecha()
// bool FechaValida(int dia, int mes, int año)
// bool Bisiesto(int año)
// string DiaSemana(int dia, int mes, int año)
// Consideraciones:
// 1. La entrada será válida si...
// año → es mayor o igual que 1582.
// día → cumple la condición de ser mayor que 1 y menor que 28, 29, 30 o 31 según corresponda.
// mes → esté entre 1 y 12.
// 2. Antes de calcular el día de la semana, se tendrán que ajustar los datos de manera que: Si mes <= 2 , tendremos
// que sumarle 12 al mes y restarle uno al año. El día de la semana se calculará con la siguiente operación:
// diaSemana = (dia + 2*mes + 3*(mes + 1)/5 + año + año/4 - año/100 + año/400 + 2) % 7;
// 👁 Nota: Si diaSemana es 1 → Domingo, 2 → Lunes, 3 → Martes, … y 0 → Sábado.

namespace ejercicio7
{
    class program
    {
        static (int dia, int mes, int año) LeeFecha()
        {
            int dia; int mes; int año;
            do
            {   Console.Write("\nIntroduzca el día: ");
                dia = int.Parse(Console.ReadLine());
                Console.Write("\nIntroduzca el mes: ");
                mes = int.Parse(Console.ReadLine());
                Console.Write("\nIntroduzca el año: ");
                año = int.Parse(Console.ReadLine());
            }
            while (!(FechaValida(dia, mes, año)));
            return (dia, mes, año);
        }

        static bool FechaValida(int dia, int mes, int año)
        {
            bool fechaValida;
            
            if (dia >= 1 && año >= 1582)
            {
                switch (mes)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12:
                        fechaValida = dia <= 31;
                        break;                                     
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        fechaValida = dia <= 30;
                        break;
                    case 2:
                        fechaValida = dia < 29 || dia == 29 && Bisiesto(año);
                        break;                           
                    default:
                        fechaValida = false;
                        break;                 
                }
            } 
            
            else
            {
                fechaValida = false;
                Console.WriteLine("\nERROR! La fecha introducida no es válida.");
            }
            return fechaValida;
        }

        static bool Bisiesto(int año)
        {
            bool fechaValida;
            
            if (año % 4 == 0 && año % 100 != 0 || año % 400 == 0)
            {
                fechaValida = true;
            }
            
            else
            {
                fechaValida = false;
            }
            return fechaValida;
        }

        static string DiaSemana(int dia, int mes, int año)
        {
            if (mes <= 2)
            {
                mes = mes + 12;
                año = año - 1;
            }

            int diaSemana = (dia + 2 * mes + 3 * (mes + 1) / 5 + año + año / 4 - año / 100 + año / 400 + 2) % 7;
            string semanaDia = "";
            
            switch (diaSemana)
            {
                case 0:
                    semanaDia = "Sábado";
                    break;                
                case 1:
                    semanaDia = "Domingo";
                    break;
                case 2:
                    semanaDia = "Lunes";
                    break;
                case 3:
                    semanaDia = "Martes";
                    break;
                case 4:
                    semanaDia = "Miércoles";
                    break;                        
                case 5:
                    semanaDia = "Jueves";
                    break;
                case 6:
                    semanaDia = "Viernes";
                    break;                 
                default:
                    semanaDia = "?";
                    break;                      
            }
            return semanaDia;
        }

        static void Main(string[] args)
        {
            (int dia, int mes, int año) = LeeFecha();
            Console.WriteLine($"\nEl día de la fecha [{dia}/{mes}/{año}] es: {DiaSemana(dia, mes, año)}");           
        } 
    }
}