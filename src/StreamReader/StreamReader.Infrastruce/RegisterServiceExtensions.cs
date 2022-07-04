
using StreamReader.Infrastruce.KafkaStreamer;
using Microsoft.Extensions.DependencyInjection;
using StreamReader.Infrastruce.Data;
using StreamReader.Domain;  
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using HBUC.Logging;
using HBUC.Domain;

namespace StreamReader.Infrastruce
{
    public static class RegisterServiceExtensions
    { 
        public static IServiceCollection AddKafkaConsumer<Tk, Tv, THandler>(this IServiceCollection services,
            Action<KafkaConsumerConfig<Tk, Tv>> configAction) where THandler : class, IKafkaHandler<Tk, Tv>
        {
            var configuration = (IConfiguration)services.BuildServiceProvider().GetService(typeof(IConfiguration));
            services.AddDbContext<StreamWriterContext>(c => c.UseNpgsql(configuration.GetConnectionString("ProductViewConnection")));
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerService<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            services.AddScoped<IProductViewService, ProductViewService>();

            services.AddScoped<IKafkaHandler<Tk, Tv>, THandler>();

            services.AddHostedService<BackGroundKafkaConsumer<Tk, Tv>>();



            services.Configure(configAction);

            return services;
        }


    }
}