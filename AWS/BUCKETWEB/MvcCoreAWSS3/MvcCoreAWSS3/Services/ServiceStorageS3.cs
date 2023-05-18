using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Mvc;

namespace MvcCoreAWSS3.Services
{
    public class ServiceStorageS3
    {
        private readonly string BucketName;
        private readonly IAmazonS3 ClientS3;

        public ServiceStorageS3(IConfiguration configuration, IAmazonS3 clientS3)
        {
            this.ClientS3 = clientS3;
            this.BucketName = configuration.GetValue<string>("AWS:BucketName");
        }

        public async Task<bool> UploadFileAsync(string fileName, Stream stream)
        {
            PutObjectRequest request = new()
            {
                BucketName = this.BucketName,
                InputStream = stream,
                Key = fileName
            };

            PutObjectResponse response = await this.ClientS3.PutObjectAsync(request);

            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteFileAsync(string fileName)
        {
            DeleteObjectResponse response = await this.ClientS3.DeleteObjectAsync(this.BucketName, fileName);

            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<Tuple<string, List<string>>>> GetFilesAsync()
        {
            ListObjectsResponse response = await this.ClientS3.ListObjectsAsync(this.BucketName);
            List<Tuple<string, List<string>>> filesVersions = new();

            foreach (var file in response.S3Objects)
            {
                var fileVersions = await this.GetFileVersionsAsync(file.Key);
                filesVersions.Add(Tuple.Create(file.Key, fileVersions));
            }

            return filesVersions;
        }

        public async Task<Stream> GetFileAsync(string fileName)
        {
            GetObjectResponse response = await this.ClientS3.GetObjectAsync(this.BucketName, fileName);
            return response.ResponseStream;
        }

        public async Task<List<string>> GetFileVersionsAsync(string fileName)
        {
            ListVersionsResponse response = await this.ClientS3.ListVersionsAsync(this.BucketName);
            List<S3ObjectVersion> versions = response.Versions.Where(x => x.Key == fileName).ToList();
            return versions.Select(x => x.VersionId).ToList();
        }

        public async Task DeleteVersionAsync(string fileName, string versionId)
        {
            DeleteObjectRequest request = new()
            {
                BucketName = this.BucketName,
                VersionId = versionId,
                Key = fileName
            };

            await this.ClientS3.DeleteObjectAsync(request);
        }
    }
}
