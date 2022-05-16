using ProductAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductAPI.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> FindAll();
        Task<IEnumerable<Product>> FindById();
        Task<IEnumerable<Product>> Create(Product name);
        Task<IEnumerable<Product>> Update(Product name);
        Task<bool> Delete(long name);
    }
}
