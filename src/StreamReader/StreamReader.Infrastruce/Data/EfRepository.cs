using HBUC.Entities; 
namespace StreamReader.Infrastruce.Data
{
    public class EfRepository<T> : RepositoryBase<T> where T : BaseEntity
    {
        public EfRepository(StreamWriterContext dbContext) : base(dbContext)
        {
        }


    }
}
