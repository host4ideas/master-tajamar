using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebJobChollometro.Data;
using WebJobChollometro.Repositories;

string connectionString = @"Data Source=sqlfmb.database.windows.net;Initial Catalog=AZURETAJAMAR;User ID=adminsql;Password=Admin123";

var provider = new ServiceCollection()
    .AddTransient<RepositoryChollos>()
    .AddDbContext<ChollometroContext>(options =>
    {
        options.UseSqlServer(connectionString);
    }).BuildServiceProvider();

RepositoryChollos repositoryChollos = provider.GetService<RepositoryChollos>();

await repositoryChollos.PopulateChollosAsync();
