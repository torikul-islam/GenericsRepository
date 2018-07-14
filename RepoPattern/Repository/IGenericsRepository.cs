using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattern.Repository
{
    public interface IGenericsRepository<TEntity>
    {
        Task<TEntity> GetByIdAsync(int id);
        IQueryable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> GetAll();
        Task EditAsync(TEntity entity);
        Task InsertAsync(TEntity entity);
        Task DeletetAsync(TEntity entity);

    }
}
