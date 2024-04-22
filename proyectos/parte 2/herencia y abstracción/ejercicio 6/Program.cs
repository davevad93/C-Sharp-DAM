using System;

// DAVIDE PRESTI
// - Ejercicio 6 -
// Crear una clase llamada TablaEnteros que no permita que se creen objetos a partir de ella.
// Esta clase almacenará una tabla de enteros de una dimensión y que será un atributo protegido, 
// el tamaño debe ser especificado mediante su constructor.
// La clase debe obligar a que cualquier clase que herede de ella y no quiera ser una clase
// abstracta, implemente un método llamado GuardarNumerosenTabla.
// Además, TablaEnteros dispondrá de dos métodos:
// DevuelveTabla, método redefinible, que servirá para devolver la cadena con elcontenido completo de la tabla.
// SumaPropia que se encargará de comprobar si existen más números positivos onegativos en la tabla y devolverá la suma de aquellos de los que hay mayor cantidad.
// Crear a partir de esta clase dos nuevas clases llamadas:
// TablaImpares: que solo guardará números impares en el atributo del padre.
// TablaPares: que solo guardará números pares, el el atributo del padre.
// Ambas, lo harán mediante el método GuardarNumerosEnTabla, antes mencionado, que
// seleccionará los números apropiados (pares o impares) a guardar a partir de número generados aleatoriamente.
// En el programa principal, crea instancias de cada una de estas clases, dales valores 
// y muestra las tablas y la suma propia de ambos objetos por pantalla.

namespace ejercicio6
{
    abstract class TablaEnteros
    {
        protected int[] tabla;
      
        public TablaEnteros(int longitud)
        {
            this.tabla = new int[longitud];
        }

        abstract public void GuardarNumerosEnTabla();

        public int SumaPropia()
        {
            int numerosPositivos = 0;
            int sumaPositivos = 0;
            int numerosNegativos = 0;
            int sumaNegativos = 0;
            
            for (int i = 0; i < tabla.Length; i++)
            {
                if (tabla[i] < 0)
                {
                    numerosNegativos++;
                    sumaNegativos += tabla[i];
                }
                else if (tabla[i] > 0)
                {
                    numerosPositivos++;
                    sumaPositivos += tabla[i];
                }                
            }

            if (numerosPositivos > numerosNegativos)
            {
                return  sumaPositivos;
            } 
            else
            {
                return sumaNegativos;
            }
        }
                
        public virtual string DevuelveTabla()
        {
            string devolverTabla = "";
            int[] mostrarTabla = new int[tabla.Length];
            for (int i = 0; i < tabla.Length; i++)
            {
                mostrarTabla[i] = tabla[i];
                devolverTabla = $"{devolverTabla} {mostrarTabla[i]}"; 
            }
            return devolverTabla;
        }
    }

    class TablaPares:TablaEnteros
    {
        public TablaPares(int longitud):base(longitud)
        {

        }
        public override void GuardarNumerosEnTabla()
        {
            Random numero = new Random();
            bool stopPares = true;
            int contador = 0;
            int longitudAleatorio = tabla.Length;
           
            while(stopPares!)
            {
                if (contador != (longitudAleatorio))
                {
                    int numeroParAleatorio = numero.Next(-100, 101);
                    if (numeroParAleatorio % 2 == 0)
                    {
                        tabla[contador] = numeroParAleatorio;
                        contador++;
                    }
                }
                else
                {
                   stopPares = false;
                }
            }
        } 
    }

    class TablaImpares:TablaEnteros
    {
        public TablaImpares(int longitud):base(longitud){}
        public override void GuardarNumerosEnTabla()
        {
            Random numero = new Random();
            bool stopImpares = true;
            int contador = 0;
            int longitudAleatorio = tabla.Length;
           
            while(stopImpares!)
            {
                if (contador != (longitudAleatorio))
                {
                    int numeroImparAleatorio = numero.Next(-100, 101);
                    if (numeroImparAleatorio % 2 != 0)
                    {
                        tabla[contador] = numeroImparAleatorio;
                        contador++;
                    }
                }
                else
                {
                   stopImpares = false;
                }
            }
        } 
    }
    class Program
    {
       static void Main(string[] args)
        {
            TablaEnteros numerosImpares = new TablaImpares(10);
            numerosImpares.GuardarNumerosEnTabla();
            Console.Write("\nLos números impares son:");
            Console.Write(numerosImpares.DevuelveTabla());
            Console.WriteLine($"\nLa suma de los números impares es: {numerosImpares.SumaPropia()}");

            TablaEnteros numerosPares = new TablaPares(10);
            numerosPares.GuardarNumerosEnTabla();
            Console.Write("Los números pares son:");
            Console.Write(numerosPares.DevuelveTabla());
            Console.WriteLine($"\nLa suma de los números pares es: {numerosPares.SumaPropia()}\n");
        }
    }
}