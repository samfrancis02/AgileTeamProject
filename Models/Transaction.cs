namespace atmapp.Models
{
    public class Transaction
    {
        public int Id { get; set; } // Primary Key
        public string CardNumber { get; set; } // The card used for the transaction
        public string TransactionType { get; set; } // e.g., Withdrawal, Balance Inquiry
        public double Amount { get; set; } // Transaction amount
        public DateTime Timestamp { get; set; } // Date and time of the transaction
        public string Status { get; set; } // Success or Failed
    }
}
