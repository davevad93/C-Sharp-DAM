using System;
using System.IO;
using Spectre.Console;

// DAVIDE PRESTI
// - Ejercicio 1 -
// Este ejercicio se desarrollará a partir de una librería de terceros descargada de NuGet que facilita el diseño de la 
// salida por consola, la librería se llama spectre.console y va a permitir, entre otras cosas, crear tablas y gráficos a 
// partir de unos datos, Web Oficial Spectre Console.
// El ejercicio constará de leer la información del fichero datos.csv, pasado como recurso. A partir de la lectura del 
// archivo y con la ayuda de la .dll, se creará una tabla y dos gráficos (uno con el dato temperatura y el otro con el 
// dato velocidad del viento) con el aspecto parecido al de la imagen:

namespace ejercicio1
{
    class Program
    {
        static TableColumn CreaColumna(string columna)
        {
            TableColumn tc = new TableColumn($"[blue]{columna}[/]");
            tc.Centered();
            return tc;
        }

        static Table CreaTabla(string ruta)
        {
            var tabla = new Table();
            int fila = 0;
            using (var fs = new FileStream(ruta, FileMode.Open, FileAccess.Read))
            using (var st = new StreamReader(fs))
            while (!st.EndOfStream)
            {
                string[] columnas = st.ReadLine().Split(',');
                if (fila == 0) 
                {
                    foreach (var c in columnas)
                    {
                        tabla.AddColumn(CreaColumna(c));
                    }    
                }    
                else  
                {
                    var fecha = LeeFecha(columnas[0]);
                    var datos = new string[]{fecha.ToString(), columnas[1], columnas[2], columnas[3], columnas[4]};
                    tabla.AddRow(datos);
                }
                fila++;
            }
            return tabla;
        }

        static DateTime LeeFecha(string fecha)
        {
            int año = int.Parse(fecha.Substring(0, 4));
            int mes = int.Parse(fecha.Substring(4, 2));
            int dia = int.Parse(fecha.Substring(6, 2));
            int horas = int.Parse(fecha.Substring(9, 2));
            int minutos = int.Parse(fecha.Substring(11, 2));
            return new DateTime(año, mes, dia, horas, minutos, 0);
        }

        static void LeeDatosTemperatura(BarChart temperatura, string linea)
        {
            string[] columnas = linea.Split(',');
            double grados;
            Color color;

            if (double.TryParse(columnas[1].Replace('.',','), out grados))
            {
                if (grados < 1)
                {
                    color = Color.DeepSkyBlue1;
                }
                else if (grados < 3)
                {
                    color = Color.DarkCyan;
                }
                else
                {
                    color = Color.Yellow;
                }
                temperatura.AddItem(LeeFecha(columnas[0]).ToString(), grados, color);
            }
        }

        static void LeeDatosViento(BarChart viento, string linea)
        {
            string[] columnas = linea.Split(',');
            double velocidad;
            Color color;
            if (double.TryParse(columnas[3].Replace('.',','), out velocidad))
            {
                if (velocidad < 20)
                {
                    color = Color.Yellow;
                }
                else if (velocidad < 30)
                {
                    color = Color.Gold1;
                }
                else if (velocidad < 40)
                {
                    color = Color.DarkOrange;
                }
                else
                {
                    color = Color.Red;
                }
                viento.AddItem(LeeFecha(columnas[0]).ToString(), velocidad, color);
            }
        }

        static (BarChart, BarChart) CreaGraficos(string ruta)
        {
            var temperatura = new BarChart().Width(70).Label("[green] Temperatura[/]");
            temperatura.CenterLabel();
            var viento = new BarChart().Width(70).Label("[green] Velocidad Viento[/]");
            viento.CenterLabel();

            int fila = 0;
            using (var fs = new FileStream(ruta, FileMode.Open, FileAccess.Read))
            using (var st = new StreamReader(fs))
            {
                while (!st.EndOfStream)
                {
                    string linea = st.ReadLine();
                    if (fila > 0)
                    {
                        LeeDatosTemperatura(temperatura, linea);
                        LeeDatosViento(viento, linea);
                    }
                    fila++;
                }
            }
            return (temperatura, viento);
        }

        static void Main(string[] args)
        {
            AnsiConsole.Write(CreaTabla("datos.csv"));
            (BarChart ,BarChart) grafico = CreaGraficos("datos.csv");
            AnsiConsole.Write(grafico.Item1);
            AnsiConsole.Write(grafico.Item2);
        }
    }
}