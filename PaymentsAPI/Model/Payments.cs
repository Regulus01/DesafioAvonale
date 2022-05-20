using PaymentsAPI.Model.Base;
using PaymentsAPI.Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentsAPI.Model
{
    public class Payments : BaseEntity
    {
        [Required]
        [Column("Value")]
        public double Value { get; set; }
        [Required]
        [Column("Status")]
        [Range(1, 8)]
        public OrderStatus Status {get; set; }
    }
}
