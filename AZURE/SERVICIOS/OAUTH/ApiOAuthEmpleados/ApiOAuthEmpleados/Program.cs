using ApiOAuthEmpleados.Data;
using ApiOAuthEmpleados.Helpers;
using ApiOAuthEmpleados.Repositories;
using Microsoft.EntityFrameworkCore;
using NSwag.Generation.Processors.Security;
using NSwag;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace ApiOAuthEmpleados
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //builder.Services.AddSingleton<HelperOAuthToken>();
            HelperOAuthToken helper = new(builder.Configuration);
            builder.Services.AddAuthentication(helper.GetAuthenticationOptions()).AddJwtBearer(helper.GetJwtOptions());
            builder.Services.AddSingleton(helper);

            //var service = (HelperOAuthToken)serviceProvider.GetService(typeof(HelperOAuthToken));

            string connectionString = builder.Configuration.GetConnectionString("SqlServer");

            builder.Services.AddTransient<RepositoryEmpleados>();
            builder.Services.AddDbContext<EmpleadosContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen(options =>
            //{
            //    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            //    {
            //        Title = "API OAuth Empleados 2023",
            //        Version = "v1",
            //        Description = "Ejemplo Seguridad API Tokens"
            //    });
            //});

            // REGISTRAMOS SWAGGER COMO SERVICIO
            builder.Services.AddOpenApiDocument(document =>
            {
                document.Title = "Api Timers";
                document.Description = "Api Timers 2022.  BBDD Timers para el proyecto";

                // CONFIGURAMOS LA SEGURIDAD JWT PARA SWAGGER,
                // PERMITE AÑADIR EL TOKEN JWT A LA CABECERA.
                document.AddSecurity("JWT", Enumerable.Empty<string>(),
                    new NSwag.OpenApiSecurityScheme
                    {
                        Type = OpenApiSecuritySchemeType.ApiKey,
                        Name = "Authorization",
                        In = OpenApiSecurityApiKeyLocation.Header,
                        Description = "Copia y pega el Token en el campo 'Value:' así: Bearer {Token JWT}."
                    }
                );

                document.OperationProcessors.Add(
                    new AspNetCoreOperationSecurityScopeProcessor("JWT"));
            });

            var app = builder.Build();

            app.UseOpenApi();
            //app.UseSwaggerUi3();

            //app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.InjectStylesheet("/css/bootstrap.css");
                options.InjectStylesheet("/css/material3x.css");
                options.SwaggerEndpoint(
                    url: "/swagger/v1/swagger.json", name: "Api v1");
                options.RoutePrefix = "";
                options.DocExpansion(DocExpansion.None);
            });

            //app.UseSwagger();
            //app.UseSwaggerUI(options =>
            //{
            //    options.SwaggerEndpoint("/swagger/v1/swagger.json", "API OAuth Empleados");
            //    options.RoutePrefix = "";
            //});

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
