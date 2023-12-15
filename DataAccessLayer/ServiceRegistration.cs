using DataAccessLayer.Contexts;
using DataAccessLayer.Interfaces.Repositories;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer;

public static class ServiceRegistration
{
    public static void AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
    {
        // Если TRUE, то данные в SQLite, иначе InMemoryStream и CSV
        bool isSqlite = configuration.GetValue<bool>("StorageSettings:UseSqlite");

        if (isSqlite)
        {
            services.AddDbContext<ApplicationDbContext>(opts =>
            {
                string connectionString = configuration.GetConnectionString("StorageSettings:SqliteConnection");
                opts.UseSqlite(connectionString);
            });
        }
        else
        {
            services.AddDbContext<ApplicationDbContext>(opts => opts.UseInMemoryDatabase("ShopServiceDatabase"));
        }

        services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddTransient<IUnitOfWork, UnitOfWork>();
    }
}
