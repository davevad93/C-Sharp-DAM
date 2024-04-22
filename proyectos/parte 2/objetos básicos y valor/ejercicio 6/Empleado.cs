// DAVIDE PRESTI
// - Ejercicio 6 -
// A partir del primer ejercicio y teniendo en cuenta la relación entre las clases, crea las claseEmpresa.
// 📌Nota:
// El método DatosEmpresa de Empresa devolverá la información de la empresa sin los empleados, 
// mientras que ACadena incluirá los empleados.
// Una posible salida sería:
// La Empresa S.L
// María Soto del Rio
// Calle el Pozo, 34 Bajo
// El empleado María Soto del Rio con dni: 23453456L tiene un salario 1920 y su categoria es: Gerente
// El empleado Juanma Perez Ortiz con dni: 14568712G tiene un salario 1440 y su categoria es: Administrativos
// El empleado Pedro Martinez Sancho con dni: 12346123K tiene un salario 1440 y su categoria es: Administrativos

namespace ejercicio6
{
  class Empleado
    {    
        private const double SALARIO_BASE = 1200;
        private readonly string dni;
        private readonly string nombre;
        private readonly int añoNacimento;
        public enum Categoria {Subalterno = 10, Administrativo = 20, JefeDepartamento = 40, Gerente = 60}
        private Categoria categoria;
        public Empleado(in string dni, in string nombre, in int nacimiento)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.añoNacimento = nacimiento;
        }

        public Empleado(Empleado empleado)
        {
            this.dni = empleado.dni;
            this.nombre = empleado.nombre;
            this.añoNacimento = empleado.añoNacimento;
            this.categoria = empleado.categoria;
        }

        public string GetNombre() 
        { 
            return nombre; 
        }

        public int GetAñoNacimiento() 
        { 
            return añoNacimento; 
        }

        public string GetDni() 
        {
            return dni; 
        }

        public void SetCategoria(Categoria categoria)
        {
            this.categoria = categoria;
        }

        public double Salario()
        {
            double salario = (SALARIO_BASE * (double)categoria) / 100 + SALARIO_BASE;
            return salario;
        }

        public string ACadena()
        {
            string linea;
            linea = $"El empleado {nombre} con dni: {dni} tiene un salario {Salario()} y su categoria es: {categoria}";
            return linea;
        }
    }
}