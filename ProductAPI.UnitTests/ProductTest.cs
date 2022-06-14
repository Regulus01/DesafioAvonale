using ProductAPI.Models;
using Xunit;

namespace ProductAPI.UnitTests
{
    public class ProductTest
    {
        [Theory(DisplayName = "Deve calcular o valor total do produto")]
        [InlineData(100)]
        [InlineData(150)]
        [InlineData(800)]
        public void TotalValueProduct(int qtd)
        {
            Product product = new Product();
            product.Id = 1;
            product.Name = "TestProduct";
            product.UnitaryValue = 100;

            double expected = 100 * qtd;

            Assert.Equal(expected, product.TotalValue(qtd));
          
        }
    }
}
