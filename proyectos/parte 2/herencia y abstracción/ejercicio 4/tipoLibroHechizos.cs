// DAVIDE PRESTI
// - Ejercicio 4 -
// Crea una clase Guerrero que herede de la clase Humano del ejercicio anterior, añade los
// campos tipoArma y tipoArmadura y los métodos que creas necesarios, para hacerla funcional.
// Crea también la clase Mago hija de humano con los atributos tipoLibroHechizos y tipoTúnica y los métodos necesarios.
// 📌 Nota: Sería interesante que utilices tipos enumerados para los campos anteriormente descritos.

namespace ejercicio4
{
    public enum LibroHechizos
    {
        BolaDeFuego, Congelacion, TormentaDeRayos, AtrapaAlmas, FuegoDivino
    }     
    public static class tipoLibroHechizos
    {   
        public static string GetLibroHechizosInfo(this LibroHechizos tipo)
        {
            switch (tipo)
            {
                case LibroHechizos.BolaDeFuego:
                    return "Bolas de fuego";
                case LibroHechizos.Congelacion:
                    return "Congelación";
                case LibroHechizos.TormentaDeRayos:
                    return "Tormenta de rayos";
                case LibroHechizos.AtrapaAlmas:
                    return "Atrapa almas";
                case LibroHechizos.FuegoDivino:
                    return "Fuego divino";
                default:
                    return "?";
            }
        }
    }
}