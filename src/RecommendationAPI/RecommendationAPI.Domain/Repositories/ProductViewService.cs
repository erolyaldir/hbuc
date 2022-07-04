using HBUC.Domain;
using HBUC.Logging;
using Newtonsoft.Json;
using RecommendationAPI.Entities;
using RecommendationAPI.Entities.Dto;
using StackExchange.Redis;

namespace RecommendationAPI.Domain
{
    public class ProductViewService : IProductViewService
    {
        private readonly IRepository<ProductView> _productViewRepository;
        private readonly IAppLogger<ProductViewService> _logger;
        ConnectionMultiplexer _redisConnection;
        public ProductViewService(IRepository<ProductView> productViewRepository, ConnectionMultiplexer redisConnection, IAppLogger<ProductViewService> logger)
        {
            _productViewRepository = productViewRepository;
            _redisConnection = redisConnection;
            _logger = logger;
        }

        public void DeleteUserProducts(string userId, string productId)
        {
            var productViews = _productViewRepository.Where(x => x.UserId == userId && x.ProductId == productId).ToList();
            _productViewRepository.DeleteRangeAsync(productViews);
            _logger.LogInformation($"ProductView was deleted of {userId} and productId {productId}.");
        }

        public Tuple<List<BestSellerItem>, bool> GetBestSellers(string userId)
        {
            var products = JsonConvert.DeserializeObject<List<BestSellerItem>>(_redisConnection.GetDatabase(0).ListRange("bestsellers")[0]);
            var productViews = _productViewRepository.Where(x => x.UserId == userId).ToList();
            if (productViews.Any())
            {
                var grpItems = productViews.GroupBy(x => x.ProductId).Select(x => new SumObject
                {
                    ProductId = x.Key,
                    Count = x.Count()
                }).OrderBy(x => x.Count).Take(3);

                var categoryOfProducts = products.Where(x => grpItems.Select(q => q.ProductId).Contains(x.ProductId)).ToList().Select(x => x.CategoryId);

                return new Tuple<List<BestSellerItem>, bool>(products.Where(x => categoryOfProducts.Contains(x.CategoryId)).OrderBy(x => x.Count).Take(10).ToList(),true); 
            }
            else
            { 
                return new Tuple<List<BestSellerItem>, bool>(products.OrderBy(x => x.Count).Take(10).ToList(), true);
            }
             
        }

        public List<ProductView> GetUserProductViews(string userId)
        {
            return _productViewRepository.Where(x => x.UserId == userId).Distinct().OrderBy(x => x.CreatedDate).Take(10).ToList();
        }

    }
    internal class SumObject
    {
        public string ProductId { get; set; }
        public int Count { get; set; }
    }
}
