using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiProject.Core.Repositories;
using WebApiProject.Core.UnitOfWork;
using WebApiProject.DataAccess.Concrete.EfCore.Context;
using WebApiProject.DataAccess.Concrete.EfCore.Repositories;

namespace WebApiProject.DataAccess.Concrete.EfCore.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WebApiProjectContext _context;
        private EfProductRepository _productRepository;
        private EfCategoryRepository _categoryRepository;

        public UnitOfWork(WebApiProjectContext context)
        {
            _context = context;
        }

        public IProductRepository Products => _productRepository ?? new EfProductRepository(_context) ;  //_productREpository varsa al yoksa yenisini new'le ve al.

        public ICategoryRepository Categories => _categoryRepository ?? new EfCategoryRepository(_context);

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
