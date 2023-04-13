using ApiCoreHospitales.Data;
using ApiCoreHospitales.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCoreHospitales.Repositories
{
    public class RepositoryHospital
    {
        private HospitalesContext hospitalesContext;

        public RepositoryHospital(HospitalesContext hospitalesContext)
        {
            this.hospitalesContext = hospitalesContext;
        }

        public async Task<List<Hospital>> GetHospitalesAsync()
        {
            return await this.hospitalesContext.Hospitales.ToListAsync();
        }

        public async Task<Hospital?> FindHospitalAsync(int idHospital)
        {
            return await this.hospitalesContext.Hospitales.FindAsync(idHospital);
        }
    }
}
