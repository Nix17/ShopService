using AutoMapper;
using BusinessLogicLayer.Mappings;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer;

public static class ServiceRegisration
{
    public static void AddBusinessLogicLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddSingleton(provider => new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new ProductProfile());
            cfg.AddProfile(new StoreProfile());
            cfg.AddProfile(new ProductBatchProfile());
        }).CreateMapper());

        // Если TRUE, то данные в SQLite, иначе InMemoryStream и CSV
        bool isSqlite = configuration.GetValue<bool>("StorageSettings:UseSqlite");

        if (isSqlite) services.AddTransient<ICsvWriterService, CsvWriterEmptyService>();
        else services.AddTransient<ICsvWriterService, CsvWriterService>();

        services.AddTransient<IShopCommands, ShopCommands>();
    }
}
