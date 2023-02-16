using Microsoft.EntityFrameworkCore;
using MvcNetCoreEF.Data;
using MvcNetCoreEF.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString = builder.Configuration.GetConnectionString("SqlHospitalLocal");
// Si utilizamos context de EF, estamos obligados a utilizar Transient en los repositorios
builder.Services.AddTransient<RepositoryHospital>();
// Para inyectar el context necesitamos la cadena de conexion solamente porque estamos hablando de SQL server
// Se utiliza el metodo AddDbContext<Context> para la inyeccion
builder.Services.AddDbContext<HospitalContext>(options => options.UseSqlServer(connectionString));

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
