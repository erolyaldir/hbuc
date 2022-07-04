using HBUC.Entities;
using StreamReader.Infrastruce.Data;

namespace RecommendationAPI.Infrastruce.Data
{
    public class EfRepository<T> : RepositoryBase<T> where T : BaseEntity
    {
        public EfRepository(ProductViewContext dbContext) : base(dbContext)
        {
        }


    }
}
