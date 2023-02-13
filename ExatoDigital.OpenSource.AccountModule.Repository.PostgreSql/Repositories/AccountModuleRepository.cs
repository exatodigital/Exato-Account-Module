using ExatoDigital.OpenSource.AccountModule.Domain.Models;
using ExatoDigital.OpenSource.AccountModule.Domain.Parameters.AccountParameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Parameters.AccountTypeParameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Parameters.CurrencyParameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Parameters.UserBalanceParameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Response.AccountResult;
using ExatoDigital.OpenSource.AccountModule.Domain.Response.AccountTypeResult;
using ExatoDigital.OpenSource.AccountModule.Domain.Response.CurrencyResult;
using ExatoDigital.OpenSource.AccountModule.Domain.Response.UserBalanceResult;
using ExatoDigital.OpenSource.AccountModule.Repository.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ExatoDigital.OpenSource.AccountModule.Repository.PostgreSql.Repositories
{
    public sealed class AccountModuleRepository : IAccountModuleRepository
    {
        private readonly AccountModuleDbContext _dbContext;
        public AccountModuleRepository(AccountModuleDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public AccountModuleDbContext DbContext => _dbContext;

        public async Task<CreateAccountResult> CreateAccount(CreateAccountParameters parameters)
        {
            DbContext.Account.Add(new Account
            {
                AccountTypeId = parameters.AccountTypeId,
                CurrencyId = parameters.CurrencyId,
                AccountUid = default,
                AccountExternalUid = default,
                AccountClientId = null,
                MasterAccountUid = parameters.MasterAccountUid,
                RelatedAccountUid = parameters.MasterAccountUid,
                InternalName = parameters.InternalName,
                LongDisplayName = parameters.LongDisplayName,
                ShortDisplayName = parameters.ShortDisplayName,
                Description = parameters.Description,
                Metadata = null,
                Owner = parameters.Owner,
                CurrentBalance = parameters.Balance,
                CreatedAt = DateTime.Now,
                CreatedBy = null,
                UpdatedAt = null,
                UpdatedBy = null,
                DeletedAt = null,
                DeletedBy = null
            });
            await DbContext.SaveChangesAsync();
            var account = DbContext.Account.Where(x => x.AccountId == 1).Include(x => x.AccountType).Include(x => x.Currency).FirstOrDefault();
            return new CreateAccountResult() { Success = true, Account = account };
        }
        public async Task<CreateAccountResult> RetrieveAccount(CreateAccountParameters parameters)
        {
            return new CreateAccountResult();
        }
        public async Task<CreateAccountResult> UpdateAccount(CreateAccountParameters parameters)
        {
            return new CreateAccountResult();
        }
        public async Task<CreateAccountResult> DeleteAccount(CreateAccountParameters parameters)
        {
            return new CreateAccountResult();
        }
        public async Task<CreateAccountResult> QueryAccount(CreateAccountParameters parameters)
        {
            return new CreateAccountResult();
        }
        public async Task<CreateAccountTypeResult> CreateAccountType(CreateAccountTypeParameters parameters)
        {
            return new CreateAccountTypeResult();
        }
        public async Task<CreateAccountTypeResult> RetrieveAccountType(CreateAccountTypeParameters parameters)
        {
            return new CreateAccountTypeResult();
        }
        public async Task<CreateAccountTypeResult> UpdateAccountType(CreateAccountTypeParameters parameters)
        {
            return new CreateAccountTypeResult();
        }
        public async Task<CreateAccountTypeResult> DeleteAccountType(CreateAccountTypeParameters parameters)
        {
            return new CreateAccountTypeResult();
        }
        public async Task<CreateAccountTypeResult> QueryAccountType(CreateAccountTypeParameters parameters)
        {
            return new CreateAccountTypeResult();
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
                MinValue = parameters.MinValue,
                MaxValue = parameters.MaxValue,
                Symbol = parameters.Symbol,
                CreatedAt = default,
                CreatedBy = default,
                UpdatedAt = default,
                UpdatedBy = default,
                DeletedAt = default,
                DeletedBy = default
            };

            DbContext.Currency.Add(currency);
            await DbContext.SaveChangesAsync();

            return new CreateCurrencyResult() { Success = true, currency = currency };
        }
        public async Task<RetrieveCurrencyResult> RetrieveCurrency(RetrieveCurrencyParameters parameters)
        {
            IQueryable<Currency> query = DbContext.Currency;
            if(parameters.CurrencyId != null)
                query = query.AsQueryable().Where(c => c.CurrencyId == parameters.CurrencyId);
            if(parameters.CurrencyExternalUid != null)
                query = query.AsQueryable().Where(c => c.CurrencyExternalUid == parameters.CurrencyExternalUid);
            if(parameters.InternalName!= null)
                query = query.AsQueryable().Where(c => c.InternalName == parameters.InternalName);

            var result = await query.AsNoTracking().FirstOrDefaultAsync();

            return new RetrieveCurrencyResult() { Currency = result };
        }
        public async Task<UpdateCurrencyResult> UpdateCurrency(UpdateCurrencyParameters parameters)
        {
            DbContext.Update(parameters.Currency);
            await DbContext.SaveChangesAsync();

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
        public async Task<CreateCurrencyResult> QueryCurrency(CreateCurrencyParameters parameters)
        {
            return new CreateCurrencyResult();
        }

        public async Task<BlockUserBalanceResult> BlockUserBalance(BlockUserBalanceParameters parameters)
        {
            return new BlockUserBalanceResult();
        }
    }
}
