using Xunit;
using PaymentsAPI.Model;

namespace PaymentsAPI.UnitTests
{
    public class PaymentsTest
    {
        [Theory(DisplayName = "Deve Aprovar o pagamento")]
        [InlineData(100.05)]
        [InlineData(150.05)]
        [InlineData(800.05)]
        public void ApprovePayment(double value)
        {
            Payments payments = new Payments();
            payments.Value = value;
            payments.ApprovePayment(payments.Value);
            Assert.Equal("APROVADO", payments.Status);
        }

        [Theory(DisplayName = "Deve Reprovar o pagamento")]
        [InlineData(30.05)]
        [InlineData(50.05)]
        [InlineData(99.99)]
        public void ReprovePayment(double value)
        {
            Payments payments = new Payments();
            payments.Value = value;
            payments.ApprovePayment(payments.Value);

            Assert.Equal("REJEITADO", payments.Status);
        }
    }
}