using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PaymentsAPI.Controllers;
using PaymentsAPI.Data;
using PaymentsAPI.Repository;
using ProductAPI.Data;
using ProductAPI.Models;
using ProductAPI.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly SqlServerContext _context;
        private IMapper _mapper;
        private readonly IPaymentsRepository _repository;

        public ProductRepository(SqlServerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<ProductVO> Create(ProductVO vo)
        {
            Product product = _mapper.Map<Product>(vo);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVO>(product);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                Product product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
                if (product == null)
                {
                    return false;
                }
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ProductVO>> FindAll()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductVO>>(products);
        }

        public async Task<ProductVO> FindById(long id)
        {
            Product product = await _context.Products.Where(p => p.Id == id)
                              .FirstOrDefaultAsync();
            return _mapper.Map<ProductVO>(product);
        }

        public async Task<ProductVO> BuyProduct(long id, int qtdComprada, Card card)
        {


            Product product = await _context.Products.Where(p => p.Id == id)
                             .FirstOrDefaultAsync();

            PaymentsVO paymentsVO = new PaymentsVO();
            paymentsVO.Value = product.UnitaryValue;

            PaymentsController task = new PaymentsController(_repository);
            var response = await task.Create(paymentsVO);


            product.QtdEtoque -= qtdComprada;
            await _context.SaveChangesAsync();


            return _mapper.Map<ProductVO>(product);
        }

    }
}
