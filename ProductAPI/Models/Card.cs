using System.ComponentModel.DataAnnotations;

namespace ProductAPI.Models
{
    public class Card
    {
        public string Holder { get; set; }
        [CreditCard(ErrorMessage = "Cartão de crédito inválido")]
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string Flag { get; set; }
        public string cvv { get; set; }
    }
}
