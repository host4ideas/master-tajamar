using Microsoft.EntityFrameworkCore;
using MvcCoreMultiplesBBDD.Data;
using MvcCoreMultiplesBBDD.Models;
using MvcCoreMultiplesBBDD.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//string connetionString = builder.Configuration.GetConnectionString("OracleHospital");
//builder.Services.AddTransient<IRepositoryEmpleados, RepositoryEmpleadosOracle>();
//builder.Services.AddDbContext<HospitalContext>(options => options.UseOracle(connetionString));
string connetionString = builder.Configuration.GetConnectionString("SqlHospital");
builder.Services.AddTransient<IRepositoryEmpleados, RepositoryEmpleadosSql>();
builder.Services.AddDbContext<HospitalContext>(options => options.UseSqlServer(connetionString));

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
