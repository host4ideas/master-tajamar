﻿using ClienteApiOAuth;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;

//CODIGO static void Main()
Console.WriteLine("Request Api OAuth");
Console.WriteLine("------------------------");
Console.WriteLine("Introduzca sus credenciales");
Console.WriteLine("User Name");
string user = Console.ReadLine();
Console.WriteLine("Password");
string pass = Console.ReadLine();
string response = await GetToken(user, pass);
Console.WriteLine(response);
Console.WriteLine("Fin de Programa");

static async Task<string> GetToken(string user, string pass)
{
    string urlApi = "https://apioauthempleados2023.azurewebsites.net/";
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