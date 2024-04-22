// DAVIDE PRESTI
// - Ejercicio 4 -
// Crea una clase Guerrero que herede de la clase Humano del ejercicio anterior, añade los
// campos tipoArma y tipoArmadura y los métodos que creas necesarios, para hacerla funcional.
// Crea también la clase Mago hija de humano con los atributos tipoLibroHechizos y tipoTúnica y los métodos necesarios.
// 📌 Nota: Sería interesante que utilices tipos enumerados para los campos anteriormente descritos.

namespace ejercicio4
{
  class Mago : Humano
    {
        private string tunica;
        private string libroHechizos;

        public Mago(string nombre, int edad, float peso, Sexo sexo, int inteligencia,
                                                        int fuerza, int destreza, int energia,
        int dañoRecibido, in string tunica, in string libroHechizos) : base(nombre, edad, peso, sexo, inteligencia,
                                                    fuerza, destreza, energia, dañoRecibido, 0)
        {
            this.tunica = tunica;
            this.libroHechizos = libroHechizos;
        }

        protected override int GetDañoInfligido()
        {
            int daño;
            if (libroHechizos == LibroHechizos.BolaDeFuego.GetLibroHechizosInfo())
            {
                daño = 5;
                if(tunica == Tunica.Novicio.GetTunicaInfo())
                {
                    daño = 10;
                }
            }
            else if (libroHechizos == LibroHechizos.Congelacion.GetLibroHechizosInfo())
            {
                daño = 10;
                if (tunica == Tunica.Aprendiz.GetTunicaInfo())
                {
                    daño = 15;
                }
            }
            else if (libroHechizos == LibroHechizos.TormentaDeRayos.GetLibroHechizosInfo())
            {
                daño = 15;
                if (tunica == Tunica.Hechizero.GetTunicaInfo())
                {
                    daño = 20;
                }
            }
            else if (libroHechizos == LibroHechizos.AtrapaAlmas.GetLibroHechizosInfo())
            {
                daño = 30;
                if (tunica == Tunica.Nigromante.GetTunicaInfo())
                {
                    daño = 40;
                }
            }
            else
            {
                daño = 50;
            }

            daño = daño + (GetInteligencia()/5);
            return daño;
        }

        private string GetTunica()
        {
            return tunica;
        }

        private string GetLibroHechizos()
        {
            return libroHechizos;
        }

        public override int GetInteligencia()
        {
            return base.GetInteligencia()+(base.GetInteligencia()/5);
        }

        public override string ATexto()
        {
            return $"Mago\n\n{base.ATexto()}\nTunica: {GetTunica()}\nLibro de Hechizos: {GetLibroHechizos()}\n";
        }
    }
}