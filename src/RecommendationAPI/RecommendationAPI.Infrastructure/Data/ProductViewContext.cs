using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection; 

namespace RecommendationAPI.Infrastruce.Data
{
    public class ProductViewContext : DbContext
    {
        public ProductViewContext(DbContextOptions<ProductViewContext> options) : base(options)
        {
           
        }


       // public DbSet<ProductView> ProductViews { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
