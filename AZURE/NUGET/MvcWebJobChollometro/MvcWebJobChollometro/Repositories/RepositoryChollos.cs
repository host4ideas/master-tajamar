using Microsoft.EntityFrameworkCore;
using MvcWebJobChollometro.Data;
using MvcWebJobChollometro.Models;

namespace MvcWebJobChollometro.Repositories
{
    public class RepositoryChollos
    {
        private ChollometroContext chollometroContext;

        public RepositoryChollos(ChollometroContext chollometroContext)
        {
            this.chollometroContext = chollometroContext;
        }

        public Task<List<Chollo>> GetChollosAsync()
        {
            var consulta = from datos in this.chollometroContext.Chollos
                           orderby datos.Fecha descending
                           select datos;

            return consulta.ToListAsync();
        }
    }
}
