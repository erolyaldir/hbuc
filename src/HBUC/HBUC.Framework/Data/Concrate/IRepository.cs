
using HBUC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBUC.Domain
{

    public interface IRepository<T> where T : BaseEntity
    { 
        public IQueryable<T> List { get;  }
        Task<T> AddAsync(T entity);

        Task AddRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task DeleteRangeAsync(IEnumerable<T> entities);

        IQueryable<T> Where(System.Linq.Expressions.Expression<Func<T, bool>> expression);
        Task<int> SaveChangesAsync();
    }
}
