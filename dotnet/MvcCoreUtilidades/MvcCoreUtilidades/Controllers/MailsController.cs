using Microsoft.AspNetCore.Mvc;
using MvcCoreUtilidades.Helpers;

namespace MvcCoreUtilidades.Controllers
{
    public class MailsController : Controller
    {
        private readonly HelperUploadFile helperUpload;
        private readonly HelperMail helperMail;

        public MailsController(HelperUploadFile helperUpload, HelperMail helperMail)
        {
            this.helperUpload = helperUpload;
            this.helperMail = helperMail;
        }

        public IActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMail(string para, string asunto, string mensaje, List<IFormFile> files)
        {
            if (files == null)
            {
                await this.helperMail.SendMailAsync(para, asunto, mensaje);
            }
            else
            {
                if (files.Count > 1)
                {
                    List<string> paths = await this.helperUpload.UploadFileAsync(files, Folders.Temp);
                    await this.helperMail.SendMailAsync(para, asunto, mensaje, paths);
                }
                else
                {
                    string path = await this.helperUpload.UploadFileAsync(files[0], Folders.Temp);
                    await this.helperMail.SendMailAsync(para, asunto, mensaje, path);
                }
            }

            ViewData["MENSAJE"] = "Email enviado correctamente";
            return View();
        }
    }
}
