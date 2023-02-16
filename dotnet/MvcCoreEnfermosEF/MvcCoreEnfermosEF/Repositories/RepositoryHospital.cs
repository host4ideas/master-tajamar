using MvcCoreEnfermosEF.Data;
using MvcCoreEnfermosEF.Models;

namespace MvcCoreEnfermosEF.Repositories
{
    public class RepositoryHospital
    {
        private HospitalContext context;

        public RepositoryHospital(HospitalContext context)
        {
            this.context = context;
        }

        public List<Enfermo> GetEnfermos()
        {
            var consulta = from datos in this.context.Enfermos select datos;
            return consulta.ToList();
        }

        public Enfermo FindEnfermo(string inscripcion)
        {
            var consulta = from datos in this.context.Enfermos where datos.Inscripcion == inscripcion select datos;
            return consulta.FirstOrDefault();
        }
    }
}
