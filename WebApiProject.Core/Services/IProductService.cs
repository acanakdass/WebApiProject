using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiProject.Core.Entities;

namespace WebApiProject.Core.Services
{
    public interface IProductService:IService<Product>
    {
        /// <summary>
        /// Parametre olarak verilen id bilgisine sahip product nesnesini ve içerisinde bu nesneye ait kategorileri getirir.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns>Product nesnesi döndürülür</returns>
        Task<Product> GetByIdWithCategories(int productId);
    }
}
