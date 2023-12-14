using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Contexts;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Чтение значения из конфигурационного файла
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        bool useSqlite = configuration.GetValue<bool>("StorageSettings:UseSqlite");

        // Выбор базы данных в зависимости от значения
        if (useSqlite)
        {
            optionsBuilder.UseSqlite("Data Source=shop-service-app.db");
        }
        else
        {
            optionsBuilder.UseInMemoryDatabase("ShopServiceDatabase");
        }
    }
}
