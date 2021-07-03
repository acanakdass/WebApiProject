using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiProject.Core.Entities;

namespace WebApiProject.Core.Repositories
{
    public interface ICategoryRepository :IRepository<Category>
    {
        /// <summary>
        /// Parametre olarak verilen id bilgisine sahip kategoriyi ve kategoriye ait ürünleri getirir.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns>Category nesnesi döndürülür.</returns>
        Task<Category> GetByIdWithProducts(int categoryId);
    }
}
