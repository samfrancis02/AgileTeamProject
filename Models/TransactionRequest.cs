using System.ComponentModel.DataAnnotations;

namespace atmapp.Models
{
    public class TransactionRequest
    {
        [Required(ErrorMessage = "TransactionType is required")]
        public string TransactionType { get; set; }

        [Range(1, 10000, ErrorMessage = "Amount must be between 1 and 10000")]
        public double Amount { get; set; }

        [Required(ErrorMessage = "CardNumber is required")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "CardNumber must be 16 digits")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "AtmId is required")]
        public string AtmId { get; set; }

        public string TransactionId { get; set; }
    }
}
