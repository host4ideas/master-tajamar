using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MvcCoreEfProcedures.Data;
using MvcCoreEfProcedures.Models;

namespace MvcCoreEfProcedures.Repositories
{
    public class RepositoryTrabajadores
    {
        private EnfermosContext context;

        public RepositoryTrabajadores(EnfermosContext context)
        {
            this.context = context;
        }

        public List<Trabajador> GetTrabajadores()
        {
            var consulta = from datos in this.context.Trabajadores
                           select datos;
            return consulta.ToList();
        }

        public List<string> GetOficios()
        {
            var consulta = (from datos in this.context.Trabajadores
                            select datos.Oficio).Distinct().ToList();
            return consulta;
        }

        public TrabajadoresModel GetTrabajadoresModel(string oficio)
        {
            string sql = "SP_TRABAJADORES_OFICIO @OFICIO, @PERSONAS OUT, @MEDIA OUT, @SUMA OUT";

            SqlParameter paramOficio = new("@OFICIO", oficio);
            SqlParameter outPersonas = new("@PERSONAS", 1);
            SqlParameter outMedia = new("@MEDIA", 1);
            SqlParameter outSuma = new("@SUMA", 1);

            outPersonas.Direction = System.Data.ParameterDirection.Output;
            outMedia.Direction = System.Data.ParameterDirection.Output;
            outSuma.Direction = System.Data.ParameterDirection.Output;

            var consulta = this.context.Trabajadores.FromSqlRaw(sql, paramOficio, outPersonas, outMedia, outSuma);
            TrabajadoresModel model = new()
            {
                Trabajadores = consulta.ToList(),
                Personas = int.Parse(outPersonas.Value.ToString()),
                MediaSalarial = int.Parse(outMedia.Value.ToString()),
                SumaSalarial = int.Parse(outSuma.Value.ToString())
            };

            return model;
        }
    }
}
