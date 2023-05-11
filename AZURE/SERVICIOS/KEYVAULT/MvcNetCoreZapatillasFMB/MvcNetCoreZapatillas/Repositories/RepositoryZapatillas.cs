using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MvcNetCoreZapatillas.Data;
using MvcNetCoreZapatillas.Models;
using System.Collections.Generic;

#region SQL SERVER
//VUESTRO PROCEDIMIENTO DE PAGINACION DE IMAGENES DE ZAPATILLAS
//CREATE OR ALTER PROCEDURE SP_GRUPO_ZAPATILLAS
//(@IDPRODUCTO INT, @POSICION INT)
//AS
//	SELECT * FROM(SELECT CAST(ROW_NUMBER() OVER(ORDER BY IDIMAGEN) AS INT) AS POSICION,
//    IDIMAGEN, IDPRODUCTO, IMAGEN
//		FROM IMAGENESZAPASPRACTICA) AS QUERY
//		WHERE QUERY.POSICION >= @POSICION AND QUERY.POSICION < (@POSICION + 1);
//GO
#endregion

namespace MvcNetCoreZapatillas.Repositories
{
    public class RepositoryZapatillas
    {
        private readonly ZapatillasContext context;

        public RepositoryZapatillas(ZapatillasContext context)
        {
            this.context = context;
        }

        public Task<List<Zapatilla>> GetZapatillas()
        {
            return this.context.Zapatillas.ToListAsync();
        }

        public Task<Zapatilla?> FindZapatilla(int idProducto)
        {
            return this.context.Zapatillas.FirstOrDefaultAsync(x => x.IdProducto == idProducto);
        }

        public async Task<ImagenZapatilla> PaginacionImagenesZapatillas(int idProducto, int posicion)
        {
            string sql = "SP_GRUPO_ZAPATILLAS @IDPRODUCTO, @POSICION";

            SqlParameter paramIdProducto = new("@IDPRODUCTO", idProducto);
            SqlParameter paramPosicion = new("@POSICION", posicion);

            List<ImagenZapatilla> imagenes = await this.context.ImagenesZapatillas.FromSqlRaw(sql, paramIdProducto, paramPosicion).ToListAsync();

            return imagenes.FirstOrDefault();
        }

        public int GetNumeroRegistrosImagenZapa(int idProducto)
        {
            return this.context.ImagenesZapatillas.Where(x => x.IdProducto == idProducto).Count();
        }
    }
}
