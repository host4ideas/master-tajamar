using NetCoreLinqToSqlInjection.Models;
using NetCoreLinqToSqlInjection.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Instancia el objeto por cada peticion de la clase
//builder.Services.AddTransient<Coche>();

// Instancia un unico coche
//builder.Services.AddSingleton<ICoche, Coche>();
//builder.Services.AddSingleton<ICoche, Deportivo>();

//Coche car = new()
//{
//    Marca = "Cochecito",
//    Imagen = "image3.jpg",
//    Modelo = "Super",
//    Velocidad = 100,
//    VelocidadMaxima = 200
//};
////builder.Services.AddSingleton<ICoche, Coche>(x => car);
//builder.Services.AddSingleton<ICoche>(car);

builder.Services.AddSingleton<RepositoryDoctores>();

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
