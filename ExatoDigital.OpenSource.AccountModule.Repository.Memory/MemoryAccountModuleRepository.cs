using ExatoDigital.OpenSource.AccountModule.Domain.Parameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Response;
using ExatoDigital.OpenSource.AccountModule.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExatoDigital.OpenSource.AccountModule.Repository.Models;
using ExatoDigital.OpenSource.AccountModule.Repository.PostgreSql;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ExatoDigital.OpenSource.AccountModule.Repository.Memory
{
    public sealed class MemoryAccountModuleRepository : IAccountModuleRepository
    {
        static DbContextOptions options = new DbContextOptionsBuilder<AccountModuleDbContext>()
            .UseInMemoryDatabase(databaseName: "AccountModuleDb").Options;
        private AccountModuleDbContext _accountModuleDbContext { get; set; } = new AccountModuleDbContext(options);
        
        public async Task<CreateAccountResult> CreateAccount(CreateAccountParameters parameters)
        {
            var result = _accountModuleDbContext.Account.Add(new Account
            {
                AccountId = 1,
                AccountUid = default,
                AccountExternalUid = default,
                AccountClientId = 0,
                MasterAccountUid = default,
                RelatedAccountUid = default,
                InternalName = "Teste",
                LongDisplayName = "",
                ShortDisplayName = "Teste",
                Description = "",
                Metadata = "",
                Owner = "",
                CurrentBalance = 0,
                CreatedAt = default,
                CreatedBy = 0,
                UpdatedAt = default,
                UpdatedBy = 0,
                DeletedAt = default,
                DeletedBy = 0,
                AccountType = null,
                Currency = null,
                Transactions = null
            });
            await _accountModuleDbContext.SaveChangesAsync();
            var resultado = _accountModuleDbContext.Account.Where(x => x.AccountId == 1).First();
            return new CreateAccountResult() { Success = true };
        }

        public async Task<BlockUserBalanceResult> BlockUserBalance(BlockUserBalanceParameters parameters)
        {
            return null;
        }
        public static void Clear() { }
    }
}
