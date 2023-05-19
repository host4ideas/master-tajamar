using Amazon.SQS;
using Amazon.SQS.Model;
using MvcCoreSenderAWSSQS.Models;
using Newtonsoft.Json;

namespace ReceiverSQSConsole.Services
{
    public class ServiceSQS
    {
        private readonly IAmazonSQS SQSClient;
        private readonly string UrlQueue;

        public ServiceSQS(IAmazonSQS sQSClient)
        {
            SQSClient = sQSClient;
            UrlQueue = "https://sqs.us-east-1.amazonaws.com/043642756697/queue-viernes-standard";
        }

        public async Task<List<Mensaje>?> ReceiveMessagesAsync()
        {
            ReceiveMessageRequest request = new()
            {
                QueueUrl = UrlQueue,
                MaxNumberOfMessages = 10,
                WaitTimeSeconds = 5,
            };

            ReceiveMessageResponse response = await this.SQSClient.ReceiveMessageAsync(request);
            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Messages.ConvertAll(x => JsonConvert.DeserializeObject<Mensaje>(x.Body));
            }

            return default;
        }
    }
}
