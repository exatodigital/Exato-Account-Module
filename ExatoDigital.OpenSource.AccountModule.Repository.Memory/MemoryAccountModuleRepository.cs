using ExatoDigital.OpenSource.AccountModule.Domain.Parameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Response;
using ExatoDigital.OpenSource.AccountModule.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExatoDigital.OpenSource.AccountModule.Domain.Models;
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
                AccountTypeId = parameters.AccountTypeId,
                CurrencyId = parameters.CurrencyId,
                AccountUid = default,
                AccountExternalUid = default,
                AccountClientId = 1,
                MasterAccountUid = default,
                RelatedAccountUid = default,
                InternalName = parameters.InternalName,
                LongDisplayName = parameters.LongDisplayName,
                ShortDisplayName = parameters.ShortDisplayName,
                Description = parameters.Description,
                Metadata = null,
                Owner = parameters.Owner,
                CurrentBalance = 0,
                CreatedAt = default,
                CreatedBy = 0,
                UpdatedAt = default,
                UpdatedBy = 0,
                DeletedAt = default,
                DeletedBy = 0
            });
            await _accountModuleDbContext.SaveChangesAsync();
            var resultado = _accountModuleDbContext.Account.Where(x => x.AccountId == 1).Include(x => x.AccountType).Include(x => x.Currency).FirstOrDefault();
            return new CreateAccountResult() { Success = true };
        }

        public async Task<CreateAccountTypeResult> CreateAccountType(CreateAccountTypeParameters parameters)
        {
            var accountType = new AccountType
            {
                AccountTypeUid = default,
                AccountTypeExternalUid = default,
                AccountTypeClientId = 1,
                Name = parameters.Name,
                NegativeBalanceAllowed = default,
                AllowedToExpire = default,
                ExpireAt = default,
                CreatedAt = default,
                CreatedBy = default,
                UpdatedAt = default,
                UpdatedBy = default,
                DeletedAt = default,
                DeletedBy = default
            };

            _accountModuleDbContext.AccountType.Add(accountType);
            await _accountModuleDbContext.SaveChangesAsync();

            return new CreateAccountTypeResult() { Success = true, accountType = accountType };
        }

        public async Task<CreateCurrencyResult> CreateCurrency(CreateCurrencyParameters parameters)
        {
            var currency = new Currency
            {
                CurrencyUid = default,
                CurrencyExternalUid = default,
                CurrencyClientId = default,
                InternalName = parameters.InternalName,
                LongDisplayName = parameters.LongDisplayName,
                ShortDisplayName = parameters.ShortDisplayName,
                Description = parameters.Description,
                AdditionalMetadata = default,
                DecimalPrecision = parameters.DecimalPrecision,
                MinValue= parameters.MinValue,
                MaxValue = parameters.MaxValue,
                Symbol = parameters.Symbol,
                CreatedAt = default,
                CreatedBy = default,
                UpdatedAt = default,
                UpdatedBy = default,
                DeletedAt = default,
                DeletedBy = default
            };

            _accountModuleDbContext.Currency.Add(currency);
            await _accountModuleDbContext.SaveChangesAsync();

            return new CreateCurrencyResult() { Success = true, currency = currency};
        }
        public async Task<BlockUserBalanceResult> BlockUserBalance(BlockUserBalanceParameters parameters)
        {
            return null;
        }
        public static void Clear() {}
    }
}
