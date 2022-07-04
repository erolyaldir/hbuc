using HBUC.Entities;
using StreamReader.Infrastruce.Data;

namespace ETLProcess.Infrastructure
{
    public class EfRepository<T> : RepositoryBase<T> where T : BaseEntity
    {
        public EfRepository(ETLProcessContext dbContext) : base(dbContext)
        {
        }


    }
}
