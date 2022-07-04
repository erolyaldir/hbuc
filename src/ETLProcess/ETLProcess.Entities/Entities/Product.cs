using HBUC.Entities;
using System.Collections.Generic;

namespace ETLProcess.Entities
{
    public class Product : BaseEntity
    {
        public string ProductId { get; set; }
        public string CategoryId { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
