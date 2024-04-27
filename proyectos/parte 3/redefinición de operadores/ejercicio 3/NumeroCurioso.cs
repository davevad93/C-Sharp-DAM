// DAVIDE PRESTI
// - Ejercicio 3 -
// Para cierta implementación que no viene al caso, el departamento de diseño ha detectado la necesidad de crear un nuevo tipo de números a los que ha denominado "números curiosos". Un número curioso se caracteriza por tres coordenadas reales.
// Sobre los números curiosos interesa realizar las siguientes operaciones:

// 1. Suma
// 2. Resta

// Crea la clase NumeroCurioso con los atributos, propiedades y métodos que creas necesarios para su correcta implementación y prueba.
// Redefine los operadores necesarios para poder realizar la suma y resta de dos números curiosos.

namespace ejercicio3
{
    public class NumeroCurioso
    {
        private double a;
        private double b;
        private double c;

        private static double PotenciaCuadrada(double a, double b, double c)
        {
            double cuadradoA = a * a;
            double cuadradoB = b * b;
            double cuadradoC = c * c;
            return cuadradoA + cuadradoB + cuadradoC;
        }

        public NumeroCurioso(double a, double b, double c)
        {
            double curioso = PotenciaCuadrada(a, b, c);
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public double A
        {
            get {return a;}
            set {a = value;}
        }

        public double B
        {
            get {return b;}
            set {b = value;}
        }

        public double C
        {
            get {return c;}
            set {c = value;}
        }

        public static NumeroCurioso operator +(NumeroCurioso n1, NumeroCurioso n2)
        {
            double coordA = 0;
            double coordB = 0;
            double coordC = 0;

            double sumaCuadrado = PotenciaCuadrada(n1.a + n2.a, n1.b + n2.b, n1.c + n2.c);
            if (sumaCuadrado != 0)
            {
                double raizCuadrada = Math.Sqrt(sumaCuadrado);
                coordA = (n1.a + n2.a) / raizCuadrada;
                coordB = (n1.b + n2.b) / raizCuadrada;
                coordC = (n1.c + n2.c) / raizCuadrada;
            }
            else
            {
                return new NumeroCurioso(0, 0, 0);
            }
            return new NumeroCurioso(coordA, coordB, coordC);
        }

        public static NumeroCurioso operator -(NumeroCurioso n1, NumeroCurioso n2)
        {
            double coordA = 0;
            double coordB = 0;
            double coordC = 0;

            double sumaCuadrado = PotenciaCuadrada(n1.a - n2.a, n1.b - n2.b, n1.c - n2.c);
            if (sumaCuadrado != 0)
            {
                double raizCuadrada = Math.Sqrt(sumaCuadrado);
                coordA = (n1.a - n2.a) / raizCuadrada;
                coordB = (n1.b - n2.b) / raizCuadrada;
                coordC = (n1.c - n2.c) / raizCuadrada;
            }
            else
            {
                return new NumeroCurioso(0, 0, 0);
            }
            return new NumeroCurioso(coordA, coordB, coordC);
        }

        public override string ToString()
        {
            string salida = $"({a:F2}, {b:F2}, {c:F2})"; 
            return salida;
        }        
    }
}