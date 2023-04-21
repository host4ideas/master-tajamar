using Azure.Data.Tables;
using MvcCoreSasStorage.Repositories;
using MvcCoreSasStorage.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string azureKeys = builder.Configuration.GetValue<string>("AzureKeys:StorageAccount");

TableServiceClient tableServiceClient = new(azureKeys);
builder.Services.AddSingleton(tableServiceClient);
builder.Services.AddTransient<ServiceStorageTables>();
builder.Services.AddTransient<ServiceAzureAlumnos>();
builder.Services.AddTransient<RepositoryXML>();

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
