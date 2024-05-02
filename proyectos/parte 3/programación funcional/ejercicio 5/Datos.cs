// DAVIDE PRESTI
// - Ejercicio 5 -

// En el el zip de propuestas de solución para autoevaluación de este bloque de ejercicios,
// hay un fichero denominado Ej5_ConsultasProductos_a_completar.cs donde hay definidas las
// siguientes clases ...

//             Producto                                     Dimensiones
// +CodArticulo : string { get; init; }             +Largo : int { get; init; }
// +Descripcion : string { get; init; }             +Ancho : int { get; init; }
// +Categoria : string { get; init; }   1 ===== 1   +Espesor : int { get; init; }   
// +Colores : string[] { get; init; }
// +Precio : double { get; init; }

// En la propiedad estática Productos de la clase Datos te devolverá una secuencia de
// productos ( IEnumerable<Producto> ) sobre la que realizar las consultas.
// Además, en el programa principal tienes un 'esqueleto' a completar con descripción de cada
// consulta. Por ejemplo, para la primera consulta tendríamos ...
// Console.WriteLine(SeparadorConsulta);
// Console.WriteLine(
// "Consulta 1: Usando las funciones Where y Select.\n" +
// "Mostrar CodArticulo, Descripcion y Precio .\n" +
// "de productos con Precio entre 10 y 30 euros\n");
// var consulta1 = "";
// Console.WriteLine(string.Join("\n", consulta1));
// Nosotros deberemos rellenar la consulta de acuerdo a las especificaciones de la descripción,
// cuidando la presentación y sangría para que sean legibles. Por ejemplo ...
// ...
// var consulta1 = Productos.Where(p => p.Precio >= 10 && p.Precio <= 30)
// .Select(p => new
// {
//     CodArticulo = p.CodArticulo,
//     Descripcion = p.Descripcion,
//     Precio = p.Precio
// });

namespace ejercicio5
{
    public class Datos
    {
        public static IEnumerable<Producto> Productos = new List<Producto>
        {
            new Producto {CodArticulo = "A01", Descripcion = "Uno", Categoria = "C1", Colores = new[] {"blanco", "negro", "gris"}, Dimensiones = new Dimensiones {Largo = 4, Ancho = 4, Espesor = 3}, Precio = 15.05},
            new Producto {CodArticulo = "A02", Descripcion = "Dos", Categoria = "C1", Colores = new[] {"blanco", "gris", "rojo"}, Dimensiones = new Dimensiones {Largo = 4, Ancho = 10, Espesor = 2}, Precio = 25.95},
            new Producto {CodArticulo = "A03", Descripcion = "Tres", Categoria = "C2", Colores = new[] {"rojo", "gris", "verde"}, Dimensiones = new Dimensiones {Largo = 5, Ancho = 5, Espesor = 3}, Precio = 30.25},
            new Producto {CodArticulo = "A04", Descripcion = "Cuatro", Categoria = "C1", Colores = new[] {"verde", "rojo"}, Dimensiones = new Dimensiones {Largo = 6, Ancho = 8, Espesor = 4}, Precio = 18.45},
        };
    }
}