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
            _accountModuleDbContext.Account.Add(new Account
            {
                AccountId = 1,
                AccountUid = default,
                AccountExternalUid = default,
                AccountClientId = 1,
                MasterAccountUid = default,
                RelatedAccountUid = default,
                InternalName = parameters.InternalName,
                LongDisplayName = parameters.LongDisplayName,
                ShortDisplayName = parameters.ShortDisplayName,
                Description = parameters.Description,
                Metadata = "",
                Owner = parameters.Owner,
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
            //var resultado = _accountModuleDbContext.Account.Where(x => x.AccountId == 1).First();
            return new CreateAccountResult() { Success = true };
        }

        public async Task<CreateAccountTypeResult> CreateAccountType(CreateAccountTypeParameters parameters)
        {
            _accountModuleDbContext.AccountType.Add(new AccountType
            {
                AccountTypeId = 1,
                AccountTypeUid = default,
                AccountTypeExternalUid = default,
                AccountTypeClientId  = 1,
                Name = parameters.Name,
                NegativeBalanceAllowed  = default,
                AllowedToExpire  = default,
                ExpireAt = default,
                CreatedAt = default,
                CreatedBy = default,
                UpdatedAt = default,
                UpdatedBy = default,
                DeletedAt = default,
                DeletedBy = default
            });
            try
            {
                await _accountModuleDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            var resultado = _accountModuleDbContext.AccountType.Where(x => x.AccountTypeId == 1).First();
            return new CreateAccountTypeResult() { Success = true };
        }

        public async Task<BlockUserBalanceResult> BlockUserBalance(BlockUserBalanceParameters parameters)
        {
            return null;
        }
        public static void Clear() { }
    }
}
