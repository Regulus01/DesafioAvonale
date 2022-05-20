using AutoMapper;
using PaymentsAPI.Data;
using PaymentsAPI.Model;
using PaymentsAPI.Model.Context;
using System.Threading.Tasks;

namespace PaymentsAPI.Repository
{
    public class PaymentsRepository : IPaymentsRepository
    {
        private readonly SqlServerContext _context;
        private IMapper _mapper;

        public PaymentsRepository(SqlServerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaymentsVO> Create(PaymentsVO vo)
        {
            Payments payments = _mapper.Map<Payments>(vo);
            _context.Payments.Add(payments);
            await _context.SaveChangesAsync();
            return _mapper.Map<PaymentsVO>(payments);
        }
    }
}
