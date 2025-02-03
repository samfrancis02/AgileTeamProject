namespace atmapp.Models
{
    public class Transaction
    {
        public int Id { get; set; } // Primary key
        public string CardNumber { get; set; } // Foreign key linking to VisaCards or MasterCards
        public string TransactionType { get; set; } // Withdrawal, Balance Inquiry, etc.
        public double Amount { get; set; } = 0.0; // Match FLOAT in DB
        public DateTime Timestamp { get; set; } = DateTime.Now; // Ensure default matches database behavior
        public string Status { get; set; } // Success, Declined, etc.
    }
}
