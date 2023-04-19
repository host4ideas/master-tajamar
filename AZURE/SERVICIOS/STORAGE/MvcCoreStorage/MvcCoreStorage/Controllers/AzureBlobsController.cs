using Microsoft.AspNetCore.Mvc;
using MvcCoreStorage.Models;
using MvcCoreStorage.Services;

namespace MvcCoreStorage.Controllers
{
    public class AzureBlobsController : Controller
    {
        private readonly ServiceStorageBlob serviceStorageBlob;

        public AzureBlobsController(ServiceStorageBlob serviceStorageBlob)
        {
            this.serviceStorageBlob = serviceStorageBlob;
        }

        public async Task<IActionResult> Index()
        {
            List<string> containers = await this.serviceStorageBlob.GetContainersAsyc();
            return View(containers);
        }

        public IActionResult CreateContainer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContainer(string containerName)
        {
            await this.serviceStorageBlob.CreateContainerAsync(containerName);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteContainer(string containerName)
        {
            await this.serviceStorageBlob.DeleteContainerAsync(containerName);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ListBlobs(string containerName)
        {
            List<BlobModel> blobs = await this.serviceStorageBlob.GetBLobsAsync(containerName);
            return View(blobs);
        }

        public async Task<IActionResult> DeleteBlob(string containerName, string blobName)
        {
            await this.serviceStorageBlob.DeleteBlobAsync(containerName, blobName);
            return RedirectToAction("ListBlobs", new { containerName });
        }

        public IActionResult UploadBlob(string containerName)
        {
            ViewData["CONTAINER"] = containerName;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadBlob(string containerName, IFormFile file)
        {
            string blobName = file.FileName;
            using (Stream stream = file.OpenReadStream())
            {
                await this.serviceStorageBlob.UploadBlobAsync(containerName, blobName, stream);
            }

            return RedirectToAction("ListBlobs", new { containerName });
        }
    }
}
