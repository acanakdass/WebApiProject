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
    class EfCategoryRepository : EfEntityRepositoryBase<Category>, ICategoryRepository
    {
        private WebApiProjectContext _webApiProjectContext { get => _context as WebApiProjectContext; }
        public EfCategoryRepository(WebApiProjectContext context) : base(context)
        {
        }

        public async Task<Category> GetByIdWithProducts(int categoryId)
        {
            var categoryWithProducts = await _webApiProjectContext.Categories.Include(cp => cp.Products).FirstOrDefaultAsync(c => c.Id == categoryId);
            return categoryWithProducts;
        }
    }
}
