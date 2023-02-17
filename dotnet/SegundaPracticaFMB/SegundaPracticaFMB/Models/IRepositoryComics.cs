namespace SegundaPracticaFMB.Models
{
    public interface IRepositoryComics
    {
        public List<Comic> GetComics();
        public void CreateComic(string nombre, string imagen, string descripcion);
    }
}
