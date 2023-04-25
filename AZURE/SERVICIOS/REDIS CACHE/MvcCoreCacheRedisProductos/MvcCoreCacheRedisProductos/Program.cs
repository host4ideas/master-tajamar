using MvcCoreCacheRedisProductos.Helpers;
using MvcCoreCacheRedisProductos.Repositories;
using MvcCoreCacheRedisProductos.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<RepositoryProductos>();
builder.Services.AddSingleton<HelperPathProvider>();
builder.Services.AddTransient<ServiceCacheRedis>();

string cnnRedis = builder.Configuration.GetValue<string>("AzureKeys:CacheRedis");
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = cnnRedis;
});

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

public static partial class Program
{
    static string cnnRedis;
}

/*
 using MvcCoreCacheRedisProductos.Helpers;
using MvcCoreCacheRedisProductos.Repositories;
using MvcCoreCacheRedisProductos.Services;

namespace MvcCoreCacheRedisProductos
{
    public static class Program
    {
        static string cnnRedis;

        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddTransient<RepositoryProductos>();
            builder.Services.AddSingleton<HelperPathProvider>();

            cnnRedis = builder.Configuration.GetValue<string>("AzureKeys:CacheRedis");

            builder.Services.AddTransient<ServiceCacheRedis>();
            builder.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = cnnRedis;
            });

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

 */