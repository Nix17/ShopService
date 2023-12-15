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
using DataAccessLayer.Helpers;
using DataAccessLayer.Entities;

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
                string connectionString = configuration.GetConnectionString("SqliteConnection");
                if (string.IsNullOrEmpty(connectionString)) connectionString = "shop-service-app.db";
                opts.UseSqlite(connectionString);
            });
        }
        else
        {
            services.AddDbContext<ApplicationDbContext>(opts => opts.UseInMemoryDatabase("ShopServiceDatabase"));
            
            CsvReadWriteHelper.ReadCsvFile<string>("");


            // Получаем текущую директорию
            string currentDirectory = Directory.GetCurrentDirectory();
            string storesCsvPath = Path.Combine(currentDirectory, "Data\\stores.csv");
            string productsCsvPath = Path.Combine(currentDirectory, "Data\\products.csv");

            // Получаем контекст
            var serviceProvider = services.BuildServiceProvider();
            var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
            // Читаем данные из CSV
            var stores = CsvReadWriteHelper.ReadCsvFile<StoresCsvModel>(storesCsvPath);
            var products = CsvReadWriteHelper.ReadCsvFile<ProductsCsvModel>(productsCsvPath);
            ImportDataHelper.ImportToDbInMemory(dbContext, stores, products).Wait();
        }

        services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddTransient<IUnitOfWork, UnitOfWork>();
    }
}
