namespace atmapp.Models
{
    public class VisaCard : CardBase
    {
        public string CardNumber { get; set; } // Primary key
        public string CardHolderName { get; set; }
        public string ExpirationDate { get; set; }
        public string HashedPIN { get; set; }
        public double Balance { get; set; } = 0.0; // Match FLOAT in DB
        public int FailedAttempts { get; set; } = 0; // For rate-limiting
        public DateTime? LockoutUntil { get; set; } // For temporary lockout

        // Limits
        public double TransactionLimit { get; set; } = 1000.0; // Default per transaction
        public double DailyLimit { get; set; } = 5000.0; // Default daily limit
        public double DailyWithdrawn { get; set; } = 0.0; // Tracks daily withdrawals
    }
}
