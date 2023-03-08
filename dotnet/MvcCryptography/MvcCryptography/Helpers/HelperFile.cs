using MvcCryptography.Models;
using MvcCryptography.Helpers;

namespace MvcCryptography.Helpers
{
    public class HelperFile
    {
        private readonly HelperPath helperPath;
        private IWebHostEnvironment hostEnvironment;

        public HelperFile(HelperPath helperPath, IWebHostEnvironment hostEnvironment)
        {
            this.helperPath = helperPath;
            this.hostEnvironment = hostEnvironment;
        }

        public Task DeleteFile(int fileId)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UploadFileAsync(IFormFile file, string fileName, string host, Folders folder)
        {
            string type = file.FileName.Split('.')[1];

            string carpeta = "";
            if (folder == Folders.Images)
            {
                carpeta = "images";
            }
            else if (folder == Folders.Files)
            {
                carpeta = "files";
            }
            else if (folder == Folders.Temp)
            {
                carpeta = "temp";
            }

            string finalFileName = fileName + "." + type;

            string rootPath = this.hostEnvironment.WebRootPath;
            string path = Path.Combine(rootPath, "uploads", carpeta, finalFileName);

            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
                return Path.Combine(host, "uploads", carpeta, finalFileName);
            }
        }
    }
}
