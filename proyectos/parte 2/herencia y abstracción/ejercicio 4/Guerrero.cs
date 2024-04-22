// DAVIDE PRESTI
// - Ejercicio 4 -
// Crea una clase Guerrero que herede de la clase Humano del ejercicio anterior, añade los
// campos tipoArma y tipoArmadura y los métodos que creas necesarios, para hacerla funcional.
// Crea también la clase Mago hija de humano con los atributos tipoLibroHechizos y tipoTúnica y los métodos necesarios.
// 📌 Nota: Sería interesante que utilices tipos enumerados para los campos anteriormente descritos.

namespace ejercicio4
{
  class Guerrero : Humano
    {
        private string armadura;
        private string arma;

        public Guerrero(string nombre, int edad, float peso, Sexo sexo, int inteligencia,
                                                        int fuerza, int destreza, int energia,
        int dañoRecibido, in string armadura, in string arma) : base(nombre, edad, peso, sexo, inteligencia,
                                                    fuerza, destreza, energia, dañoRecibido, 0)
        {
            this.armadura = armadura;
            this.arma = arma;
        }

        public override int GetFuerza()
        {
            return base.GetFuerza() + (base.GetFuerza()/5);
        }

        private string GetArmadura()
        {
            
            return armadura;
        }

        private string GetArma()
        {
            return arma;
        }

        protected override int GetDestreza()
        {
            return base.GetDestreza();
        }

        protected override int GetDañoInfligido()
        {
            int daño;
            if (arma == Arma.Arco.GetArmaInfo())
            {
                daño = 3;
            }
            else if (arma == Arma.Daga.GetArmaInfo())
            {
                daño = 4;
            }
            else if (arma == Arma.Maza.GetArmaInfo())
            {
                daño = 6;
            }
            else if (arma ==Arma.Espada.GetArmaInfo())
            {
                daño = 8;
            }
            else if (arma == Arma.Ballesta.GetArmaInfo())
            {
                daño = 10;
            }
            else
            {
                daño = 12;
            }

            daño = daño + (GetDestreza()/5) + (GetFuerza()/3);
            return daño;
        }
        public override string ATexto()
        {
            return $"\nGuerrero\n\n{base.ATexto()}\nArmadura: {GetArmadura()}\nArma: {GetArma()}\n";
        }
    }
}