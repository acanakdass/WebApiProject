using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiProject.Core.Repositories;

namespace WebApiProject.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        Task SaveChangesAsync();
        void SaveChanges();
    }
}
