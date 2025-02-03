namespace atmapp.Models
{
    public class TransactionResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public decimal Balance { get; set; } = 0;  // Include this if it's relevant, such as for balance inquiries.
    }
}
