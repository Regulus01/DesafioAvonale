using Microsoft.AspNetCore.Mvc;
using PaymentsAPI.Data;
using PaymentsAPI.Repository;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace PaymentsAPI.Controllers
{
    [Route("api/product/payments/purchase")]
    [ApiController]
    public class PaymentsController : Controller
    {
        private IPaymentsRepository _repository;

        public PaymentsController(IPaymentsRepository repository)
        {
            _repository = repository ?? throw new ArgumentException(nameof(repository));
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create Payment")]
        public async Task<ActionResult<PaymentsVO>> Create([FromBody] PaymentsVO vo)
        {
            if (vo == null)
            {
                return BadRequest();
            }

            try
            {
                var product = await _repository.Create(vo);
                return Ok(product);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
