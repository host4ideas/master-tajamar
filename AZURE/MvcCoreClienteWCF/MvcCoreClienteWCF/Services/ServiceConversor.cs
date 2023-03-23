using ServiceReference;

namespace MvcCoreClienteWCF.Services
{
    public class ServiceConversor
    {
        private readonly NumberConversionSoapTypeClient client;

        public ServiceConversor()
        {
            this.client = new NumberConversionSoapTypeClient(
                    NumberConversionSoapTypeClient.EndpointConfiguration.NumberConversionSoap
            );
        }

        public async Task<string> NumberToWordsRequestAsync(int number)
        {
            ulong input = (ulong)number;
            NumberToWordsResponse response = await this.client.NumberToWordsAsync(input);
            return response.Body.NumberToWordsResult;
        }
    }
}
