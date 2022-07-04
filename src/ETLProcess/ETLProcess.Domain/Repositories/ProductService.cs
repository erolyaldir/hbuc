using ETLProcess.Entities;
using ETLProcess.Entities.Dto;
using HBUC.Domain;
using HBUC.Logging;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace StreamReader.Domain
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ETLProcess.Entities.Order> _orderRepository;
        private readonly IRepository<OrderItem> _orderItemRepository; 
        ConnectionMultiplexer _redisConnection;
        private readonly IAppLogger<ProductService> _logger;
        public ProductService(IRepository<Product> productRepository, IRepository<ETLProcess.Entities.Order> orderRepository, IRepository<OrderItem> orderItemRepository, ConnectionMultiplexer redisConnection,IAppLogger<ProductService> logger)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository; 
            _redisConnection = redisConnection;
            _logger = logger;
        }
        public void CalculateTopSellProducts()
        {
            var qry = (from oi in _orderItemRepository.List
                       join o in _orderRepository.List on oi.OrderId equals o.OrderId
                       group oi by new { oi.ProductId, o.UserId }
                      into grp
                       select new SumObject
                       {
                           ProductId = grp.Key.ProductId,
                           Count = grp.Select(x => grp.Key.UserId).Distinct().Count()
                       }).ToList().GroupBy(x => x.ProductId).Select(grp => new SumObject
                       {
                           ProductId = grp.Key,
                           Count = grp.Count()
                       }).OrderBy(x => x.Count);
            var products = _productRepository.List.ToList();

            List<BestSellerItem> bestSellerItems = new List<BestSellerItem>();
            foreach (var t in qry)
            {
                bestSellerItems.Add(new BestSellerItem
                {
                    ProductId = t.ProductId,
                    Count = t.Count,
                    CategoryId = products.FirstOrDefault(x => x.ProductId == t.ProductId).CategoryId
                });
            }
            _redisConnection.GetDatabase(0) .ListLeftPushAsync("bestsellers", JsonConvert.SerializeObject(bestSellerItems));
           
        }
    }
    internal class SumObject
    {
        public string ProductId { get; set; }
        public int Count { get; set; }
    }
}
