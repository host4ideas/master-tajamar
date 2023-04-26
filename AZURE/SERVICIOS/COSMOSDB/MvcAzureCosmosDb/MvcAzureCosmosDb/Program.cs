using Microsoft.Azure.Cosmos;
using MvcAzureCosmosDb.Services;

namespace MvcAzureCosmosDb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            string connectionString = builder.Configuration.GetConnectionString("CosmosDb");
            string database = builder.Configuration.GetValue<string>("CochesCosmosDb:Database");
            string container = builder.Configuration.GetValue<string>("CochesCosmosDb:Container");

            CosmosClient clientCosmos = new(connectionString);
            Container containerCosmos = clientCosmos.GetContainer(database, container);
            builder.Services.AddSingleton(clientCosmos);
            builder.Services.AddTransient(x => containerCosmos);
            builder.Services.AddTransient<ServiceCosmosDb>();

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}