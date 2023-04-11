using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NugetCustomers_FMB.Models
{
    public class Order
    {
        [JsonProperty("OrderID")]
        public int OrderId { get; set; }
        [JsonProperty("CustomerID")]
        public string CustomerId { get; set; }
        [JsonProperty("OrderDate")]
        public DateTime OrderDate { get; set; }
        [JsonProperty("ShipName")]
        public string OrderName { get; set; }
    }
}
