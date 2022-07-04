using HBUC.Entities; 

namespace ETLProcess.Entities 
{
    public class OrderItem:BaseEntity
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal OrderId { get; set; }

        public List<Order> Orders { get; set; }
        public List<Product> Products { get; set; }

    }
}
