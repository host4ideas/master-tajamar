using Newtonsoft.Json;
using NugetCustomers_FMB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NugetCustomers_FMB.Services
{
    public class ServiceNorthwind
    {
        public async Task<CustomersList> GetCustomersAsync()
        {
            HttpClient client = new();
            using HttpResponseMessage response = await client.GetAsync("http://www.contoso.com/");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            // Above three lines can be replaced with new helper method below
            // string responseBody = await client.GetStringAsync(uri);

            CustomersList customers = JsonConvert.DeserializeObject<CustomersList>(responseBody);
            return customers;

            //WebClient client = new WebClient();
            //client.Headers["content-type"] = "application/json";
            //string url =
            //    "https://services.odata.org/V4/Northwind/Northwind.svc/Customers";
            //string dataJson =
            //    await client.DownloadStringTaskAsync(url);
            //CustomersList customers =
            //    JsonConvert.DeserializeObject<CustomersList>(dataJson);
            //return customers;
        }

        public async Task<Customer?> FindCustomerAsync(string id)
        {
            CustomersList customerList = await GetCustomersAsync();
            return customerList.Customers.FirstOrDefault(x => x.IdCustomer == id);
        }

        public async Task<List<Order>?> GetCustomerOrdersAsync(string id)
        {
            WebClient client = new WebClient();
            client.Headers["content-type"] = "application/json";
            string url = "https://services.odata.org/V4/Northwind/Northwind.svc/Orders";
            string dataJson = await client.DownloadStringTaskAsync(url);
            OrdersList? orders = JsonConvert.DeserializeObject<OrdersList>(dataJson);

            return orders?.Orders.Where(x => x.CustomerId == id).ToList();
        }
    }
}
