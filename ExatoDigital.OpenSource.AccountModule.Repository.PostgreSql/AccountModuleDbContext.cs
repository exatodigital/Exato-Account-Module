using ExatoDigital.OpenSource.AccountModule.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ExatoDigital.OpenSource.AccountModule.Repository.PostgreSql
{
    public sealed class AccountModuleDbContext : DbContext
    {
        private readonly string? _connectionString;

        public AccountModuleDbContext(DbContextOptions options) : base (options){}
        public AccountModuleDbContext(string connectionString) : base() { _connectionString = connectionString; }

        public AccountModuleDbContext(DbContextOptions<AccountModuleDbContext> options)
          : base(options)
        {

        }
        public DbSet<Account> Account { get; set; }
        public DbSet<AccountType> AccountType { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<RealCurrency> RealCurrency { get; set; }
        public DbSet<Transaction> Transaction { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseIdentityColumns();

            modelBuilder.Entity<Account>()
                .HasOne(a => a.AccountType)
                .WithMany(at => at.Accounts)
                .HasForeignKey(a => a.AccountTypeId);

            modelBuilder.Entity<Account>()
                .HasOne(a => a.Currency)
                .WithMany(at => at.Accounts)
                .HasForeignKey(a => a.CurrencyId);

            modelBuilder.Entity<Account>()
               .HasMany(a => a.Transactions)
               .WithOne(at => at.Account)
               .HasForeignKey(a => a.AccountId);

            modelBuilder.Entity<Currency>()
              .HasOne(a => a.RealCurrency);

        }
    }
}
