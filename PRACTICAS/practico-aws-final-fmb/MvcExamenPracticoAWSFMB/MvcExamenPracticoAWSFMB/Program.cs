using Amazon.S3;
using MvcCubosAWS.Helpers;
using MvcCubosAWS.Models;
using MvcExamenPracticoAWSFMB.Services;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpClient();

// AWS Secrets Manager ============================================ 
string secret = await SecretsManager.GetSecretAsync();
KeysModel model = JsonConvert.DeserializeObject<KeysModel>(secret);
builder.Services.AddSingleton<KeysModel>(model);

builder.Services.AddAWSService<IAmazonS3>();
builder.Services.AddTransient<ServiceStorageS3>();
builder.Services.AddTransient<ServiceConciertos>();

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
