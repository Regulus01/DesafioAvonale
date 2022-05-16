using Microsoft.AspNetCore.Mvc;
using ProductAPI.Data;
using ProductAPI.Repository;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ProductAPI.Controllers
{
    [Route("api/product")]
    [ApiController]
    public partial class ProductController : Controller
    {
        private IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentException(nameof(repository));
        }

        [HttpPost]
        public async Task<ActionResult<ProductVO>> Create([FromBody] ProductVO vo)
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
