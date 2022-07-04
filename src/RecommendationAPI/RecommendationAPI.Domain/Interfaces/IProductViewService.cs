
 
using RecommendationAPI.Entities;
using RecommendationAPI.Entities.Dto;

namespace RecommendationAPI.Domain 
{
    public interface IProductViewService
    {
        public List<ProductView> GetUserProductViews(string userId);
        public void DeleteUserProducts(string userId, string productId);
        public Tuple<List<BestSellerItem>, bool> GetBestSellers(string userId);
    }
}
