using Amazon.S3.Model;
using Microsoft.AspNetCore.Mvc;
using MvcCoreAWSS3.Services;

namespace MvcCoreAWSS3.Controllers
{
    public class AWSFilesController : Controller
    {
        private readonly ServiceStorageS3 serviceStorageS3;
        private readonly string BucketUrl;

        public AWSFilesController(ServiceStorageS3 serviceStorageS3, IConfiguration configuration)
        {
            this.serviceStorageS3 = serviceStorageS3;
            this.BucketUrl = configuration.GetValue<string>("AWS:BucketUrl");
        }

        public async Task<IActionResult> Index()
        {
            ViewData["BUCKETURL"] = this.BucketUrl;
            var files = await this.serviceStorageS3.GetFilesAsync();
            return View(files);
        }

        public async Task<IActionResult> DeleteVersion(string fileName, string versionId)
        {
            await this.serviceStorageS3.DeleteVersionAsync(fileName, versionId);
            return RedirectToAction(nameof(Details), new { fileName });
        }

        public async Task<IActionResult> Details(string fileName)
        {
            ViewData["FILENAME"] = fileName;
            var versions = await this.serviceStorageS3.GetFileVersionsAsync(fileName);
            return View(versions);
        }

        public IActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            using Stream stream = file.OpenReadStream();
            await this.serviceStorageS3.UploadFileAsync(file.Name, stream);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> FileAWS(string fileName)
        {
            Stream stream = await this.serviceStorageS3.GetFileAsync(fileName);
            return File(stream, "image/jpg");
        }

        public async Task<IActionResult> DeleteFile(string fileName)
        {
            await this.serviceStorageS3.DeleteFileAsync(fileName);
            return RedirectToAction(nameof(Index));
        }
    }
}
