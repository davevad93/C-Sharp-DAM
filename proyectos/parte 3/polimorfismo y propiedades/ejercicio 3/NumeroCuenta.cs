using System.Text.RegularExpressions;

// DAVIDE PRESTI
// - Ejercicio 3 -

// Vamos a ampliar el ejercicio de la cuenta corriente que hicimos en en el bloque anterior de excepciones, modificando ligeramente su definición inicial y añadiendo los TAD necesarios para modelar los distintos tipos de cuenta de un banco algo usurero. e tal manera que:
// La clase Cuenta, importada del bloque anterior, va a simbolizar un tipo de cuenta genérico del que sólo podremos ingresar, retirar fondos y tener unos datos de usuario.

// Además, añadiremos una propiedad autodefinida Saldo donde el get será público y el set protegido.
// Por otro lado se modificará el método Reintegro para que devuelva la cantidad reintegrada, que en ocasiones no será la misma que el usuario desea reintegrar.
// ✋ Importante: Para poder construir correctamente el código y no perderos durante la lectura del texto, os aconsejamos concienzudamente, que miréis las llamadas a los métodos del programa principal.

// Las distintas especificaciones para cuenta serán:

// Cuenta de ahorro
// Se especializa respecto a la genérica mediante la aplicación de intereses al saldo actual.
// Por ejemplo, si una cuenta tiene un saldo de 1000€ y la tasa de interés es del 2%, después del pago de intereses el nuevo saldo será de 1020€.

// En este tipo de cuenta los intereses se sumarán al finalizar el mes sobre el
// Saldo en ese momento.

// saldo = saldo + (saldo * interes_tpu);
// Redefiniremos el método ToString para que indique el tipo de cuenta antes de llamar al de la clase base para que muestre sus datos básicos. La salida correspondiente al ToString es la siguiente:

// ....en Cuenta Ahorro
// Numero de cuenta: 2085-0103-92-0300731702
// Titular: Nicolas
// Saldo: 0,00 €.
// ....
// Cuenta de depósito
// También aplica intereses al saldo actual, por lo cual hereda de cuenta de ahorro. Pero si el titular realiza un reintegro de parte del capital antes del vencimiento del plazo fijo, el banco deducirá un porcentaje sobre el reintegro.
// Por ejemplo, si el titular retira 1000€ antes del vencimiento del plazo y hay un recargo del 5% sobre el reintegro, el saldo disminuirá en 1000€ pero el titular sólo recibirá 950€. Por tanto el Reintegro devolverá la cantidad reducida.
// this.Saldo = this.Saldo - cantidad;
// // Si el depósito aún no venció.
// cantidad = cantidad - (cantidad * recargo_tpu);
// Si el plazo de la cuenta venció, no se cobrará recargo por el reintegro.
// Este tipo de cuenta no permite crédito y los intereses se abonarán al finalizar el mes sobre el saldo en ese momento, igual que en la clase padre.
// Anularemos el método ToString para que indique el tipo de cuenta antes de llamar al de la clase base para que muestre sus datos básicos como en la salida mostrada más abajo.
// ✋ Nota: Para poder probar la clase, el vencimiento se controlará desde fuera de la clase y en esta quedará reflejado mediante un valor booleano.

// Cuenta corriente
// No aplica intereses al saldo, pero permite al titular girar cheques y realizar reintegros a través del cajero automático. No obstante, el banco restringe el número de transacciones mensuales a una determinada cantidad y si el titular excede las transacciones; el banco le cobrará un recargo por transacción. Se consideran como transacciones los reintegros y los ingresos.
// Por ejemplo si tenemos 5 transacciones y realizamos 8 y el recargo por transacción adicional es de 1€, el banco nos cobrará 3€.

// Este recargo por pasar del número de transacciones mensuales establecido, se realizara al finalizar el mes. Momento en el cual se aplicará el recargo sobre el Saldo y además se reiniciará el número de transacciones a cero.

// Saldo = Saldo
//         - (numeroTrasaccionesMesActual - maximoTrasaccionesGratuitasPorMes) 
//         * recargoXTransaccionAdicional_Euros;
// Redefiniremos el método ToString para que indique el tipo de cuenta antes de llamar al de la clase base para que muestre sus datos básicos.

// Cuenta crédito
// Permite al titular retirar dinero adicional al que indica su saldo, hasta un límite de crédito. Pero esto no es gratuito; al finalizar el mes, el banco aplicará una tasa de interés al saldo negativo o descubierto en ese momento.
// Por ejemplo, si nuestro saldo es -1000€ al 20%, pagaremos un recargo de 200€, de tal manera que el nuevo saldo será de -1200€.
// double cargo = (Saldo < 0) ? Math.Abs(Saldo) * interes_tpu : 0d;
// Saldo = Saldo - cargo;
// A diferencia de la cuenta corriente, la cuenta de crédito no tiene límite para la cantidad de transacciones que se pueden realizar sobre ella. Pues al banco le interesa que nos quedemos sin dinero para poder "chuparnos la sangre".
// En todos los casos el control de tiempo se realizará de forma externa a las clases y los intereses, recargos, etc… se gestionarán a través de operaciones sobre los diferentes objetos de cuenta.
// Definiremos una excepción personaliza da CreditoMaximoExcedidoException, como clase anidada pública. Esta excepción se generará si el usuario al intentar realizar un reintegro que supere el límite de crédito establecido para la cuenta, teniendo en cuenta el Saldo, se le pasarán las tres cantidades al constructor y se construirá la cadena indicando el problema en la propia llamada a base.
// Anularemos el método ToString para que indique el tipo de cuenta antes de llamar al de la clase base para que muestre sus datos básicos.
// Programa principal
// Deberemos diseñar la jerarquía de clases que creamos más conveniente y probar el siguiente código…

namespace ejercicio3
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
            mensaje = $"{entidad}-{sucursal}-{dcEntSuc}{dcNumero}-{cuenta}";
            return mensaje;
        }
    }    
}
