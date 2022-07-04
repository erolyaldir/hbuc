using HBUC.Entities; 
namespace RecommendationAPI.Entities 
{
    public class ProductView  : BaseEntity
    {
        public string Id { get; set; } 
        public string Event { get; set; } 
        public string MessageId { get; set; } 
        public string UserId { get; set; } 
        public string ProductId { get; set; } 
        public string Source { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
