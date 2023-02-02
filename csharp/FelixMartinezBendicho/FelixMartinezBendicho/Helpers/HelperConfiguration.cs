using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FelixMartinezBendicho.Helpers
{
    public class HelperConfiguration
    {
        public static string GetConnectionString()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("config.json", true, true);
            IConfigurationRoot config = builder.Build();
            return config["SqlPracticaAdo"]!;
        }
    }
}
