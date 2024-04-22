// DAVIDE PRESTI
// - Ejercicio 4 -
// Crea una clase Guerrero que herede de la clase Humano del ejercicio anterior, añade los
// campos tipoArma y tipoArmadura y los métodos que creas necesarios, para hacerla funcional.
// Crea también la clase Mago hija de humano con los atributos tipoLibroHechizos y tipoTúnica y los métodos necesarios.
// 📌 Nota: Sería interesante que utilices tipos enumerados para los campos anteriormente descritos.

namespace ejercicio4
{
    public enum Tunica
    {
        Nada, Novicio, Aprendiz, Hechizero, Nigromante, Archimago
    }     
    public static class tipoTunica
    {     
        public static string GetTunicaInfo(this Tunica tipo)
        {
            switch (tipo)
            {
                case Tunica.Nada:
                    return "Sin túnica";
                case Tunica.Novicio:
                    return "Túnica de novicio";
                case Tunica.Aprendiz:
                    return "Túnica de aprendiz";
                case Tunica.Hechizero:
                    return "Túnica de hechizero";
                case Tunica.Nigromante:
                    return "Túnica de nigromante";
                case Tunica.Archimago:
                    return "Túnica de archimago";
                default:
                    return "?";
            }
        }
    }        
}