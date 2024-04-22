// DAVIDE PRESTI
// - Ejercicio 4 -
// Crea una clase Guerrero que herede de la clase Humano del ejercicio anterior, añade los
// campos tipoArma y tipoArmadura y los métodos que creas necesarios, para hacerla funcional.
// Crea también la clase Mago hija de humano con los atributos tipoLibroHechizos y tipoTúnica y los métodos necesarios.
// 📌 Nota: Sería interesante que utilices tipos enumerados para los campos anteriormente descritos.

namespace ejercicio4
{
    public enum Armadura
    {
        Nada, Ligera, Media, Pesada, Legendaria
    }     
    public static class tipoArmadura
    {     
        public static string GetArmaduraInfo(this Armadura tipo)
        {
            switch (tipo)
            {
                case Armadura.Nada:
                    return "Sin armadura";
                case Armadura.Ligera:
                    return "Armadura de cuero";
                case Armadura.Media:
                    return "Armadura de malla";
                case Armadura.Pesada:
                    return "Armadura imperial";
                case Armadura.Legendaria:
                    return "Armadura legendaria";                    
                default:
                    return "?";
            }
        }
    }
}