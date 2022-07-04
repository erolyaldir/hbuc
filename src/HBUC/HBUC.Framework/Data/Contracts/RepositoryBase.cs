using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using HBUC.Entities;
using HBUC.Domain;

namespace StreamReader.Infrastruce.Data
{
    public class RepositoryBase<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DbContext dbContext;


        public IQueryable<T> List { get { return dbContext.Set<T>(); } }

        public RepositoryBase(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            dbContext.Add(entity);

            await SaveChangesAsync();

            return entity;
        }
        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            dbContext.AddRangeAsync(entities);

            await SaveChangesAsync(); 
        }
        public async Task DeleteAsync(T entity)
        {
            dbContext.Remove(entity);

            await SaveChangesAsync();
        }

        public async Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            dbContext.RemoveRange(entities);

            await SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            dbContext.Update(entity);

            await SaveChangesAsync();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return dbContext.Set<T>().Where(expression);


        }


    }
}
