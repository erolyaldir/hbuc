using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ETLProcess.Entities;

namespace StreamReader.Infrastruce.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("orders","public");
            builder.HasKey(ci => ci.OrderId);
            builder.Property(ci => ci.OrderId).IsRequired(true).HasMaxLength(50).HasColumnName("order_id");
            builder.Property(ci => ci.UserId).IsRequired(true).HasMaxLength(50).HasColumnName("user_id");

        }
    }
}


