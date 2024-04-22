using System.Text.RegularExpressions;

// DAVIDE PRESTI
// - Ejercicio 4 -
// Crea un programa a partir del siguiente diagrama de clases en UML
// La aplicación permitirá recoger datos de una cuenta bancaria. Deberás crear los siguientes
// métodos y comprobar que funcionan correctamente. Prueba la aplicación con más de un
// número de cuenta y captura las posibles excepciones en el programa principal.
// El constructor NumeroCuenta recibirá un string con el número de cuenta completo y si este
// no se corresponde con un número de cuenta correcto se lanzara una excepción
// NumeroCuentaIncorrectoException . Esta excepción se puede lanzar por dos motivos:
// 1. Porque no cumple el patrón de un número de cuenta (para ello llamará al método
// formatoCorrecto)
// 2. Porque la cuenta no se corresponde con los dígitos de control (en este caso usara
// dcCorrecto).
// El método privado de NumeroDeCuenta , formatoCorrecto . Comprobará el formato del
// número de cuenta con expresiones regulares y si el formato es correcto rellenará los
// campos del objeto. En caso contrario lanzará una excepción
// NumeroCuentaIncorrectoException , indicando que el formato de la cuenta no cumple las
// condiciones necesarias.
// El método privado dcCorrecto , comprobará si el dígito de control corresponde a la
// cuenta, devolviendo false en caso contrario. Para ver como se hace esto, consulta la
// Nota y la Pista posterior.
// El método Reintegro , lanzará una exception SaldoInsuficienteException , cuando se
// intente retirar una cantidad y no haya suficiente saldo.
// El código cuenta corriente es un número de 20 cifras. Las 4 primeras de la izquierda
// identifican a la Entidad, las 4 siguientes, la Sucursal, luego vienen 2 dígitos de control y las
// 10 últimas corresponden al número de la cuenta corriente.
// El primero es el dígito de control de Entidad/Sucursal.
// El segundo es el dígito de control del número de la cuenta corriente.
// El siguiente ejemplo nos enseñará a calcularlos…
// Supongamos ahora 2085 el código de una hipotética entidad y 0103 el código de una de sus
// sucursales.
// Para calcular el dígito de control de Entidad/Sucursal:
// Realizaremos la operación:
// 2*4 + 0*8 + 8*5 + 5*10 + 0*9 + 1*7 + 0*3 + 3*6 = 123
// Es decir, cada una de las cifras de la entidad, seguidas de la sucursal, se han ido
// multiplicando por los números del array de ponderaciones 4, 8, 5, 10, 9, 7, 3, 6 y
// luego se han sumado estos resultados.
// Ahora realizaremos la operación 11 – (resultado % 11)
// El resultado será un número entre 1 y 11 . Si el número es menor que 10 será ya el
// valor del DC. Pero si es 10 el DC será 1 y si es 11 será 0 . En este caso
// 11 – (123 % 11) = 9 que será el DC de Entidad/sucursal.
// Para calcular el dígito de control de número de cuenta corriente:
// Si este es, por ejemplo, el 0300731702 , para calcular su dígito de control se realiza la
// operación:
// 0*1 + 3*2 + 0*4 + 0*8 + 7*5 + 3*10 + 1*9 + 7*7 + 0*3 + 2*6 = 141
// Es decir, cada una de las cifras del número de la cuenta, leídas de izquierda a derecha,
// se han ido multiplicando por 1, 2, 4, 8, 5, 10, 9, 7, 3, 6 y luego se han sumado
// estos resultados.
// Realizaremos la misma operación que antes 11 – (121 % 11) = 2 que será el DC de
// número de cuenta.
// Algunas cuentas para poder probar son:
// 2085 0103 92 0300731702
// 2100 0721 09 0200601249
// 0049 0345 31 2710611698
// 2100 1162 43 0200084482
// 2100 1516 05 0200306484
// 2100 0811 79 0200947329
// 9182 5005 04 0201520831
// 👉Pista: El método dcCorrecto calcula el dígito de control de una string con N números a
// partir de un array de ponderaciones de también N números. Y después comprueba el número
// resultante, con el DC pasado como argumento, el método devolverá true si los dígitos son
// iguales, false en caso contrario. Por tanto, este método será llamada en dos ocasiones: para
// los 8 número anteriores a los 2 dígitos de control, y para los 10 números posteriores. Usando
// cada vez el array de ponderaciones correspondiente que se describen arriba.

