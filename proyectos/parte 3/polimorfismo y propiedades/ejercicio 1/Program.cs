using System;

// DAVIDE PRESTI
// - Ejercicio 1 -

// Para practicar el concepto de polimorfismo funcional o sobrecarga, vamos a suponer que tenemos un método de utilidad
// que nos permite calcular el coste de la carrera de un taxi.
// Hay cuatro conceptos básicos que conforman el precio de la carrera. Dos de ellos fijos, que son la bajada de bandera y la
// carrera mínima, y dos conceptos variables en cada trayecto: los kilómetros recorridos y el tiempo de espera.
// Además de los cuatro conceptos básicos, existen algunos recargos o suplementos que deben pagarse en determinadas
// circunstancias: por día festivo o domingo, por horario nocturno, por mascotas u otros conceptos de ocupación extra.
// A partir del método CosteCarrera con parámetros opcionales que se muestra a continuación, refactoríza el código para
// quitar los parámetros opcionales de métodos públicos sobrecargando CosteCarrera y que se ofrezcan sobrecargas con el
// menor número de parámetros posibles.
// 📌 Nota: Modificaremos el Main para evitar llamadas donde se pasen los valores a 0 o a false en las llamadas a
// CosteCarrera , al realizar estos cambios deberás modificar el tipo de ocupacionExtra a uint , para que no se produzca
// ambigüedad en la llamada.

namespace ejercicio1
{
    public static class Taxi
    {
        const float BAJADA_BANDERA = 1.82F;
        const float CARRERA_MINIMA = 3.63F;
        const float COSTE_KM = 0.9F;
        const float ESPERA_POR_HORA = 18.77F;
        const short PORCENTAJE_NOCTURNO = 30;

        public static double CosteCarrera(float kilometrosRecorridos, float minutosEspera)
        {
            return CosteCarrera(kilometrosRecorridos, minutosEspera, false, 0, 0u);
        }

        public static double CosteCarrera(float kilometrosRecorridos, float minutosEspera, bool nocturno)
        {
            return CosteCarrera(kilometrosRecorridos, minutosEspera, nocturno, 0, 0u);
        }

        public static double CosteCarrera(float kilometrosRecorridos, float minutosEspera, bool nocturno, int porcentajeFestivo)
        {
            return CosteCarrera(kilometrosRecorridos, minutosEspera, nocturno, porcentajeFestivo, 0u);
        }

        public static double CosteCarrera(float kilometrosRecorridos, float minutosEspera, uint ocupacionExtra)
        {
            return CosteCarrera(kilometrosRecorridos, minutosEspera, false, 0, ocupacionExtra);            
        }
        public static double CosteCarrera(float kilometrosRecorridos, float minutosEspera, int porcentajeFestivo)
        {
            return CosteCarrera(kilometrosRecorridos, minutosEspera, false, porcentajeFestivo, 0u);            
        }
                    
        public static double CosteCarrera(float kilometrosRecorridos, float minutosEspera, bool nocturno, int porcentajeFestivo, uint ocupacionExtra)
        {
            float costeCarrera = BAJADA_BANDERA + kilometrosRecorridos * COSTE_KM + minutosEspera * (ESPERA_POR_HORA / 60);
            costeCarrera = costeCarrera < CARRERA_MINIMA ? CARRERA_MINIMA : costeCarrera;

            float incrementoNocturno = nocturno ? costeCarrera / PORCENTAJE_NOCTURNO : 0;
            float incrementoFestivo = porcentajeFestivo != 0 ? costeCarrera * porcentajeFestivo / 100f : 0;

            costeCarrera += incrementoFestivo >= incrementoNocturno ? incrementoFestivo : incrementoNocturno;
            costeCarrera += ocupacionExtra;

            return costeCarrera;
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine($"Coste carrera lunes mañana -> {Taxi.CosteCarrera(20, 5):F2} euros.");
            Console.WriteLine($"Coste carrera lunes noche -> {Taxi.CosteCarrera(20, 5, true):F2} euros.");
            Console.WriteLine($"Coste carrera lunes con mi mascota Dogo -> {Taxi.CosteCarrera(20, 5, 1u):F2} euros.");
            Console.WriteLine($"Coste carrera Domingo de Ramos -> {Taxi.CosteCarrera(20, 5, 40):F2} euros.");
            Console.WriteLine($"Coste carrera Domingo noche -> {Taxi.CosteCarrera(20, 5, true, 20):F2} euros.");
            Console.WriteLine($"Coste carrera Domingo de Ramos noche con Dogo y Minina -> {Taxi.CosteCarrera(20, 5, true, 40, 2u):F2} euros.");
        }
    }
}