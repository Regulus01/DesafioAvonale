using ProductAPI.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductAPI.Models
{
    public class Product : BaseEntity
    {
        [Required]
        [Column("Name")]
        [StringLength(150)]
        public string Name { get; set; }

        [Column("Value")]
        [Required]
        [Range(1, 1000)]
        public double UnitaryValue { get; set; }

        [Column("Estoque")]
        [Required]
        public int QtdEtoque { get; set; }
    }
}
