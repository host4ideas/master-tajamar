using Microsoft.EntityFrameworkCore;
using MvcNetCoreZapatillas.Data;
using MvcNetCoreZapatillas.Repositories;
using MvcNetCoreZapatillas.Data;
using MvcNetCoreZapatillas.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString =
    builder.Configuration.GetConnectionString("SqlHospital");
builder.Services.AddTransient<RepositoryZapatillas>();
builder.Services.AddDbContext<ZapatillasContext>
    (options => options.UseSqlServer(connectionString));
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
    pattern: "{controller=Zapatillas}/{action=Zapatillas}/{id?}");

app.Run();
