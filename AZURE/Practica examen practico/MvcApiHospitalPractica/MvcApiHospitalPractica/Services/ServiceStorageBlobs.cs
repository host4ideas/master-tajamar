﻿using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using MvcApiHospitalPractica.Models;

namespace MvcApiHospitalPractica.Services
{
    public class ServiceStorageBlob
    {
        private readonly BlobServiceClient blobServiceClient;

        public ServiceStorageBlob(BlobServiceClient blobServiceClient)
        {
            this.blobServiceClient = blobServiceClient;
        }

        public async Task<List<string>> GetContainersAsync()
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

        public async Task<List<BlobModel>> GetBlobsAsync(string containerName)
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

        public async Task<string> GetBlobUriAsync(string container, string name)
        {
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(container);
            BlobClient blobClient = containerClient.GetBlobClient(name);

            var response = await containerClient.GetPropertiesAsync();
            var properties = response.Value;

            // Will be private if it's None
            if (properties.PublicAccess == Azure.Storage.Blobs.Models.PublicAccessType.None)
            {
                Uri imageUri = blobClient.GenerateSasUri(BlobSasPermissions.Read, DateTimeOffset.UtcNow.AddSeconds(3600));
                return imageUri.ToString();
            }

            return blobClient.Uri.AbsoluteUri.ToString();
        }

        public Task<string>? FindBlob(string containerName, string blobName)
        {
            return GetBlobUriAsync(containerName, blobName);
        }
    }
}
