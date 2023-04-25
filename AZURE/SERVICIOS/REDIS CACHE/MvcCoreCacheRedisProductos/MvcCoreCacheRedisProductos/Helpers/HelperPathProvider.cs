namespace MvcCoreCacheRedisProductos.Helpers
{
    public enum Folders { Images, Documents, Temporal }

    public class HelperPathProvider
    {
        private IWebHostEnvironment webHostEnvironment;

        public HelperPathProvider(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        public string MapPath(string fileName, Folders folders)
        {
            string carpeta = "";

            switch (folders)
            {
                case Folders.Images:
                    carpeta = "images";
                    break;
                case Folders.Documents:
                    carpeta = "Documents";
                    break;
                case Folders.Temporal:
                    carpeta = "Temporal";
                    break;
            }
            string path = Path.Combine(this.webHostEnvironment.WebRootPath, carpeta, fileName);
            return path;
        }
    }
}
