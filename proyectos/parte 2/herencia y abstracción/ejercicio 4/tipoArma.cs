// DAVIDE PRESTI
// - Ejercicio 4 -
// Crea una clase Guerrero que herede de la clase Humano del ejercicio anterior, añade los
// campos tipoArma y tipoArmadura y los métodos que creas necesarios, para hacerla funcional.
// Crea también la clase Mago hija de humano con los atributos tipoLibroHechizos y tipoTúnica y los métodos necesarios.
// 📌 Nota: Sería interesante que utilices tipos enumerados para los campos anteriormente descritos.

namespace ejercicio4
{
    public enum Arma
    {
        Arco, Daga, Maza, Espada, Ballesta, Hacha
    }    
    public static class tipoArma
    {                 
        public static string GetArmaInfo(this Arma tipo)
        {
            switch (tipo)
            {
                case Arma.Arco:
                    return "Arco ligero";
                case Arma.Daga:
                    return "Daga de acero";
                case Arma.Maza:
                    return "Maza orca";
                case Arma.Espada:
                    return "Espada élfica";
                case Arma.Ballesta:
                    return "Ballesta imperial";
                case Arma.Hacha:
                    return "Hacha de guerra enana";
                default:
                    return "?";
            }
        }
    }
}