using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApiProject.Core.Repositories;
using WebApiProject.Core.Services;
using WebApiProject.Core.UnitOfWork;

namespace WebApiProject.Service.Services
{
    public class BaseManager<TEntity> : IService<TEntity> where TEntity:class
    {
        public readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TEntity> _repository;

        public BaseManager(IUnitOfWork unitOfWork, IRepository<TEntity> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.SaveChangesAsync();
            return entities;
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var result = await _repository.GetAsync(predicate);
            return result;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            return result;
        }

        public void Remove(TEntity entity)
        {
            _repository.Remove(entity);
            _unitOfWork.SaveChanges();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _repository.RemoveRange(entities);
            _unitOfWork.SaveChanges();
        }

        public TEntity Update(TEntity entity)
        {
            _repository.Update(entity);
            _unitOfWork.SaveChanges();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            await _repository.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var result = await _repository.WhereAsync(predicate);
            return result;
        }
    }
}
