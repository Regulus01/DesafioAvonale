using PaymentsAPI.Data;
using System.Threading.Tasks;

namespace PaymentsAPI.Repository
{
    public interface IPaymentsRepository
    {
        Task<PaymentsVO> Create (PaymentsVO vo);
    }
}
