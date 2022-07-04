using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using StreamReader.Entities.Entities;
namespace StreamReader.Infrastruce.Data
{
    public class StreamWriterContext : DbContext
    {
        public StreamWriterContext(DbContextOptions<StreamWriterContext> options) : base(options)
        {
           
        }


        public DbSet<ProductView> ProductViews { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
