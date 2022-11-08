using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExatoDigital.OpenSource.AccountModule.Repository.PostgreSql
{
    public sealed class AccountModuleDbContext : DbContext
    {
        public AccountModuleDbContext(DbContextOptions<AccountModuleDbContext> options)
          : base(options)
        {

        }

        // public DbSet<xxx> xxx { get; set; }
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
