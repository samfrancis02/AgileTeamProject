namespace atmapp.Models
{
    public class ATMInventory
    {
        public int Id { get; set; } // Primary key
        public int ATMId { get; set; } // Unique identifier for the ATM
        public int FiftyDenomination { get; set; } // Count of $50 notes
        public int TwentyDenomination { get; set; } // Count of $20 notes
        public int TenDenomination { get; set; } // Count of $10 notes

        // Check if the ATM can dispense the requested amount
        public bool CanDispenseAmount(double amount)
        {
            int remainingAmount = (int)amount;

            // Deduct amounts using available denominations
            int fiftyNeeded = Math.Min(FiftyDenomination, remainingAmount / 50);
            remainingAmount -= fiftyNeeded * 50;

            int twentyNeeded = Math.Min(TwentyDenomination, remainingAmount / 20);
            remainingAmount -= twentyNeeded * 20;

            int tenNeeded = Math.Min(TenDenomination, remainingAmount / 10);
            remainingAmount -= tenNeeded * 10;

            return remainingAmount == 0; // True if the amount can be dispensed
        }

        // Dispense the requested amount and update the inventory
        public void DispenseAmount(double amount)
        {
            int remainingAmount = (int)amount;

            int fiftyNeeded = Math.Min(FiftyDenomination, remainingAmount / 50);
            FiftyDenomination -= fiftyNeeded;
            remainingAmount -= fiftyNeeded * 50;

            int twentyNeeded = Math.Min(TwentyDenomination, remainingAmount / 20);
            TwentyDenomination -= twentyNeeded;
            remainingAmount -= twentyNeeded * 20;

            int tenNeeded = Math.Min(TenDenomination, remainingAmount / 10);
            TenDenomination -= tenNeeded;
        }
    }
}
