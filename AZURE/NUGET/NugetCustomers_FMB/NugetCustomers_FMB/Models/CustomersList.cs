using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NugetCustomers_FMB.Models
{
    public class CustomersList
    {
        [JsonProperty("value")]
        public List<Customer> Customers { get; set; }
    }
}
