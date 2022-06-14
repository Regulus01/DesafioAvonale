using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PaymentsAPI.Data;
using PaymentsAPI.Model;
using ProductAPI.Data;
using ProductAPI.Models;
using ProductAPI.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly SqlServerContext _context;
        private IMapper _mapper;

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

        public async Task<PaymentsVO> BuyProduct(long id, int qtdComprada, Card card)
        {
            string payApi = "https://localhost:44340/api/product/payments/purchase";
            Product product = await _context.Products.Where(p => p.Id == id)
                      .FirstOrDefaultAsync();
            
            try
            {
                using (var client = new HttpClient())
                {
                    Payments payment = new Payments();
                    
                    if(product.QtdEtoque < 1)
                    {
                        throw new Exception("Sem estoque");
                    }

                    payment.Value = product.TotalValue(qtdComprada);
                        
                    
                    var jsonObject = JsonConvert.SerializeObject(payment);
                    var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");

                    var response = client.PostAsync(payApi, content);
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var returnPayment = response.Result.Content.ReadAsStringAsync();


                        var paymentCreated = JsonConvert.DeserializeObject<PaymentsVO>(returnPayment.Result);
                        

                        if (paymentCreated.Status == "APROVADO")
                        {
                            product.QtdEtoque -= qtdComprada;
                            await _context.SaveChangesAsync();
                      
                            return paymentCreated;
                        }
                        else

                        {
             
                            return paymentCreated;
                        }
                        
                    }
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro e o pagamento não foi realizado." + ex);
            }


            throw new Exception("Ocorreu um erro e o pagamento não foi realizado.");

        }

    }
}
