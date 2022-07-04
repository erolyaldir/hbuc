using Microsoft.Extensions.Hosting;
using Cronos;
using HBUC.Logging;
using Timer = System.Timers.Timer;
using Microsoft.Extensions.Configuration;
using StreamReader.Domain;

namespace ETLProcess.Domain.CronJobs
{
    public class CalculateTopSellProductsJob : CronJobBase
    {

        IProductService _productService;
        public CalculateTopSellProductsJob(IConfiguration configuration ,IProductService productService) :base(configuration.GetSection("CronJob")["CalculateTopSellProductsJob"])
        {
            _productService = productService;
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {            
            return base.StartAsync(cancellationToken);
        }
      
        public override Task DoWork(CancellationToken cancellationToken)
        {
            _productService.CalculateTopSellProducts();
            return Task.CompletedTask;
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        { 
            return base.StopAsync(cancellationToken);
        }
        
    }
}
