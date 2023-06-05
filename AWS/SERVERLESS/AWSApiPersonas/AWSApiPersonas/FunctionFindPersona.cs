using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using AWSApiPersonas.Repositories;
using Newtonsoft.Json;
using System.Net;

namespace AWSApiPersonas
{
    public class FunctionFindPersona
    {
        private readonly RepositoryPersonas repositoryPersonas;

        public FunctionFindPersona()
        {
            repositoryPersonas = new RepositoryPersonas();
        }

        public APIGatewayProxyResponse Find(int id, ILambdaContext context)
        {
            string jsonPersona = JsonConvert.SerializeObject(this.repositoryPersonas.FindPersona(id));

            var response = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = jsonPersona,
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };

            return response;
        }

        public APIGatewayProxyResponse Post(int id, ILambdaContext context)
        {
            string jsonPersona = JsonConvert.SerializeObject(this.repositoryPersonas.FindPersona(id));

            var response = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = jsonPersona,
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };

            return response;
        }
    }
}
