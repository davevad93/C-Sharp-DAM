// DAVIDE PRESTI
// - Ejercicio 5 -

// Vamos utilizar interfaces para utilizar algo similar al patrón estratégia del caso de estudio. Pero a través de 
// métodos estáticos en lugar de clases.

// Para ello, vamos a definir en primer lugar la clase TemperaturasXProvincia que contendrá el nombre de una 
// província y sus temperaturas máxima y mínima respectivamente.

// Definiremos el interfaz IObténTemperatura que obligará a implementar una 'estratégia' de obtención de 
// temperatura sobre un objeto de tipo TemperaturasXProvincia. Esto es, dado un objeto de tipo 
// TemperaturasXProvincia me devolverá una de las temperaturas que contiene. En este caso la másxiam o la 
// mínima pero piensa que en el futuro este tipo de objetos podría contener una propiedad TemperaturaMedia.

// Además, vamos a definir un interfaz parametrizado ICumplePredicado que oblige a implementar un método bool 
// Predicado(T o1, T o2) al que le lleguen dos objetos y me devuelva true si cumplen un determinado predicado.

// En la clase del programa principal, tendremos este método de utilidad que pedirá nombres de província y asignará 
// aleatoriamente ambas temperaturas devolviéndome un array de TemperaturasXProvincia.

// Se pide:
// 1. Implementar en la clase principal un método llamado MediaTemperaturas al que le
// pasemos el array de TemperaturasXProvincia y un objeto que implemente la estrategia
// definida en IObténTemperatura . De tal manera que, sin cambiar el método, pueda
// calcular la media de las máximas, de las mínimas o en un futuro de las medias.
// 2. Implementar en la clase principal un método llamado MuestraProvincias al que le
// pasemos el array de TemperaturasXProvincia un valor de temperatura , un objeto que
// implemente la estrategia definida en IObténTemperatura y un objeto que implemente un
// predicado definido en ICumplePredicado . De tal manera que me muestre aquellas
// provincias cuya temperatura obtenida por IObténTemperatura cumpla un determinado
// predicado.
// 3. Crea un programa principal que usando los métodos definidos anteriormente...
// 1. Muestre las provincias cuya máxima sea mayor a la media de las máximas.
// 2. Muestre las provincias cuya mínima sea menor a la media de las mínimas.
// 3. Muestre las provincias cuya mínima sea igual a la media de las mínimas.
// 💡 Pista: Puedes definir los siguientes tipos/clases públicas para usar en el Main que
// implementen las estrategias de obtención de temperatura y los predicados necesarios dentro
// de la case TemperaturasXProvincia
// class ObténMaxima que me permita obtener la temperatura máxima.
// class ObténMinima que me permita obtener la temperatura máxima.
// class MayorQue que me si una temperatura es mayor que la otra.
// class MenorQue que me si una temperatura es menor que la otra.
// class IgualQue que me si dos temperaturas son iguales.

namespace ejercicio5
{
    interface IObténTemperatura
    {
        float Temperatura(TemperaturasXProvincia t);
    }
}