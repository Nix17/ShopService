using AutoMapper;
using BusinessLogicLayer.Mappings;
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
    public static void AddBusinessLogicLayer(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddSingleton(provider => new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new ProductProfile());
            cfg.AddProfile(new StoreProfile());
            cfg.AddProfile(new ProductBatchProfile());
        }).CreateMapper());
    }
}
