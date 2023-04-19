using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using MvcCoreStorage.Models;

namespace MvcCoreStorage.Services
{
    public class ServiceStorageBlob
    {
        private readonly BlobServiceClient blobServiceClient;

        public ServiceStorageBlob(BlobServiceClient blobServiceClient)
        {
            this.blobServiceClient = blobServiceClient;
        }

        public async Task<List<string>> GetContainersAsyc()
        {
            List<string> containers = new();
            await foreach (var container in this.blobServiceClient.GetBlobContainersAsync())
            {
                containers.Add(container.Name);
            }
            return containers;
        }

        public async Task CreateContainerAsync(string containerName)
        {
            await this.blobServiceClient.CreateBlobContainerAsync(containerName, Azure.Storage.Blobs.Models.PublicAccessType.Blob);
        }

        public async Task DeleteContainerAsync(string containerName)
        {
            await this.blobServiceClient.DeleteBlobContainerAsync(containerName);
        }

        public async Task<List<BlobModel>> GetBLobsAsync(string containerName)
        {
            BlobContainerClient blobContainerClient = this.blobServiceClient.GetBlobContainerClient(containerName);

            List<BlobModel> blobModels = new();

            await foreach (var blob in blobContainerClient.GetBlobsAsync())
            {
                BlobClient blobClient = blobContainerClient.GetBlobClient(blob.Name);

                blobModels.Add(new()
                {
                    Contenedor = containerName,
                    Name = blob.Name,
                    Url = blobClient.Uri.AbsoluteUri
                });
            }

            return blobModels;
        }

        public async Task DeleteBlobAsync(string containerName, string blobName)
        {
            BlobContainerClient blobContainerClient = this.blobServiceClient.GetBlobContainerClient(containerName);
            await blobContainerClient.DeleteBlobAsync(blobName);
        }

        public async Task UploadBlobAsync(string containerName, string blobName, Stream stream)
        {
            BlobContainerClient containerClient =
                this.blobServiceClient.GetBlobContainerClient(containerName);
            await containerClient.UploadBlobAsync(blobName, stream);
        }
    }
}
