using HBUC.Domain;
using HBUC.Logging;
using str.Entities.Dto;
using StreamReader.Entities.Entities;

namespace StreamReader.Domain
{
    public class ProductViewService : IProductViewService
    {
        private readonly IRepository<ProductView> _productViewRepository;
        private readonly IAppLogger<ProductViewService> _logger;
        public ProductViewService(IRepository<ProductView> productViewRepository, IAppLogger<ProductViewService> logger)
        {
            _productViewRepository = productViewRepository;
            _logger = logger;
        }
        public void AddProductView(ProductViewDto productView)
        { 
            var productViewItem = new ProductView
            {
                Id = Guid.NewGuid().ToString(),
                Event = productView.Event,
                MessageId = productView.MessageId,
                UserId = productView.UserId,
                ProductId = productView.Properties.ProductId,
                Source = productView.Context.Source,
                CreatedDate = DateTime.UtcNow
        };
            _productViewRepository.AddAsync(productViewItem) ;
            _logger.LogInformation($"ProductView was added with {productViewItem.Id} id to User {productViewItem.UserId}.");
        }
    }
}
