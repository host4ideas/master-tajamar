using ApiSegundaPractica.Data;
using ApiSegundaPractica.Helpers;
using ApiSegundaPractica.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connectionString = builder.Configuration.GetConnectionString("SqlAzure");

builder.Services.AddDbContext<CubosContext>(options =>
{
    options.UseSqlServer(connectionString);
});
builder.Services.AddTransient<RepositoryCubos>();

HelperOAuthToken helper = new(builder.Configuration);
builder.Services.AddAuthentication(helper.GetAuthenticationOptions()).AddJwtBearer(helper.GetJwtOptions());
builder.Services.AddSingleton(helper);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
