using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExatoDigital.OpenSource.AccountModule.Repository.Models;

namespace ExatoDigital.OpenSource.AccountModule.Repository.PostgreSql
{
    public sealed class AccountModuleDbContext : DbContext
    {
        private readonly String? _connectionString;

        public AccountModuleDbContext(DbContextOptions options) : base (options){}
        public AccountModuleDbContext(string connectionString) : base() { _connectionString = connectionString; }

        public AccountModuleDbContext(DbContextOptions<AccountModuleDbContext> options)
          : base(options)
        {

        }

        public DbSet<Account> Account { get; set; }
        // public DbSet<xxx> xxx { get; set; }
        // public DbSet<xxx> xxx { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
