// DAVIDE PRESTI
// - Ejercicio 4 -
// Crea una clase Guerrero que herede de la clase Humano del ejercicio anterior, añade los
// campos tipoArma y tipoArmadura y los métodos que creas necesarios, para hacerla funcional.
// Crea también la clase Mago hija de humano con los atributos tipoLibroHechizos y tipoTúnica y los métodos necesarios.
// 📌 Nota: Sería interesante que utilices tipos enumerados para los campos anteriormente descritos.

namespace ejercicio4
{
  class Humano
    {
        private string nombre;
        private int edad;
        private float peso;
        private Sexo sexo;
        private int inteligencia;
        private int fuerza;
        private int destreza;
        private int energia;
        private int dañoRecibido;
        private int dañoInfligido;

        public Humano(string nombre, int edad, float peso, Sexo sexo, int inteligencia,
                    int fuerza, int destreza, int energia, int dañoRecibido, int dañoInfligido)
        {
            this.edad = edad;
            this.peso = peso;
            this.sexo = sexo;
            this.inteligencia = inteligencia;
            this.fuerza = fuerza;
            this.destreza = destreza;
            this.energia = energia;
            this.nombre = nombre;
            this.dañoRecibido = dañoRecibido;
            this.dañoInfligido = dañoInfligido;
        }

        private int GetEnergia()
        {
            return energia;
        }

        protected virtual int GetDestreza()
        {
            return destreza;
        }

        public virtual int GetFuerza()
        {
            return fuerza;
        }

        public virtual int GetInteligencia()
        {
            return inteligencia;
        }

        private Sexo GetSexo()
        {
            return sexo;
        }

        private float GetPeso()
        {
            return peso;
        }

        private int GetEdad()
        {
            return edad;
        }

        private string GetNombre()
        {
            return nombre;
        }

        private int GetDañoRecibido()
        {
            return dañoRecibido;
        }

        protected virtual int GetDañoInfligido()
        {
            return dañoInfligido;
        }

        public virtual string ATexto()
        {
            return $"Nombre: {GetNombre()}\nEdad: {GetEdad()} años\nPeso: {GetPeso()} kg\nSexo: {GetSexo()}\n" +
            $"Inteligencia: {GetInteligencia()}\nFuerza: {GetFuerza()}\nDestreza: {GetDestreza()}\nEnergía: {GetEnergia()}"+
            $"\nDaño que puede recibir por cada ataque: {GetDañoRecibido()}" + 
            $"\nDaño que puede infligir por cada ataque: {GetDañoInfligido()}";
        }
    }    
}