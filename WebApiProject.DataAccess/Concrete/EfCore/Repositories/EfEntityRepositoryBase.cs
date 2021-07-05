using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApiProject.Core.Repositories;
using WebApiProject.DataAccess.Concrete.EfCore.Context;

namespace WebApiProject.DataAccess.Concrete.EfCore.Repositories
{

    public class EfEntityRepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly WebApiProjectContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public EfEntityRepositoryBase(WebApiProjectContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            return entities;
        }

        public async Task<IEnumerable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = _dbSet;
            query = query.Where(predicate);
            return await query.ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = _dbSet;
            var result = query.Where(predicate);
            return await result.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            await Task.Run(() => _context.Set<TEntity>().Update(entity));
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            _context.Entry(entity);
            _dbSet.Update(entity);
            return entity;
        }

        
    }
}
