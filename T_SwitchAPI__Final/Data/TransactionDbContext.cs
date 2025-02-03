using Microsoft.EntityFrameworkCore;
using atmapp.Models;

namespace atmapp.Data
{
    public class TransactionDbContext : DbContext
    {
        public TransactionDbContext(DbContextOptions<TransactionDbContext> options) : base(options) { }

        public DbSet<VisaCard> VisaCards { get; set; }
        public DbSet<MasterCard> MasterCards { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<ATMInventory> ATMInventories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure VisaCard entity
            modelBuilder.Entity<VisaCard>()
                .ToTable("VisaCards")
                .HasKey(v => v.CardNumber); // Primary key

            modelBuilder.Entity<VisaCard>()
                .Property(v => v.Balance)
                .HasDefaultValue(0); // Default value for Balance

            modelBuilder.Entity<VisaCard>()
                .Property(v => v.TransactionLimit)
                .HasDefaultValue(1000); // Default value for TransactionLimit

            modelBuilder.Entity<VisaCard>()
                .Property(v => v.DailyLimit)
                .HasDefaultValue(5000); // Default value for DailyLimit

            modelBuilder.Entity<VisaCard>()
                .Property(v => v.DailyWithdrawn)
                .HasDefaultValue(0); // Default value for DailyWithdrawn

            modelBuilder.Entity<VisaCard>()
                .Property(v => v.FailedAttempts)
                .HasDefaultValue(0); // Default value for FailedAttempts

            // Configure MasterCard entity
            modelBuilder.Entity<MasterCard>()
                .ToTable("MasterCards")
                .HasKey(m => m.CardNumber); // Primary key

            modelBuilder.Entity<MasterCard>()
                .Property(m => m.Balance)
                .HasDefaultValue(0); // Default value for Balance

            modelBuilder.Entity<MasterCard>()
                .Property(m => m.TransactionLimit)
                .HasDefaultValue(1500); // Default value for TransactionLimit

            modelBuilder.Entity<MasterCard>()
                .Property(m => m.DailyLimit)
                .HasDefaultValue(6000); // Default value for DailyLimit

            modelBuilder.Entity<MasterCard>()
                .Property(m => m.DailyWithdrawn)
                .HasDefaultValue(0); // Default value for DailyWithdrawn

            modelBuilder.Entity<MasterCard>()
                .Property(m => m.FailedAttempts)
                .HasDefaultValue(0); // Default value for FailedAttempts

            // Configure Transaction entity
            modelBuilder.Entity<Transaction>()
                .ToTable("Transactions")
                .HasKey(t => t.Id); // Primary key

            // Configure ATMInventory entity
            modelBuilder.Entity<ATMInventory>()
                .ToTable("ATMInventories")
                .HasKey(i => i.Id); // Primary key

            modelBuilder.Entity<ATMInventory>()
                .Property(i => i.FiftyDenomination)
                .HasDefaultValue(0); // Default value for FiftyDenomination

            modelBuilder.Entity<ATMInventory>()
                .Property(i => i.TwentyDenomination)
                .HasDefaultValue(0); // Default value for TwentyDenomination

            modelBuilder.Entity<ATMInventory>()
                .Property(i => i.TenDenomination)
                .HasDefaultValue(0); // Default value for TenDenomination

            // Seed sample data for ATMInventory (optional)
            modelBuilder.Entity<ATMInventory>().HasData(
                new ATMInventory
                {
                    Id = 1,
                    ATMId = 1,
                    FiftyDenomination = 10,
                    TwentyDenomination = 20,
                    TenDenomination = 30
                }
            );
        }
    }
}
