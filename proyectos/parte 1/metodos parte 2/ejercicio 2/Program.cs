using System;

// DAVIDE PRESTI
// - Ejercicio 2 -

// Realiza un programa para calcular el número mágico de una persona. El número mágico de una persona debe
// considerarse como la suma de las cifras de su día de nacimiento, repitiendo el proceso hasta que la suma de las cifras
// devuelva un número menor de 10.
// De esta forma, alguien nacido el 7 de marzo de 1965 tendría como número mágico el 4.
// 👁 Nota: Deberás usar los métodos necesarios para que tu programa quede bien modularizado y con alta cohesión,
// evitando el acoplamiento.
// Un ejemplo de ejecución podría ser:
// Día nacimiento: 7
// Mes nacimiento: 3
// Año nacimiento: 1965
// 7 + 3 + 1 + 9 + 6 + 5 = 31
// 3 + 1 = 4
// Tu número mágico es: 4


namespace ejercicio2
{
    class program
    {
        static (int dia, int mes, int año) LeeFecha()
        {
            Console.Write("\nIntroduzca el día de nacimiento: ");
            int dia = int.Parse(Console.ReadLine());
            Console.Write("\nIntroduzca el mes de nacimiento: ");
            int mes = int.Parse(Console.ReadLine());
            Console.Write("\nIntroduzca el año de nacimiento: ");
            int año = int.Parse(Console.ReadLine());
            return (dia, mes, año);
        }
        
        static int SumaNumeros(int numero)
        {
            int sumaNumeros = 0;
            do
            {
                sumaNumeros += numero % 10;
                numero = numero / 10;
            }
            while (numero > 10);
            sumaNumeros += numero;
            return sumaNumeros;
        }

        static int NumeroMagico(int dia, int mes, int año)
        {
            int numeroMagico = SumaNumeros(dia) + SumaNumeros(mes) + SumaNumeros(año);
            do
            {
                numeroMagico = SumaNumeros(numeroMagico);
            }
            while (numeroMagico > 10);
            return numeroMagico;
        }

        static void Main(string[] args)
        {
            (int dia, int mes, int año) = LeeFecha();
            int numeroMagico = NumeroMagico(dia, mes, año);
            Console.Write($"\nTu número mágico es: {numeroMagico}\n");
        }
    }
}