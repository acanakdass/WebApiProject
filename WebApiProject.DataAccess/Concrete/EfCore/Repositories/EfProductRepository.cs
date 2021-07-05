using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiProject.Core.Entities;
using WebApiProject.Core.Repositories;
using WebApiProject.DataAccess.Concrete.EfCore.Context;

namespace WebApiProject.DataAccess.Concrete.EfCore.Repositories
{
    public class EfProductRepository : EfEntityRepositoryBase<Product>, IProductRepository
    {
        private WebApiProjectContext _webApiProjectContext { get => _context as WebApiProjectContext; }

        public EfProductRepository(WebApiProjectContext context) : base(context)
        {
        }

        /// <summary>
        /// Parametre olarak gönderilen id bilgisine sahip product nesnesini, ait olduğu kategori bilgisi ile birlikte getirir.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns>Product nesnesi döndürür.</returns>
        public async Task<Product> GetByIdWithCategories(int productId)
        {
            var productWithCategory = await _webApiProjectContext.Products.Where(p => p.Id == productId).Include(p => p.Category).FirstOrDefaultAsync();
            return productWithCategory;
        }
    }
}
