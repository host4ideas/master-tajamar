using Azure.Messaging.ServiceBus;

namespace MvcLogicApps.Services
{
    public class ServiceServiceBus
    {
        private readonly ServiceBusClient serviceBusClient;
        private readonly List<string> Mensajes;

        public ServiceServiceBus(ServiceBusClient serviceBus)
        {
            this.serviceBusClient = serviceBus;
            this.Mensajes = new List<string>();
        }

        public async Task SendMEssageAsync(string data)
        {
            ServiceBusSender sender = this.serviceBusClient.CreateSender("developers");
            ServiceBusMessage message = new(data);
            await sender.SendMessageAsync(message);
        }

        public async Task<List<string>> ReceiveMessageAsync()
        {
            ServiceBusProcessor busProcessor = this.serviceBusClient.CreateProcessor("developers");
            busProcessor.ProcessMessageAsync += Processor_ProcessMessageAsync;
            busProcessor.ProcessErrorAsync += Processor_ProcessErrorAsync;
            await busProcessor.StartProcessingAsync();
            Thread.Sleep(30000);
            await busProcessor.StopProcessingAsync();
            return this.Mensajes;
        }

        public async Task Processor_ProcessMessageAsync(ProcessMessageEventArgs arg)
        {
            string content = arg.Message.Body.ToString();
            this.Mensajes.Add(content);
            await arg.CompleteMessageAsync(arg.Message);
        }

        private Task Processor_ProcessErrorAsync (ProcessErrorEventArgs arg)
        {
            return Task.CompletedTask;
        }
    }
}
