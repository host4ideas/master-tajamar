using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using Microsoft.AspNetCore.Mvc;

namespace MvcCoreStorage.Services
{
    public class ServiceStorageFiles
    {
        private readonly ShareDirectoryClient root;

        public ServiceStorageFiles(IConfiguration configuration)
        {
            string azureKeys = configuration.GetValue<string>("AzureKeys:StorageAccount");
            ShareClient shareClient = new(azureKeys, "ejemplofiles");
            this.root = shareClient.GetRootDirectoryClient();
        }

        public async Task<List<string>> GetFilesAsync()
        {
            List<string> files = new();
            await foreach (ShareFileItem item in this.root.GetFilesAndDirectoriesAsync())
            {
                files.Add(item.Name);
            }

            return files;
        }

        public async Task<(string, string)> ReadFileAsync(string fileName)
        {
            ShareFileClient file = this.root.GetFileClient(fileName);
            ShareFileDownloadInfo data = await file.DownloadAsync();
            Stream stream = data.Content;
            string contenido = "";

            using (StreamReader reader = new(stream))
            {
                contenido = await reader.ReadToEndAsync();
            }

            return (contenido, data.ContentType);
        }

        public async Task UploadFileAsync(string fileName, Stream stream)
        {
            ShareFileClient file = this.root.GetFileClient(fileName);
            await file.CreateAsync(stream.Length);
            await file.UploadAsync(stream);
        }

        public async Task DeleteFilesAsync(string fileName)
        {
            ShareFileClient file = this.root.GetFileClient(fileName);
            await file.DeleteIfExistsAsync();
        }
    }
}
