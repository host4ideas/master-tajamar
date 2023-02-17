using SegundaPracticaFMB.Models;
using System.Data.SqlClient;
using System.Data;
using Oracle.ManagedDataAccess.Client;

#region PROCEDURES
//CREATE OR REPLACE PROCEDURE SP_CREATE_COMIC
//(P_IDCOMIC COMICS.IDCOMIC%TYPE,
//P_NOMBRE COMICS.NOMBRE%TYPE,
//P_IMAGEN COMICS.IMAGEN%TYPE,
//P_DESCRIPCION COMICS.DESCRIPCION%TYPE)
//AS
//BEGIN
//  INSERT INTO COMICS VALUES (P_IDCOMIC, P_IMAGEN, P_IMAGEN, P_DESCRIPCION);
//COMMIT;
//END;
#endregion

namespace SegundaPracticaFMB.Repositories
{
    public class ComicsRepositoryOracle: IRepositoryComics
    {
        private OracleConnection cn;
        private OracleCommand cmd;
        private DataTable tablaComics;

        public ComicsRepositoryOracle()
        {
            string connectionString = @"Data Source=LOCALHOST:1521;Persist Security Info=false;User ID=system;Password=oracle";
            // Linq
            string sql = "SELECT * FROM COMICS";
            OracleDataAdapter adapter = new(sql, connectionString);
            this.tablaComics = new();
            adapter.Fill(tablaComics);
            // Ado.net
            this.cn = new OracleConnection(connectionString);
            this.cmd = this.cn.CreateCommand();
        }

        public List<Comic> GetComics()
        {
            var consulta = from datos in this.tablaComics.AsEnumerable()
                           select new Comic()
                           {
                               Id = datos.Field<int>("IDCOMIC"),
                               Descripcion = datos.Field<string>("DESCRIPCION"),
                               Imagen = datos.Field<string>("IMAGEN"),
                               Nombre = datos.Field<string>("NOMBRE")
                           };

            return consulta.ToList();
        }


        private int GetMaxComic()
        {
            var maximo = (from datos in this.tablaComics.AsEnumerable() select datos).Max(x => x.Field<int>("IDCOMIC") + 1);
            return maximo;
        }

        public void CreateComic(string nombre, string imagen, string descripcion)
        {
            this.cmd.CommandType = CommandType.StoredProcedure;
            this.cmd.CommandText = "SP_CREATE_COMIC";

            int comicID = this.GetMaxComic();

            OracleParameter paramCod = new(":P_IDCOMIC", comicID);
            this.cmd.Parameters.Add(paramCod);
            OracleParameter paramNombre = new(":P_NOMBRE", nombre);
            this.cmd.Parameters.Add(paramNombre);
            OracleParameter paramImagen = new(":P_IMAGEN", imagen);
            this.cmd.Parameters.Add(paramImagen);
            OracleParameter paramDesc = new(":P_DESCRIPCION", descripcion);
            this.cmd.Parameters.Add(paramDesc);

            this.cn.Open();
            this.cmd.ExecuteNonQuery();
            this.cmd.Parameters.Clear();
            this.cn.Close();
        }
    }
}
