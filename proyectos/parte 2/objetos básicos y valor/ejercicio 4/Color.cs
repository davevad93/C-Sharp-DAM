// DAVIDE PRESTI
// - Ejercicio 4 -
// Crea un proyecto conlos TAD necesarios para que el siguiente código perteneciente a laMain, 
// pueda ser ejecutado sin problemas:

// Compas compas = new Compas();
// Circulo circulo = compas.DibujaCirculo(3.5f);
// Rotulador rotulador = Estuche.GetRotuladores()[new Random().Next(0,Estuche.GetRotuladores()
// rotulador.Rotula(circulo.Perimetro());
// Pincel pincel=new Pincel();
// pincel.SetColor(Color.Verde);
// pincel.Pinta(circulo.Area());

// 1.El circulo tendrá un atributo radio.
// 2.El rotulador tendrá un atributo color de tipo enumerado y solo rotula perímetros.
// 3.Habrá una clase estática Estuche con un solo método también estático que devolverá 
//   un array de rotuladores con colores aleatorios.
// 4.El pincel también tiene un atributo color y solo pinta áreas.

// La salida por pantalla del programa podría ser algo como lo siguiente:
// Dibujado un círculo de radio 3,5
// Rotulado el perímetro de 21,99 cm de color Azul.
// Pintada el area de 38,48 cm de color Verde.

namespace ejercicio4
{
  public enum Color 
    { 
        Negro, Rojo, Verde, Azul, Naranja, Amarillo 
    }
}