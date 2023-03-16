﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExatoDigital.OpenSource.AccountModule.Domain.Models;

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
        public DbSet<AccountType> AccountType { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<RealCurrency> RealCurrency { get; set; }
        public DbSet<Transaction> Transaction { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
