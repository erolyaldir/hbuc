using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using HBUC.Logging;
using HBUC.Domain; 
using StackExchange.Redis;
using RecommendationAPI.Infrastruce.Data;
using RecommendationAPI.Domain;

namespace RecommendationAPI.Infrastruce
{
    public static class RegisterServiceExtensions
    { 
        public static IServiceCollection AddServicesConfigurations(this IServiceCollection services)
        { 
            var configuration = (IConfiguration)services.BuildServiceProvider().GetService(typeof(IConfiguration));
            services.AddDbContext<ProductViewContext>(c => c.UseNpgsql(configuration.GetConnectionString("ProductViewConnection")) );
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerService<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>)); 
            services.AddScoped<IProductViewService, ProductViewService>();
            services.AddSingleton<ConnectionMultiplexer>(sp =>
            {
                return ConnectionMultiplexer.Connect(configuration["Redis:ConnectionString"]);
            });
             
           
            return services;
        }


    }
}