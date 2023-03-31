using Newtonsoft.Json;

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
class AuthResponse
{
    public string token_type { get; set; }
    public string expires_in { get; set; }
    public string ext_expires_in { get; set; }
    public string expires_on { get; set; }
    public string not_before { get; set; }
    public string resource { get; set; }
    public string access_token { get; set; }
}

class Program
{
    private static async Task<string> GetBearerToken(string clientId, string clientSecret, string tenantId)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Post, $"https://login.microsoftonline.com/{tenantId}/oauth2/token");
        var collection = new List<KeyValuePair<string, string>>
        {
            new("grant_type", "client_credentials"),
            new("client_id", clientId),
            new("client_secret", clientSecret),
            new("resource", "https://management.azure.com/")
        };
        var content = new FormUrlEncodedContent(collection);
        request.Content = content;
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();

        AuthResponse myDeserializedClass = JsonConvert.DeserializeObject<AuthResponse>(await response.Content.ReadAsStringAsync());

        return myDeserializedClass.access_token;
    }

    private static async Task Requests()
    {
        Console.Write("Type 1 to list resources or 2 to create a new one. Type 0 to cancel: ");
        string responseContent = "Cancelled";

        if (int.TryParse(Console.ReadLine(), out var option))
        {
            if (option != 0)
            {
                string clientId;
                string clientSecret;
                string tenantId;
                string subscriptionId;

                Console.WriteLine("Enter the Application (client) ID: ");
                clientId = Console.ReadLine();

                Console.WriteLine("Enter the Client Secret (password): ");
                clientSecret = Console.ReadLine();

                Console.WriteLine("Enter the Directory (tenant) ID: ");
                tenantId = Console.ReadLine();

                Console.WriteLine("Enter the Subscription ID: ");
                subscriptionId = Console.ReadLine();

                if (clientId == null || !clientId.Any() || clientSecret == null || !clientSecret.Any() || tenantId == null || !tenantId.Any() || subscriptionId == null || !subscriptionId.Any())
                {
                    Console.WriteLine("Values cannot be null. If you don't have the values, please register an application in Azure. \n You can retrieve your subscription ID by running: az account show --query id");
                    await Requests();
                }

                var client = new HttpClient();

                if (option == 1)
                {
                    string bearerToken = await GetBearerToken(clientId, clientSecret, tenantId);

                    var request = new HttpRequestMessage(HttpMethod.Get, $"https://management.azure.com/subscriptions/{subscriptionId}/resourcegroups?api-version=2021-04-01");
                    request.Headers.Add("Authorization", $"Bearer {bearerToken}");
                    var response = await client.SendAsync(request);
                    response.EnsureSuccessStatusCode();
                    responseContent = await response.Content.ReadAsStringAsync();
                }
                else if (option == 2)
                {
                    string bearerToken = await GetBearerToken(clientId, clientSecret, tenantId);

                    var request = new HttpRequestMessage(HttpMethod.Put, $"https://management.azure.com/subscriptions/{subscriptionId}/resourcegroups/AzureRESTResourceGroup?api-version=2021-04-01");
                    request.Headers.Add("Authorization", $"Bearer {bearerToken}");
                    var content = new StringContent("{'location': 'westus'}", null, "application/json");
                    request.Content = content;
                    var response = await client.SendAsync(request);
                    response.EnsureSuccessStatusCode();
                    responseContent = await response.Content.ReadAsStringAsync();
                }

                Console.WriteLine(responseContent);
            }
            else
            {
                Console.WriteLine(responseContent);
            }
        }
        else
        {
            Console.WriteLine("Invalid option");
        }

        if (option != 0)
        {
            await Requests();
        }
    }

    static void Main(string[] args)
    {
        Requests().Wait();
    }
}
