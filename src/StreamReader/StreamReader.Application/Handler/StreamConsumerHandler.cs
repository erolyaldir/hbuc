using StreamReader.Infrastruce.KafkaStreamer;
using str.Entities.Dto;
using StreamReader.Domain ;

namespace Services.Customer.Handlers
{
    public class StreamConsumerHandler : IKafkaHandler<string, ProductViewDto>
    {
        IProductViewService _productViewService;
        public StreamConsumerHandler(IProductViewService productViewService)
        {
            _productViewService = productViewService;
        }

        public async Task HandleAsync(string key, ProductViewDto value)
        {
            _productViewService.AddProductView(value);
        }
    }
}