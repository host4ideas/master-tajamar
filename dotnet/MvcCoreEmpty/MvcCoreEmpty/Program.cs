var builder = WebApplication.CreateBuilder(args);

// Añadir los servicios de vistas y controllers
builder.Services.AddControllersWithViews();
// Debemos de indicar que controller y que action debemos de utilizar

var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}"
    );

//app.MapControllerRoute(
//    name: "seguridad",
//    pattern: "{controller=Security}/{action=Login}"
//    );

app.Run();
