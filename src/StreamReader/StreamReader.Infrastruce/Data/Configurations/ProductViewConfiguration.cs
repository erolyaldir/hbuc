using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StreamReader.Entities.Entities; 

namespace StreamReader.Infrastruce.Data.Configurations
{
    public class ProductViewConfiguration : IEntityTypeConfiguration<ProductView>
    {
        public void Configure(EntityTypeBuilder<ProductView> builder)
        {
            builder.ToTable("ProductView", "stream");
            builder.HasKey(ci => ci.Id);
            builder.Property(ci => ci.Event).IsRequired(true).HasMaxLength(50);
            builder.Property(ci => ci.MessageId).HasMaxLength(50);
            builder.Property(ci => ci.UserId).IsRequired(true).HasMaxLength(100);
            builder.Property(ci => ci.ProductId).IsRequired(true).HasMaxLength(100);
            builder.Property(ci => ci.Source).HasMaxLength(50);
            builder.Property(ci => ci.CreatedDate); 
    }
    }
}


