using MvcFrameworkReto.Data;
using MvcFrameworkReto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcFrameworkReto.Repositories
{
    public class HospitalesRepository : IHospitalesRepository
    {
        private HospitalContext context;

        public HospitalesRepository(HospitalContext context)
        {
            this.context = context;
        }

        public List<Empleado> GetEmpleados()
        {
            var consulta = from datos in this.context.Empleados
                           select datos;
            return consulta.ToList();
        }
    }
}