namespace atmapp.Models
{
    public class CardBase
    {
        public string CardNumber { get; set; } // Primary Key
        public string CardHolderName { get; set; }
        public string ExpirationDate { get; set; }
        public string HashedPIN { get; set; }
        public decimal? Balance { get; set; }
        public int FailedAttempts { get; set; } = 0;
        public DateTime? LockoutUntil { get; set; }

        // ✅ Added missing properties
        public decimal TransactionLimit { get; set; }
        public decimal DailyLimit { get; set; }
        public decimal DailyWithdrawn { get; set; } = 0;
    }
}
