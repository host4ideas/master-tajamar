using System.Diagnostics;

namespace ProyectoClases
{
    public class Director : Empleado
    {
        public Director()
        {
            this.SalarioMinimo += 200;
        }

        // Con new sobreescribimos el metodo de GetDIasVacaciones
        //public new int GetDiasVacaciones()
        //{
        //    Debug.WriteLine("GetVacaciones() DIRECTOR");
        //    int vacaciones = base.GetDiasVacaciones();
        //    return vacaciones + 8;
        //}

        // Con override
        public override int GetDiasVacaciones()
        {
            Debug.WriteLine("GetVacaciones() DIRECTOR");
            int vacaciones = base.GetDiasVacaciones();
            return vacaciones + 8;
        }

        public override string ToString()
        {
            return "Nombre Completo: " + this.GetNombreCompleto() + ", Salario: " + this.SalarioMinimo + ", Vacaciones: " + this.GetDiasVacaciones();
        }
    }
}
