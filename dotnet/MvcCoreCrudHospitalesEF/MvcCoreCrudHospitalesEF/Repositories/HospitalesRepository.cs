using MvcCoreCrudHospitalesEF.Data;
using MvcCoreCrudHospitalesEF.Models;

namespace MvcCoreCrudHospitalesEF.Repositories
{
    public class HospitalesRepository
    {
        private HospitalesContext context;

        public HospitalesRepository(HospitalesContext context)
        {
            this.context = context;
        }

        public List<Hospital> GetHospitales()
        {
            var consulta = from datos in this.context.Hospitales select datos;
            return consulta.ToList();
        }

        public Hospital FindHospital(int id)
        {
            var consulta = from datos in this.context.Hospitales
                           where datos.HospitalCod == id
                           select datos;
            return consulta.FirstOrDefault();
        }

        public async Task DeleteHospital(int id)
        {
            Hospital hosp = this.FindHospital(id);
            this.context.Hospitales.Remove(hosp);
            await this.context.SaveChangesAsync();
        }

        private int GetMaximo()
        {
            var maximo = (from datos in this.context.Hospitales select datos).Max(x => x.HospitalCod);
            return maximo + 1;
        }

        public async Task InsertHospital(string nombre, string direccion, string telefono, int camas)
        {
            Hospital newHosp = new()
            {
                Nombre = nombre,
                Direccion = direccion,
                Telefono = telefono,
                Camas = camas,
                HospitalCod = this.GetMaximo()
            };

            this.context.Hospitales.Add(newHosp);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateHospital(Hospital hosp)
        {
            Hospital oldHosp = this.FindHospital(hosp.HospitalCod);
            oldHosp.Direccion = hosp.Direccion;
            oldHosp.Camas = hosp.Camas;
            oldHosp.Nombre = hosp.Nombre;
            oldHosp.Telefono = hosp.Telefono;
            await this.context.SaveChangesAsync();
        }
    }
}
