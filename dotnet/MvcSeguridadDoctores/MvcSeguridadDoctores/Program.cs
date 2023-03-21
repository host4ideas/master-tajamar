using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MvcSeguridadDoctores.Data;
using MvcSeguridadDoctores.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

// Seguridad
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("PERMISOS_ELEVADOS", policy => policy.RequireRole("ESPECIALIDAD", "PSIQUIATRIA", "CARDIOLOGIA"));
    options.AddPolicy("ADMIN_ONLY", policy => policy.RequireClaim("ADMIN"));
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(
        CookieAuthenticationDefaults.AuthenticationScheme,
        config =>
        {
            config.AccessDeniedPath = "/Managed/ErrorAcceso";
        }
);

// BBDD
string connectionString = builder.Configuration.GetConnectionString("SqlHospital");
builder.Services.AddTransient<RepositoryEnfermo>();
builder.Services.AddTransient<RepositoryDoctores>();
builder.Services.AddDbContext<HospitalContext>(options =>
{
    options.UseSqlServer(connectionString);
});

// Indicamos que queremos utilizar nuestras propias rutas
builder.Services.AddControllersWithViews(
    options => options.EnableEndpointRouting = false
).AddSessionStateTempDataProvider();

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

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.UseMvc(routes =>
{
    routes.MapRoute(
        name: "deleteEnfermo",
        template: "{controller=Enfermos}/{action=DeleteEnfermo}/{insc?}"
    );
    routes.MapRoute(
        name: "default",
        template: "{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
