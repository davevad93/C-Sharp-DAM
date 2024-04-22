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
  class Empresa
    {
        private readonly string cif;
        private readonly string razonSocial;
        private string direccion;
        private Empleado[] empleados;

        public Empresa(in string razonSocial, in string cif, in string direccion, in string dni, in string nombre, in int añoNacimiento, Empleado gerente)
        {
            this.cif = cif;
            this.razonSocial = razonSocial;
            this.direccion = direccion;
            AñadeGerente("23453456L", "María Soto del Rio", 1980, gerente);
        }
        
        public Empresa(Empresa empresa)
        {
            this.cif = empresa.cif;
            this.razonSocial = empresa.razonSocial;
            this.empleados = empresa.empleados;
            this.direccion = empresa.direccion;
        }

        public string NombreGerente()
        {
            string gerente = empleados[0].GetNombre();
            return gerente;
        }

        public string GetRazonSocial()
        {
            return razonSocial;
        }

        public string GetDireccion()
        {
            return direccion;
        }

        public string GetCif()
        {
            return cif;
        }

        public void AñadeGerente(in string dni, in string nombre, in int añoNacimiento, Empleado gerente)
        {
            gerente.SetCategoria(Empleado.Categoria.Gerente);
            this.empleados = this.empleados ?? new Empleado[1];
            empleados[0] = new Empleado(gerente);
        }

        public void SetDireccion(string direccion)
        {
            this.direccion = direccion;
        }

        public string DatosEmpresa()
        {
            string linea = $"\n{GetRazonSocial()}\n{NombreGerente()}\n{GetDireccion()}\n";
            return linea;
        }        

        public Empleado[] GetEmpleados()
        {
            return empleados;
        }

        public void Contrata(in string dni, in string nombre, in int añoNacimiento, in string categoria, Empleado empleado)
        {
            Array.Resize<Empleado>(ref empleados, empleados.Length + 1);
            empleado.SetCategoria((Empleado.Categoria)Enum.Parse(typeof(Empleado.Categoria), categoria));
            empleados[empleados.Length - 1] = new Empleado(empleado);
        }

        public string ACadena()
        {
            string linea = DatosEmpresa();
            Empleado[] empleados = GetEmpleados();
            foreach (var empleado in empleados)
            {
                linea += $"\n{empleado.ACadena()}";
            }
            return linea;
        }
    }
}