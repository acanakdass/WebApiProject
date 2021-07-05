using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiProject.Core.Entities;
using WebApiProject.Core.Repositories;
using WebApiProject.Core.Services;
using WebApiProject.Core.UnitOfWork;

namespace WebApiProject.Service.Services
{
    public class CategoryManager : BaseManager<Category>, ICategoryService
    {
        public CategoryManager(IUnitOfWork unitOfWork, IRepository<Category> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Category> GetByIdWithProducts(int categoryId)
        {
            var categoryWithProducts = await _unitOfWork.Categories.GetByIdWithProducts(categoryId);
            return categoryWithProducts;
        }
    }
}
