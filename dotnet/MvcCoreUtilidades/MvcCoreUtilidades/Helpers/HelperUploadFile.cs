﻿namespace MvcCoreUtilidades.Helpers
{
    public class HelperUploadFile
    {
        private readonly HelperPathProvider helperPath;

        public HelperUploadFile(HelperPathProvider helperPath)
        {
            this.helperPath = helperPath;
        }

        public async Task<string> UploadFileAsync(IFormFile file, Folders folder)
        {
            string fileName = file.FileName;
            string path = this.helperPath.MapPath(fileName, folder);

            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
                return path;
            }
        }

        public async Task<List<string>> UploadFileAsync(List<IFormFile> files, Folders folder)
        {
            List<string> paths = new();

            foreach (IFormFile file in files)
            {
                string fileName = file.FileName;
                string path = this.helperPath.MapPath(fileName, folder);
                paths.Add(path);

                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            return paths;
        }
    }
}
