using Microsoft.AspNetCore.Mvc;
using MvcApiHospitalPractica.Services;

namespace MvcApiHospitalPractica.Controllers
{
    public class BlobsController : Controller
    {
        private ServiceStorageBlob serviceStorage;

        public BlobsController(ServiceStorageBlob serviceStorage)
        {
            this.serviceStorage = serviceStorage;
        }

        #region CONTAINERS

        public async Task<IActionResult> Containers()
        {
            return View(await this.serviceStorage.GetContainersAsync());
        }

        public async Task<IActionResult> DeleteContainer(string containerName)
        {
            await this.serviceStorage.DeleteContainerAsync(containerName);
            return RedirectToAction("Containers");
        }

        public IActionResult CreateContainer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContainer(string containerName, bool isPublic)
        {
            await this.serviceStorage.CreateContainerAsync(containerName, isPublic);
            return RedirectToAction("Containers");
        }

        #endregion

        #region BLOBS

        public async Task<IActionResult> Blobs(string containerName)
        {
            ViewData["CONTAINER"] = containerName;
            return View(await this.serviceStorage.GetBlobsAsync(containerName));
        }

        public async Task<IActionResult> DeleteBlob(string containerName, string blobName)
        {
            await this.serviceStorage.DeleteBlobAsync(containerName, blobName);
            return RedirectToAction("Blobs", new { containerName });
        }

        [HttpPost]
        public async Task<IActionResult> UploadBlob(string containerName, string blobname, IFormFile file)
        {
            using (Stream stream = file.OpenReadStream())
            {
                await this.serviceStorage.UploadBlobAsync(containerName, blobname, stream);
            }
            return RedirectToAction("Blobs", new { containerName });
        }

        #endregion
    }
}
