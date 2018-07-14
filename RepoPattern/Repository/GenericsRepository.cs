using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using RepoPattern.Models;

namespace RepoPattern.Repository
{
    public class GenericsRepository<TEntity> : IGenericsRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _context;
        protected DbSet<TEntity> dbSet;

        public GenericsRepository(ApplicationDbContext context)
        {
            this._context = context;
            this.dbSet = _context.Set<TEntity>();
        }


        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public IQueryable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            return dbSet;
        }

        public async Task EditAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task InsertAsync(TEntity entity)
        {
            dbSet.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeletetAsync(TEntity entity)
        {
            dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}