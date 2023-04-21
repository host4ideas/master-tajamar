using Azure.Data.Tables;
using Azure.Data.Tables.Sas;

namespace ApiSaSTokenStorageTables.Services
{
    public class ServiceSaSToken
    {
        private TableClient tableAlumnos;

        public ServiceSaSToken(IConfiguration configuration)
        {
            string azureKeys = configuration.GetValue<string>("AzureKeys:StorageAccount");
            TableServiceClient serviceClient = new(azureKeys);
            this.tableAlumnos = serviceClient.GetTableClient("alumnos");
        }

        public string GenerateSaSToken(string curso)
        {
            TableSasBuilder builder = this.tableAlumnos.GetSasBuilder(TableSasPermissions.Read, DateTime.Now.AddMinutes(50));
            builder.PartitionKeyStart = curso;
            builder.PartitionKeyEnd = curso;
            Uri uriToken = this.tableAlumnos.GenerateSasUri(builder);
            return uriToken.AbsoluteUri;
        }
    }
}
