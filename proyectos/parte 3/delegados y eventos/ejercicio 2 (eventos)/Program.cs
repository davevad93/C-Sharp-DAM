using System;

// DAVIDE PRESTI
// - Ejercicio 2 (Eventos) -
// Supongamos que un banco quiere que cada vez que se retire dinero de sus cajeros se envíe
// un eMail y un SMS al usuario que ha realizado la transacción. Desde el equipo informático se
// ha diseñado una clase Cajero que tendrá:
// Un campo entero que será el número de cajero.
// Un evento al que podremos suscribirnos denominado RetiradaDeEfectivo y cuya
// signatura enviará a los suscriptores el cajero donde se ha producido el evento, el dni del
// usuario que está realizando la retirada y la cantidad.
// Un método público RetiraEfectivo que recibirá el dni del usuario que hace la operación
// y la cantidad. Además, internamente el método mostrará por la pantalla del cajero (la
// consola) el mensaje "Realizando operación..." , se esperará 2 segundos y mostrará
// "Operación realizada con éxito" y a continuación desencadenará el evento informando
// a todos los suscriptores de la operación realizada.
// Crea dos clases EnvioEMail y EnvioSMS que implementen el método
// EnviarAvisoRetiradaDeEfectivo mediante el cual se suscriban a la publicación del evento por
// parte del objeto cajero y muestren por pantalla.
// "Buscando datos usuario <dni> ..."
// "Enviando <eMain | SMS> al usuario <dni> de retirada de <cantidad> el día <fecha>
// a las <hora> horas."
// Por último, crea un programa principal donde instáncies objetos de las tres clases anteriores y
// pruebes que el evento es enviado correctamente.

namespace ejercicio2Eventos
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Cajero cajero = new Cajero(1);
                EnvioEMail email = new EnvioEMail();
                EnvioSMS sms = new EnvioSMS();
                cajero.RetiradaDeEfectivo += email.EnviarAvisoRetiradaDeEfectivo;
                cajero.RetiradaDeEfectivo += sms.EnviarAvisoRetiradaDeEfectivo;
                cajero.RetiraEfectivo("Y3023366F", 1000);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }  
        }
    }        
}