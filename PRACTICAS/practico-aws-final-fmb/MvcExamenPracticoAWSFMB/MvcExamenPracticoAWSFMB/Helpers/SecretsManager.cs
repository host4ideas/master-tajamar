using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;

namespace MvcCubosAWS.Helpers {
    public class SecretsManager {

        public static async Task<string> GetSecretAsync() {
            string secretName = "secretosmvcpractico";
            string region = "us-east-1";

            IAmazonSecretsManager client = new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(region));

            GetSecretValueRequest request = new GetSecretValueRequest {
                SecretId = "arn:aws:secretsmanager:us-east-1:043642756697:secret:secretosmvcpractico-qRggkx",
                VersionStage = "AWSCURRENT",
            };

            GetSecretValueResponse response;

            response = await client.GetSecretValueAsync(request);
            string secret = response.SecretString;

            return secret;
        }
    }
}
