using System;

// DAVIDE PRESTI
// - Ejercicio 4 -
// Crea una clase Guerrero que herede de la clase Humano del ejercicio anterior, añade los
// campos tipoArma y tipoArmadura y los métodos que creas necesarios, para hacerla funcional.
// Crea también la clase Mago hija de humano con los atributos tipoLibroHechizos y tipoTúnica y los métodos necesarios.
// 📌 Nota: Sería interesante que utilices tipos enumerados para los campos anteriormente descritos.

namespace ejercicio4
{  
    public enum Sexo {Hombre, Mujer}
    class Program
    {
        static string ObtenerNombre(Sexo sexo)
        {
            string[] nombresHombre = {"Aragorn", "Geralt", "Legolas", "Saruman", "Gandalf", "Eredin"};
            string[] nombresMujer = {"Arwen", "Leia", "Kassandra", "Eowyn", "Galadriel", "Isis"};
            string[] nombres = sexo == Sexo.Hombre ? nombresHombre : nombresMujer;
            return nombres[new Random().Next(0, nombres.Length)];
        }

        static int DañoRecibidoConArmadura(string armadura)
        {
            int daño;
            if (armadura == Armadura.Nada.GetArmaduraInfo())
            {
                daño = 5;
            }
            else if (armadura == Armadura.Ligera.GetArmaduraInfo())
            {
                daño = 3;
            }
            else if (armadura == Armadura.Media.GetArmaduraInfo())
            {
                daño = 2;
            }
            else if (armadura == Armadura.Pesada.GetArmaduraInfo())
            {
                daño = 1;
            }
            else
            {
                daño = 0;
            }
            return daño;
        }

        static int DañoRecibidoConTunica(string tunica)
        {
            int daño; 
            if (tunica == Tunica.Nada.GetTunicaInfo())
            {
                daño = 5;
            }
            else if (tunica == Tunica.Novicio.GetTunicaInfo())
            {
                daño = 4;
            }
            else if (tunica == Tunica.Aprendiz.GetTunicaInfo())
            {
                daño = 3;
            }
            else if (tunica == Tunica.Hechizero.GetTunicaInfo())
            {
                daño = 2;
            }
            else if (tunica == Tunica.Nigromante.GetTunicaInfo())
            {
                daño = 1;
            }                         
            else
            {
                daño = 0;
            }
            return daño;
        }

        private static Sexo SeleccionaSexo()
        {
            return (Sexo)(new Random()).Next(0, Enum.GetNames(typeof(Sexo)).Length);
        }

        static void Main(string[] args)
        {
            Random seed = new Random();
            Sexo sexoGuerrero = SeleccionaSexo();
            Sexo sexoMago = SeleccionaSexo();
            string armadura = ((Armadura)(new Random()).Next(0, Enum.GetNames(typeof(Armadura)).Length)).GetArmaduraInfo();
            string arma = ((Arma)(new Random()).Next(0, Enum.GetNames(typeof(Arma)).Length)).GetArmaInfo();
            string tunica = ((Tunica)(new Random()).Next(0, Enum.GetNames(typeof(Tunica)).Length)).GetTunicaInfo();
            string libroHechizos = ((LibroHechizos)(new Random()).Next(0, Enum.GetNames(typeof(LibroHechizos)).Length)).GetLibroHechizosInfo(); ;
            int inteligencia = seed.Next(5, 21);
            int fuerza = seed.Next(5, 21);
            int destreza = seed.Next(5, 21);
            int energia = seed.Next(5, 21);
            int edad = seed.Next(18, 71);
            int peso = seed.Next(50, 101);

            Guerrero guerrero = new Guerrero(ObtenerNombre(sexoGuerrero), edad, peso, sexoGuerrero, 
            inteligencia, fuerza, destreza, energia, DañoRecibidoConArmadura(armadura), armadura, arma);
            Console.WriteLine(guerrero.ATexto());

            Mago mago = new Mago(ObtenerNombre(sexoMago), edad, peso, sexoMago, 
            inteligencia, fuerza, destreza, energia, DañoRecibidoConTunica(tunica), tunica, libroHechizos);
            Console.WriteLine(mago.ATexto());
        }
    }
}