using Amazon.SQS;
using Microsoft.Extensions.DependencyInjection;
using MvcCoreSenderAWSSQS.Models;
using ReceiverSQSConsole.Services;

Console.WriteLine("App Service SQS Receiver");
var serviceProvider = new ServiceCollection()
    .AddAWSService<IAmazonSQS>()
    .AddTransient<ServiceSQS>()
    .BuildServiceProvider();

ServiceSQS serviceSQS = serviceProvider.GetService<ServiceSQS>();

List<Mensaje>? mensajes = await serviceSQS.ReceiveMessagesAsync();
if (mensajes == null)
{
    Console.WriteLine("No existen mensajes en la cola");
}
else
{
    foreach (Mensaje item in mensajes)
    {
        Console.WriteLine("---------START---------");
        Console.WriteLine("Asunto " + item.Asunto);
        Console.WriteLine("Email " + item.Email);
        Console.WriteLine("Contenido " + item.Contenido);
        Console.WriteLine("Fecha " + item.Fecha);
        Console.WriteLine("---------END---------");
    }
    Console.WriteLine("Fin de lectura de mensajes");
}
Console.WriteLine("Fin de programa");