namespace ejercicio4
{
  class NumeroCuenta
    {
        private string entidad;
        private string sucursal;
        private string dcEntSuc;
        private string dcNumero;
        private string cuenta;

        public NumeroCuenta(in string numero)
        {
            this.entidad = numero.Substring(0, 4);
            this.sucursal = numero.Substring(5, 4);
            this.dcEntSuc = numero.Substring(10, 1);
            this.dcNumero = numero.Substring(11, 1);
            this.cuenta = numero.Substring(13, 10);

            int[] ponderacionArrayDiez = new int[10];
            int[] ponderacionArrayOcho = new int[8];

            if (FormatoCorrecto(numero) == false
                || DcCorrecto((dcEntSuc + dcNumero), cuenta, ponderacionArrayDiez) == false
                || DcCorrecto((dcEntSuc + dcNumero), (entidad + sucursal), ponderacionArrayOcho) == false)
            {
                throw new NumeroCuentaIncorrectoException($"El número de cuenta o el formato son incorrectos.");
            }
        }

        private bool FormatoCorrecto(string numero)
        {
            bool formatoCorrecto;
            numero = entidad + " " + sucursal + " " + dcEntSuc + dcNumero + " " + cuenta;
            string patron = @"^[0-9]{4}\s[0-9]{4}\s[0-9]{2}\s[0-9]{10}$";
            Regex comprobar = new Regex(patron);
            if (comprobar.IsMatch(numero))
            {
                formatoCorrecto = true;
            }
            else
            {
                formatoCorrecto = false;
            }
            return formatoCorrecto;
        }

        private bool DcCorrecto(string dc, string digitos, int[] ponderaciones)
        {
            bool dcCorrecto = true;
            string sumaPonderacionString = "0";

            if (ponderaciones.Length == 8)
            {
                string[] sumaPonderacion = new string[8];
                ponderaciones = new int[] { 4, 8, 5, 10, 9, 7, 3, 6 };
                dc = dcEntSuc;
                digitos = (entidad + sucursal).Replace(" ", "");
                for (int i = 0; i < digitos.Length; i++)
                {
                    sumaPonderacion[i] = (int.Parse(digitos[i].ToString()) * ponderaciones[i]).ToString();
                    sumaPonderacionString = (int.Parse(sumaPonderacion[i].ToString()) + int.Parse(sumaPonderacionString.ToString())).ToString();
                }

                string resultado = (11 - int.Parse(sumaPonderacionString) % 11).ToString();

                if (int.Parse(resultado) < 10 && resultado == dc)
                {
                    dcCorrecto = true;
                }
                else if (resultado == "11" && dc == "0")
                {
                    dcCorrecto = true;
                }
                else if (resultado == "10" && dc == "1")
                {
                    dcCorrecto = true;
                }
                else
                {
                    dcCorrecto = false;
                }
            }
            else
            {
                string[] sumaPonderacion = new string[10];
                ponderaciones = new int[] { 1, 2, 4, 8, 5, 10, 9, 7, 3, 6 };
                dc = dcNumero;
                digitos = cuenta;
                for (int i = 0; i < 10; i++)
                {
                    sumaPonderacion[i] = (int.Parse(digitos[i].ToString()) * ponderaciones[i]).ToString();
                    sumaPonderacionString = (int.Parse(sumaPonderacion[i].ToString()) + int.Parse(sumaPonderacionString.ToString())).ToString();
                }
                string resultado = (11 - int.Parse(sumaPonderacionString) % 11).ToString();

                if (int.Parse(resultado) < 10 && resultado == dc)
                {
                    dcCorrecto = true;
                }
                else if (resultado == "11" && dc == "0")
                {
                    dcCorrecto = true;
                }
                else if (resultado == "10" && dc == "1")
                {
                    dcCorrecto = true;
                }
                else
                {
                    dcCorrecto = false;
                }
            }
            return dcCorrecto;
        }
        
        public override string ToString()
        {
            string mensaje = "";
            mensaje = "\nEl formato y el dígito de control son correctos.\n";
            return mensaje;
        }
    }    
}