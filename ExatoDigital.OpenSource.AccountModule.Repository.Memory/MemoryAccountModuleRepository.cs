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
using ExatoDigital.OpenSource.AccountModule.Domain.Parameters.CurrencyParameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Response.CurrencyResult;
using ExatoDigital.OpenSource.AccountModule.Domain.Parameters.AccountParameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Parameters.AccountTypeParameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Parameters.UserBalanceParameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Response.AccountTypeResult;
using ExatoDigital.OpenSource.AccountModule.Domain.Response.AccountResult;
using ExatoDigital.OpenSource.AccountModule.Domain.Response.UserBalanceResult;

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
            var account = _accountModuleDbContext.Account.Where(x => x.AccountId == 1).Include(x => x.AccountType).Include(x => x.Currency).FirstOrDefault();
            return new CreateAccountResult() { Success = true, Account = account };
        }

        public async Task<RetrieveAccountResult> RetrieveAccount(int? accountId, Guid? accountExternalUid)
        {
            IQueryable<Account> query = _accountModuleDbContext.Account;
            if (accountId != null)
                query = query.AsQueryable().Where(c => c.AccountId == accountId);
            if (accountExternalUid != null)
                query = query.AsQueryable().Where(c => c.AccountExternalUid == accountExternalUid);

            var result = await query.AsNoTracking().FirstOrDefaultAsync();
            if (result != null)
                return new RetrieveAccountResult() { Account = result, Success = true };
            else
                return new RetrieveAccountResult() { Account = null, Success = false };
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
        public async Task<RetrieveAccountTypeResult> RetrieveAccountType(RetrieveAccountTypeParameters parameters)
        {
            IQueryable<AccountType> query = _accountModuleDbContext.AccountType;
            if (parameters.AccountTypeId != null)
                query = query.AsQueryable().Where(c => c.AccountTypeId == parameters.AccountTypeId);
            if (parameters.AccountTypeExternalUid != null)
                query = query.AsQueryable().Where(c => c.AccountTypeExternalUid == parameters.AccountTypeExternalUid);
            if (parameters.Name != null)
                query = query.AsQueryable().Where(c => c.Name == parameters.Name);

            var result = await query.AsNoTracking().FirstOrDefaultAsync();
            if (result != null) 
                return new RetrieveAccountTypeResult() { AccountType = result, Success = true };
            else
                return new RetrieveAccountTypeResult() { AccountType = null, Success = false };
        }
        public async Task<UpdateAccountTypeResult> UpdateAccountType(UpdateAccountTypeParameters parameters)
        {
            _accountModuleDbContext.Update(parameters.AccountType);
            await _accountModuleDbContext.SaveChangesAsync();
            return new UpdateAccountTypeResult() { Success = true };
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
        public async Task<RetrieveCurrencyResult> RetrieveCurrency(RetrieveCurrencyParameters parameters)
        {
            IQueryable<Currency> query = _accountModuleDbContext.Currency;
            if (parameters.CurrencyId != null)
                query = query.AsQueryable().Where(c => c.CurrencyId == parameters.CurrencyId);
            if (parameters.CurrencyExternalUid != null)
                query = query.AsQueryable().Where(c => c.CurrencyExternalUid == parameters.CurrencyExternalUid);
            if (parameters.InternalName != null)
                query = query.AsQueryable().Where(c => c.InternalName == parameters.InternalName);

            var result = await query.AsNoTracking().FirstOrDefaultAsync();
            if (result != null)
                return new RetrieveCurrencyResult() { Currency = result, Success = true };
            else
                return new RetrieveCurrencyResult() { Currency = result, Success = false };
        }
        public async Task<UpdateCurrencyResult> UpdateCurrency(UpdateCurrencyParameters parameters)
        {
            _accountModuleDbContext.Update(parameters.Currency);
            await _accountModuleDbContext.SaveChangesAsync();

            return new UpdateCurrencyResult() { Success = true };
        }

        public async Task<DeleteCurrencyResult> DeleteCurrency(DeleteCurrencyParameters parameters)
        {
            var retrieveCurrencyParameters = new RetrieveCurrencyParameters(currencyId: parameters.CurrencyId);
            var currency = RetrieveCurrency(retrieveCurrencyParameters);
            if (currency.Result.Success == true)
            {
                currency.Result.Currency.DeletedAt = DateTime.UtcNow;
                currency.Result.Currency.DeletedBy = parameters.DeletedBy;
                var updateCurrencyParameters = new UpdateCurrencyParameters(currency.Result.Currency);
                await UpdateCurrency(updateCurrencyParameters);
                return new DeleteCurrencyResult() { Success = true };
            }
            else
                return new DeleteCurrencyResult() { Success = false };
        }

        public async Task<BlockUserBalanceResult> BlockUserBalance(BlockUserBalanceParameters parameters)
        {
            return null;
        }

        public static void Clear() {}
    }
}
