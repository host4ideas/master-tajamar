using MvcNetCoreEF.Data;
using MvcNetCoreEF.Models;

namespace MvcNetCoreEF.Repositories
{
    public class RepositoryHospital
    {
        private HospitalContext context;

        public RepositoryHospital(HospitalContext context)
        {
            this.context = context;
        }

        public List<Hospital> GetHospitales()
        {
            var consulta = from datos in this.context.Hospitales
                           select datos;

            return consulta.ToList();
        }

        public Hospital FindHospital(int hospitalCod)
        {
            var consulta = from datos in this.context.Hospitales
                           where datos.IdHospital == hospitalCod
                           select datos;

            return consulta.FirstOrDefault();
        }
    }
}
