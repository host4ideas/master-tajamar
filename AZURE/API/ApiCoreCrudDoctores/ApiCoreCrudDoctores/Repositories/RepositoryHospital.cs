using ApiCoreCrudDoctores.Data;
using ApiCoreCrudDoctores.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCoreCrudDoctores.Repositories
{
    public class RepositoryHospital
    {
        private HospitalContext hospitalContext;

        public RepositoryHospital(HospitalContext hospitalContext)
        {
            this.hospitalContext = hospitalContext;
        }

        public Task<List<Doctor>> GetDoctorsAsync()
        {
            return this.hospitalContext.Doctores.ToListAsync();
        }

        public async Task<Doctor?> FindDoctorAsync(int id)
        {
            return await this.hospitalContext.Doctores.FindAsync(id);
        }

        private async Task<int> GetMaxDoctorAsync()
        {
            return await this.hospitalContext.Doctores.MaxAsync(x => x.Id) + 1;
        }

        public async Task CreateDoctorAsync(int idHospital, string apellido, string especialidad, int salario)
        {
            await this.hospitalContext.Doctores.AddAsync(new()
            {
                Id = await this.GetMaxDoctorAsync(),
                Apellido = apellido,
                Especialidad = especialidad,
                IdHospital = idHospital,
                Salario = salario
            });
            await this.hospitalContext.SaveChangesAsync();
        }

        public async Task DeleteDoctorAsync(int id)
        {
            Doctor? doctor = await this.FindDoctorAsync(id);
            if (doctor != null)
            {
                this.hospitalContext.Doctores.Remove(doctor);
                await this.hospitalContext.SaveChangesAsync();
            }
        }

        public async Task IncrementarSalarioAsync(int id, int incremento)
        {
            Doctor? doctor = await this.FindDoctorAsync(id);
            if (doctor != null)
            {
                doctor.Salario += incremento;
                await this.hospitalContext.SaveChangesAsync();
            }
        }

        public async Task UpdateDoctorAsync(int id, int idHospital, string apellido, string especialidad, int salario)
        {
            Doctor? doctor = await this.FindDoctorAsync(id);
            if (doctor != null)
            {
                doctor.Apellido = apellido;
                doctor.Especialidad = especialidad;
                doctor.Salario = salario;
                doctor.IdHospital = idHospital;
                await this.hospitalContext.SaveChangesAsync();
            }
        }
    }
}
