using PaymentsAPI.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentsAPI.Model
{
    public class Payments : BaseEntity
    {
        [Required]
        [Column("Value")]
        public double Value { get; set; }
        [Column("Status")]
        [Range(1, 8)]
        public string Status {get; private set; }


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
