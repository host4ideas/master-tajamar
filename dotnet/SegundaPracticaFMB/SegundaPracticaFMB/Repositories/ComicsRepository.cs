using SegundaPracticaFMB.Models;
using System.Data;
using System.Data.SqlClient;

#region PROCEDURES
//CREATE OR ALTER PROCEDURE SP_CREATE_COMIC
//(@P_IDCOMIC INT,
//@P_NOMBRE NVARCHAR(150),
//@P_IMAGEN NVARCHAR(600),
//@P_DESCRIPCION NVARCHAR(500))
//AS
//    INSERT INTO COMICS VALUES (@P_IDCOMIC, @P_IMAGEN, @P_IMAGEN, @P_DESCRIPCION);
//GO
#endregion

namespace SegundaPracticaFMB.Repositories
{
    public class ComicsRepository: IRepositoryComics
    {
        private SqlConnection cn;
        private SqlCommand cmd;
        private DataTable tablaComics;

        public ComicsRepository()
        {
            string connectionString = "Data Source=LOCALHOST\\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=sa;Password=MCSD2023";
            // Linq
            string sql = "SELECT * FROM COMICS";
            SqlDataAdapter adapter = new(sql, connectionString);
            this.tablaComics = new();
            adapter.Fill(tablaComics);
            // Ado.net
            this.cn = new SqlConnection(connectionString);
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

            SqlParameter paramCod = new("@P_IDCOMIC", this.GetMaxComic());
            this.cmd.Parameters.Add(paramCod);
            SqlParameter paramNombre = new("@P_NOMBRE", nombre);
            this.cmd.Parameters.Add(paramNombre);
            SqlParameter paramImagen = new("@P_IMAGEN", imagen);
            this.cmd.Parameters.Add(paramImagen);
            SqlParameter paramDesc = new("@P_DESCRIPCION", descripcion);
            this.cmd.Parameters.Add(paramDesc);

            this.cn.Open();
            this.cmd.ExecuteNonQuery();
            this.cmd.Parameters.Clear();
            this.cn.Close();
        }
    }
}
