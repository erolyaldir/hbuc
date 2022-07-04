using Microsoft.EntityFrameworkCore;  
using System.Reflection; 
namespace ETLProcess.Infrastructure
{
    public class ETLProcessContext : DbContext
    {
        public ETLProcessContext(DbContextOptions<ETLProcessContext> options) : base(options)
        {
           
        }

         
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
