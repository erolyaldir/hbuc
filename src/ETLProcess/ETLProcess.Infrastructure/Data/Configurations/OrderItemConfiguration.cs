using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ETLProcess.Entities;

namespace StreamReader.Infrastruce.Data.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("order_items", "public");
            builder.HasKey(ci => ci.Id);
            builder.Property(ci => ci.Id).IsRequired(true).HasColumnName("id");
            builder.Property(ci => ci.ProductId).IsRequired(true).HasMaxLength(50).HasColumnName("product_id");
            builder.Property(ci => ci.Quantity).IsRequired(true).HasColumnName("quantity");
            builder.Property(ci => ci.OrderId).IsRequired(true).HasColumnName("order_id");


            builder.HasMany(r => r.Products).WithMany(r => r.OrderItems);
            builder.HasMany(r => r.Orders).WithMany(r => r.OrderItems);
        }
    }
}


