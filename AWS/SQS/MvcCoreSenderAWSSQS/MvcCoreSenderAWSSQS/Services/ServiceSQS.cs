using Amazon.SQS;
using Amazon.SQS.Model;
using MvcCoreSenderAWSSQS.Models;
using Newtonsoft.Json;
using System.Net;

namespace MvcCoreSenderAWSSQS.Services
{
    public class ServiceSQS
    {
        private readonly IAmazonSQS ClientSQS;
        private readonly string UrlQueue;

        public ServiceSQS(IConfiguration configuration, IAmazonSQS clientSQS)
        {
            ClientSQS = clientSQS;
            this.UrlQueue = configuration.GetValue<string>("AWS:SQS:UrlQueue");
        }

        public async Task SendMessageAsync(Mensaje mensaje)
        {
            string json = JsonConvert.SerializeObject(mensaje);
            
            SendMessageRequest request = new()
            {
                MessageBody = json,
                QueueUrl = this.UrlQueue
            };

            SendMessageResponse response = await this.ClientSQS.SendMessageAsync(request);
            HttpStatusCode statusCode = response.HttpStatusCode;
        }
    }
}
