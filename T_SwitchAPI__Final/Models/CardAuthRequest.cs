using System.ComponentModel.DataAnnotations;

namespace atmapp.Models
{
    public class CardAuthRequest
    {
        [Required(ErrorMessage = "CardNumber is required")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "CardNumber must be 16 digits")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "PIN is required")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "PIN must be 4 digits")]
        public string PIN { get; set; }


    }
}
