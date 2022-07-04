using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using HBUC.Logging;
using HBUC.Domain;
using ETLProcess.Infrastructure;
using ETLProcess.Domain.CronJobs;
using StreamReader.Domain;
using StackExchange.Redis;

namespace ETLProcess.Infrastruce
{
    public static class RegisterServiceExtensions
    { 
        public static IServiceCollection AddServicesConfigurations(this IServiceCollection services)
        { 
            var configuration = (IConfiguration)services.BuildServiceProvider().GetService(typeof(IConfiguration));
            services.AddDbContext<ETLProcessContext>(c => c.UseNpgsql(configuration.GetConnectionString("ETLProcessConnection")), ServiceLifetime.Singleton);
            services.AddSingleton(typeof(IAppLogger<>), typeof(LoggerService<>));
            services.AddSingleton(typeof(IRepository<>), typeof(EfRepository<>)); 
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<ConnectionMultiplexer>(sp =>
            {
                return ConnectionMultiplexer.Connect(configuration["Redis:ConnectionString"]);
            });
            services.AddHostedService<CalculateTopSellProductsJob>(); 
           
            return services;
        }


    }
}