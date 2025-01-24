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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure primary key for VisaCard
            modelBuilder.Entity<VisaCard>()
                .HasKey(v => v.CardNumber);

            // Configure primary key for MasterCard
            modelBuilder.Entity<MasterCard>()
                .HasKey(m => m.CardNumber);


            modelBuilder.Entity<VisaCard>().ToTable("VisaCards");
            modelBuilder.Entity<MasterCard>().ToTable("MasterCards");



            // for transaction

            modelBuilder.Entity<Transaction>().ToTable("Transactions");
            modelBuilder.Entity<Transaction>().HasKey(t => t.Id); // Primary Key
        }

    }
}
