using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApiProject.Core.Entities;
using WebApiProject.Core.Repositories;
using WebApiProject.Core.Services;
using WebApiProject.Core.UnitOfWork;

namespace WebApiProject.Service.Services
{
    public class ProductManager : BaseManager<Product>, IProductService
    {
        public ProductManager(IUnitOfWork unitOfWork, IRepository<Product> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Product> GetByIdWithCategories(int productId)
        {
            var productWithCategories = await _unitOfWork.Products.GetByIdWithCategories(productId);
            return productWithCategories;
        }
    }
}
