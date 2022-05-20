using PaymentsAPI.Model.Enums;

namespace PaymentsAPI.Data
{
    public class PaymentsVO
    {
        public double Value { get; set; }
        public OrderStatus Status { get; set; }
    }
}
