using Microsoft.EntityFrameworkCore;
using MvcSeguridadDoctores.Data;
using MvcSeguridadDoctores.Models;

namespace MvcSeguridadDoctores.Repositories
{
    public class RepositoryEnfermo
    {
        private readonly HospitalContext hospitalContext;

        public RepositoryEnfermo(HospitalContext hospitalContext)
        {
            this.hospitalContext = hospitalContext;
        }

        public Task<Enfermo?> FindEnfermo(string insc)
        {
            return this.hospitalContext.Enfermos.FirstOrDefaultAsync(x => x.Inscripcion == insc);
        }

        public Task<List<Enfermo>> GetEnfermos()
        {
            return this.hospitalContext.Enfermos.ToListAsync();
        }

        public async Task DeleteEnfermo(string insc)
        {
            Enfermo? enfermo = await this.FindEnfermo(insc);
            if (enfermo != null)
            {
                this.hospitalContext.Enfermos.Remove(enfermo);
                await this.hospitalContext.SaveChangesAsync();
            }
        }
    }
}
