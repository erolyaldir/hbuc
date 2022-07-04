using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ETLProcess.Entities ;

namespace StreamReader.Infrastruce.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("products", "public");
            builder.HasKey(ci => ci.ProductId);
            builder.Property(ci => ci.ProductId).IsRequired(true).HasMaxLength(50).HasColumnName("product_id");
            builder.Property(ci => ci.CategoryId).IsRequired(true).HasMaxLength(50).HasColumnName("category_id"); 
       
        }
    }
}


