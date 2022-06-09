using PaymentsAPI.Data;
using ProductAPI.Data;
using ProductAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductAPI.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductVO>> FindAll();
        Task<ProductVO> FindById(long id);
        Task<ProductVO> Create(ProductVO vo);
        Task<bool> Delete(long id);
        Task<PaymentsVO> BuyProduct(long id, int qtdComprada, Card card);
    }
}
