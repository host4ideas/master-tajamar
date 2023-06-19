using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;

namespace ApiPracticoAWSFMB.Helpers {
    public class SecretsManager {

        public static string GetSecretAsync() {
            string secretName = "secretosmvcpractico";
            string region = "us-east-1";

            IAmazonSecretsManager client = new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(region));

            GetSecretValueRequest request = new GetSecretValueRequest {
                SecretId = "arn:aws:secretsmanager:us-east-1:043642756697:secret:secretosmvcpractico-qRggkx",
                VersionStage = "AWSCURRENT",
            };

            GetSecretValueResponse response;

            response = client.GetSecretValueAsync(request).Result;
            string secret = response.SecretString;

            return secret;
        }
    }
}
