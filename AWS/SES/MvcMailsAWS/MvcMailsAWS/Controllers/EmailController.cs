using Amazon;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Net;
using System.Net.Mail;

namespace MvcMailsAWS.Controllers
{
    public class EmailController : Controller
    {
        private readonly IConfiguration _configuration;

        public EmailController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string to, string subject, string body)
        {
            string server = this._configuration.GetValue<string>("AWS:EmailCredentials:Server");
            string user = this._configuration.GetValue<string>("AWS:EmailCredentials:User");
            string password = this._configuration.GetValue<string>("AWS:EmailCredentials:Password");
            string sender = this._configuration.GetValue<string>("AWS:EmailCredentials:Email");

            MailMessage message = new(sender, to, subject, body);

            NetworkCredential credentials = new(user, password);

            SmtpClient smtpClient = new()
            {
                Host = server,
                Port = 25,
                EnableSsl = true,
                UseDefaultCredentials = true,
                Credentials = credentials
            };

            await smtpClient.SendMailAsync(message);

            ViewData["MENSAJE"] = "Mail enviado correctamente";

            return View();
        }

        public IActionResult EmailAWS()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> EmailAWS(string to, string subject, string body)
        //{
        //    string sender = this._configuration.GetValue<string>("AWS:EmailCredentials:Email");

        //    AmazonSimpleEmailServiceV2Client client = new(RegionEndpoint.USEast1);

        //    Destination destination = new()
        //    {
        //        ToAddresses = new List<string>() { to }
        //    };

        //    Message message = new()
        //    {
        //        Body = new Body()
        //        {
        //            Text = new Content() { Data = body }
        //        },
        //        Subject = new Content() { Data = subject },
        //    };

        //    SendEmailRequest sendEmailRequest = new()
        //    {
        //        Destination = destination,
        //        Content = new EmailContent() { Simple = message },
        //        FromEmailAddress = sender
        //    };

        //    SendEmailResponse response = await client.SendEmailAsync(sendEmailRequest);

        //    ViewData["MENSAJE"] = "Email enviado correctamente";

        //    return View();
        //}


        [HttpPost]
        public async Task<IActionResult> EMailAWS(string to, string subject, string body, IFormFile file)
        {
            string emailSender =
                this._configuration.GetValue<string>
                ("AWS:EmailCredentials:Email");
            AmazonSimpleEmailServiceClient client = new(RegionEndpoint.USEast1);

            if (file != null)
            {
                using MemoryStream memory = new();

                MimeMessage message = new()
                {
                    Subject = subject
                };
                message.From.Add(MailboxAddress.Parse(emailSender));
                message.To.Add(MailboxAddress.Parse(to));

                BodyBuilder builder = new()
                {
                    TextBody = body
                };

                using (Stream stream = file.OpenReadStream())
                {
                    builder.Attachments.Add(file.FileName, stream);
                }

                message.Body = builder.ToMessageBody();

                await message.WriteToAsync(memory);

                SendRawEmailRequest request = new SendRawEmailRequest();

                request.RawMessage = new RawMessage() { Data = memory };
                await client.SendRawEmailAsync(request);
                ViewData["MENSAJE"] = "Email con adjuntos enviado";
                return View();
            }
            else
            {
                Destination destination = new()
                {
                    ToAddresses = new List<string> { to }
                };

                Message message = new()
                {
                    Subject = new Content(subject),
                    Body = new Body(new Content(body))
                };

                SendEmailRequest request = new()
                {
                    Destination = destination,
                    Message = message,
                    Source = emailSender
                };

                SendEmailResponse response = await client.SendEmailAsync(request);

                ViewData["MENSAJE"] = "Email enviado correctamente AWS";
                return View();
            }
        }
    }
}
