using System;
using System.Collections.Generic;
using System.Linq;

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
    class Program
    {
        const string SeparadorConsulta = "------------------------------------------------------------------------";
        static void Main(string[] args)
        {
            IEnumerable<Producto> Productos = Datos.Productos;
            Console.WriteLine(SeparadorConsulta);
            Console.WriteLine(
                "Consulta 1: Usando las funciones Where y Select.\n" +
                "Mostrar CodArticulo, Descripcion y Precio.\n" +
                "de productos con Precio entre 10 y 30 euros\n");
            var consulta1 = Productos.Where(p => p.Precio >= 10 && p.Precio <= 30)
                                        .Select(p => new
                                        {
                                            CodArticulo = p.CodArticulo,
                                            Descripcion = p.Descripcion,
                                            Precio = p.Precio
                                        });
            Console.WriteLine(string.Join("\n", consulta1));
            Console.WriteLine();

            Console.WriteLine(SeparadorConsulta);
            Console.WriteLine(
                "Consulta 2: Usando las funciones Select, OrderByDescending y Take.\n" +
                "Muestra CodArticulo, Descripcion y Precio de los 3 productos.\n" +
                "más caros (ordenando por Precio descendente)\n");
            var consulta2 = Productos.Select(p => new
                                        {
                                            CodArticulo = p.CodArticulo,
                                            Descripcion = p.Descripcion,
                                            Precio = p.Precio
                                        })
                                        .OrderByDescending(p => p.Precio)
                                        .Take(3);
            Console.WriteLine(string.Join("\n", consulta2));
            Console.WriteLine();

            Console.WriteLine(SeparadorConsulta);
            Console.WriteLine(
                "Consulta 3: Usando las funciones GroupBy, OrderBy y First.\n" +
                "Muestra el precio más barato por categoría\n");
            var consulta3 = Productos.GroupBy(p => p.Categoria)
                                        .Select(g => new
                                        {
                                            Categoria = g.Key,
                                            PrecioMasBarato = g.OrderBy(p => p.Precio).First().Precio
                                        });
            Console.WriteLine(string.Join("\n", consulta3));
            Console.WriteLine();

            Console.WriteLine(SeparadorConsulta);
            Console.WriteLine(
                "Consulta 4: Usando las funciones GroupBy, Count.\n" +
                "¿Cuántos productos hay de cada categoría?\n");
            var consulta4 = Productos.GroupBy(p => p.Categoria)
                                        .Select(g => new
                                        {
                                            Categoria = g.Key,
                                            NumeroProductos = g.Count()
                                        });
            Console.WriteLine(string.Join("\n", consulta4));
            Console.WriteLine();

            Console.WriteLine(SeparadorConsulta);
            Console.WriteLine(
                "Consulta 5: Usando las funciones GroupBy, Count, Where y Select\n" +
                "Mostrar las categorías que tengan más de 2 productos\n");
            var consulta5 = Productos.GroupBy(p => p.Categoria)
                                        .Where(g => g.Count() > 2)
                                        .Select(g => g.Key);
            Console.WriteLine(string.Join("\n", consulta5));
            Console.WriteLine();

            Console.WriteLine(SeparadorConsulta);
            Console.WriteLine(
                "Consulta 6: Usando la función Select\n" +
                "Mostrar CodArticulo, Descripcion, Precio y Descuento redondeado a 2 decimales,\n" +
                "siendo Descuento el 10% del Precio\n");
            var consulta6 = Productos
                .Select(p => new
                {
                    CodArticulo = p.CodArticulo,
                    Descripcion = p.Descripcion,
                    Precio = p.Precio,
                    Descuento = Math.Round(p.Precio * 0.1, 2)
                });
            Console.WriteLine(string.Join("\n", consulta6));
            Console.WriteLine();

            Console.WriteLine(SeparadorConsulta);
            Console.WriteLine(
                "Consulta 7: Usando las funciones Where, Contains y Select.\n" +
                "Mostrar CodArticulo, Descripcion y Colores\n" +
                "de los productos de color verde o rojo\n");
            var consulta7 = Productos
                .Where(p => p.Colores.Contains("verde") || p.Colores.Contains("rojo"))
                .Select(p => new { p.CodArticulo, p.Descripcion, p.Colores });
            Console.WriteLine(string.Join("\n", consulta7));
            Console.WriteLine();

            Console.WriteLine(SeparadorConsulta);
            Console.WriteLine(
                "Consulta 8: Usando las funciones Where, Count y Select.\n" +
                "Mostrar CodArticulo, Descripcion y Colores.\n" +
                "de los productos que se fabrican en tres Colores\n");
            var consulta8 = Productos
                .Where(p => p.Colores.Length == 3)
                .Select(p => new { p.CodArticulo, p.Descripcion, p.Colores });
            Console.WriteLine(string.Join("\n", consulta8));
            Console.WriteLine();

            Console.WriteLine(SeparadorConsulta);
            Console.WriteLine(
                "Consulta 9: Usando las funciones Where, Select.\n" +
                "Mostrar CodArticulo, Descripcion y Dimensiones\n" +
                "de los productos con espesor de 3 cm\n");
            var consulta9 = Productos
                .Where(p => p.Dimensiones.Espesor == 3)
                .Select(p => new { p.CodArticulo, p.Descripcion, Dimensiones = p.Dimensiones.ToString() });
            Console.WriteLine(string.Join("\n", consulta9));
            Console.WriteLine();

            Console.WriteLine(SeparadorConsulta);
            Console.WriteLine(
                "Consulta 10: Usando las funciones SelectMany, Distinct y OrderBy.\n" +
                "Mostrar los colores de productos ordenados y sin repeticiones\n");
            var consulta10 = Productos
                .SelectMany(p => p.Colores)
                .Distinct()
                .OrderBy(c => c);
            Console.WriteLine(string.Join("\n", consulta10));
            Console.WriteLine();

            Console.WriteLine(SeparadorConsulta);
            Console.WriteLine(
                "Consulta 11: Usando las funciones SelectMany, GroupBy, OrderByDescending.\n" +
                "Mostrar TotalProductos que hay de cada Color ordenando de mayor a menor cantidad\n");
            var consulta11 = Productos
                .SelectMany(p => p.Colores)
                .GroupBy(c => c)
                .Select(g => new { Color = g.Key, TotalProductos = g.Count() })
                .OrderByDescending(r => r.TotalProductos);
            Console.WriteLine(string.Join("\n", consulta11));
            Console.WriteLine();                
        }
    }    
}