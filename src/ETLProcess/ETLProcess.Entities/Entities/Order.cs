using HBUC.Entities; 

namespace ETLProcess.Entities 
{
    public class Order : BaseEntity
    {
        public decimal OrderId { get; set; }
        public string UserId { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
