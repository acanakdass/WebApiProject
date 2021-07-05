using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebApiProject.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity:class
    {
        Task<TEntity> GetByIdAsync(int id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<IEnumerable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);


        Task<TEntity> AddAsync(TEntity entity);

        /// <summary>
        /// IEnumerable tipinde gönderilen birden fazla nesneyi oluşturur.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);
        
        void Remove(TEntity entity);
        
        void RemoveRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Parametre olarak verilen nesneyi günceller
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Güncellenen nesneyi döndürür</returns>
        TEntity Update(TEntity entity);

        /// <summary>
        /// Parametre olarak verilen nesneyi günceller.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Güncellenen nesneyi döndürür.</returns>
        Task<TEntity> UpdateAsync(TEntity entity);

    }
}
