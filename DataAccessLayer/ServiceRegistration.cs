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

namespace DataAccessLayer;

public static class ServiceRegistration
{
    public static void AddDataAccessLayerInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddDbContext<ApplicationDbContext>(options =>        
        //options.UseNpgsql(
        //   configuration.GetConnectionString("DefaultConnection"),
        //   b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
        //            .UseSnakeCaseNamingConvention()
        //    );
        
        
        services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddTransient<IUnitOfWork, UnitOfWork>();
    }
}
