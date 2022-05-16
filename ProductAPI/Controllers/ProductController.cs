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

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var status = await _repository.Delete(id);
            if (!status)
            {
                return BadRequest();
            }
            return Ok(status);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindByAll()
        {
            var products = await _repository.FindAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> FindById(long id)
        {
            var product = await _repository.FindById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }





    }
}
