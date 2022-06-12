namespace PaymentsAPI.Data
{
    public class PaymentsVO
    {
        public double Value { get; set; }
        public string Status { get; private set; }

        public void ApprovePayment(double value)
        {
            if (value >= 100)
            {
                Status = "APROVADO";
            }
            else
            {
                Status = "REJEITADO";
            }
        }
    }
}
