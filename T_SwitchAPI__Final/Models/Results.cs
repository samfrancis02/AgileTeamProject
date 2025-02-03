namespace atmapp.Models
{
    public class AuthResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class TransactionResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class BalanceResult
    {
        public bool Success { get; set; }
        public decimal Balance { get; set; }
        public string Message { get; set; }
    }
}
