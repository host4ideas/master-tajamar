using Microsoft.EntityFrameworkCore;
using MvcSeguridadDoctores.Data;
using MvcSeguridadDoctores.Models;

namespace MvcSeguridadDoctores.Repositories
{
    public class RepositoryDoctores
    {
        private readonly HospitalContext hospitalContext;

        public RepositoryDoctores(HospitalContext hospitalContext)
        {
            this.hospitalContext = hospitalContext;
        }

        public Task<Doctor?> FindDoctor(int doctorNo)
        {
            return this.hospitalContext.Doctores.FirstOrDefaultAsync(x => x.DoctorNo == doctorNo);
        }

        /// <summary>
        /// Para login
        /// </summary>
        /// <param name="apellido"></param>
        /// <param name="doctorNo"></param>
        /// <returns></returns>
        public Task<Doctor?> FindDoctor(string apellido, int doctorNo)
        {
            return this.hospitalContext.Doctores.FirstOrDefaultAsync(x => x.DoctorNo == doctorNo && x.Apellido == apellido);
        }
    }
}
