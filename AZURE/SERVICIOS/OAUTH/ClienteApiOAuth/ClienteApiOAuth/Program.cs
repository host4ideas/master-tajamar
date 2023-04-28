using ClienteApiOAuth;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;

//CODIGO static void Main()
string urlApi = "https://apioauthempleados2023.azurewebsites.net/";

Acciones();

async void Acciones()
{
    Console.WriteLine("Request Api OAuth");
    Console.WriteLine("------------------------");
    Console.WriteLine("Introduzca sus credenciales");
    Console.WriteLine("User Name");
    string? user = Console.ReadLine();
    Console.WriteLine("Password");
    string? pass = Console.ReadLine();

    if (user == null || !user.Any() || pass == null || !pass.Any())
    {
        Acciones();
    }

    string token = await GetToken(user!, pass!);
    Console.WriteLine(token);
    Console.WriteLine("Realizando petición a empleados...");
    string empleados = await GetEmpleadosAsync(token);
    Console.WriteLine(empleados);
    Console.WriteLine("Fin de Programa");
}

async Task<string> GetToken(string user, string pass)
{
    LoginModel model = new LoginModel { Username = user, Password = pass };
    using (HttpClient client = new HttpClient())
    {
        string request = "/api/auth/login";
        client.BaseAddress = new Uri(urlApi);
        client.DefaultRequestHeaders.Clear();
        client.DefaultRequestHeaders.Accept.Add
            (new MediaTypeWithQualityHeaderValue("application/json"));
        //CONVERTIMOS NUESTRO MODEL A JSON
        string jsonModel = JsonConvert.SerializeObject(model);
        StringContent content = new StringContent(jsonModel
            , Encoding.UTF8, "application/json");
        HttpResponseMessage response =
            await client.PostAsync(request, content);
        if (response.IsSuccessStatusCode)
        {
            string data = await
                response.Content.ReadAsStringAsync();
            JObject jsonObject = JObject.Parse(data);
            string token = jsonObject.GetValue("response").ToString();
            return token;
        }
        else
        {
            return "Petición incorrecta: " + response.StatusCode;
        }
    }
}

async Task<string> GetEmpleadosAsync(string token)
{
    using HttpClient client = new();
    string request = "/api/empleados";
    client.BaseAddress = new Uri(urlApi);
    client.DefaultRequestHeaders.Clear();
    client.DefaultRequestHeaders.Accept.Add(new("application/json"));
    client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);

    HttpResponseMessage response = await client.GetAsync(request);

    if (response.IsSuccessStatusCode)
    {
        return await response.Content.ReadAsStringAsync();
    }

    return "Algo ha ido mal... " + response.StatusCode;
}
