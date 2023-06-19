using Microsoft.EntityFrameworkCore;
using MvcCoreSeriesAWSBeanstalk.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string mariaCnn = builder.Configuration.GetConnectionString("MariaDbSeries");

builder.Services.AddDbContext<SeriesContext>(options =>
{
    options.UseMySql(mariaCnn, ServerVersion.AutoDetect(mariaCnn));
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
