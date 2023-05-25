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
            Account account = new Account()
            {
                AccountTypeId = parameters.AccountTypeId,
                CurrencyId = parameters.CurrencyId,
                AccountUid = Guid.NewGuid(),
                AccountExternalUid = Guid.NewGuid(),
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
            };

            DbContext.Account.Add(account);
            await DbContext.SaveChangesAsync();
            return new CreateAccountResult() { Success = true, Account = account };
        }
        public async Task<RetrieveAccountResult> RetrieveAccount(int? accountId, Guid? accountExternalUid)
        {
            IQueryable<Account> query = DbContext.Account;
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
        public async Task<UpdateAccountResult> UpdateAccount(UpdateAccountParameters parameters)
        {
            var account = DbContext.Account.FirstOrDefault(x => x.AccountId == parameters.AccountId);
            if (account != null)
            {
                account.AccountExternalUid = parameters.AccountExternalUid ?? account.AccountExternalUid;
                account.InternalName = parameters.InternalName ?? account.InternalName;
                account.LongDisplayName = parameters.LongDisplayName ?? account.LongDisplayName;
                account.ShortDisplayName = parameters.ShortDisplayName ?? account.ShortDisplayName;
                account.Description = parameters.Description ?? account.Description;
                account.Metadata = parameters.Metadata ?? account.Metadata;
            }
            await DbContext.SaveChangesAsync();
            return new UpdateAccountResult() { Success = true };
        }
        public async Task<DeleteAccountResult> DeleteAccount(DeleteAccountParameters parameters)
        {
            var account = RetrieveAccount(parameters.AccountId, parameters.AccountExternalUid);
            if (account.Result.Success == true)
            {
                var accountDeleted = DbContext.Account.Where(x => x.AccountId == account.Result.Account.AccountId).FirstOrDefault();
                accountDeleted.DeletedAt = DateTime.UtcNow;
                accountDeleted.DeletedBy = parameters.DeletedBy;
                await DbContext.SaveChangesAsync();
                return new DeleteAccountResult() { Success = true };
            }
            else
                return new DeleteAccountResult() { Success = false, ErrorMessage = "Falha ao deletar conta." };
        }
        public async Task<CreateAccountResult> QueryAccount(CreateAccountParameters parameters)
        {
            return new CreateAccountResult();
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

            DbContext.AccountType.Add(accountType);
            await DbContext.SaveChangesAsync();

            return new CreateAccountTypeResult() { Success = true, accountType = accountType };
        }
        public async Task<RetrieveAccountTypeResult> RetrieveAccountType(RetrieveAccountTypeParameters parameters)
        {
            IQueryable<AccountType> query = DbContext.AccountType;
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
                return new RetrieveAccountTypeResult() { Success = false, ErrorMessage = "Falha ao encontrar AccountType." };
        }
        public async Task<UpdateAccountTypeResult> UpdateAccountType(UpdateAccountTypeParameters parameters)
        {
            DbContext.Update(parameters.AccountType);
            await DbContext.SaveChangesAsync();
            return new UpdateAccountTypeResult() { Success = true };
        }
        public async Task<DeleteAccountTypeResult> DeleteAccountType(DeleteAccountTypeParameters parameters)
        {
            var accountTypeParameters = new RetrieveAccountTypeParameters(accountTypeId: parameters.AccountTypeId);
            var accountType = RetrieveAccountType(accountTypeParameters);
            if (accountType.Result.Success == true)
            {
                var accountTypeDeleted = DbContext.AccountType.Where(x => x.AccountTypeId == accountType.Result.AccountType.AccountTypeId).FirstOrDefault();
                accountTypeDeleted.DeletedAt = DateTime.UtcNow;
                accountTypeDeleted.DeletedBy = parameters.DeletedBy;
                await DbContext.SaveChangesAsync();
                return new DeleteAccountTypeResult() { Success = true };
            }
            else
                return new DeleteAccountTypeResult() { Success = false, ErrorMessage = "Falha ao deletar AccountType." };
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
            if (parameters.CurrencyId != null)
                query = query.AsQueryable().Where(c => c.CurrencyId == parameters.CurrencyId);
            if (parameters.CurrencyExternalUid != null)
                query = query.AsQueryable().Where(c => c.CurrencyExternalUid == parameters.CurrencyExternalUid);
            if (parameters.InternalName != null)
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
                return new DeleteCurrencyResult() { Success = false, ErrorMessage = "Erro ao criar Currency." };
        }
        public async Task<CreateCurrencyResult> QueryCurrency(CreateCurrencyParameters parameters)
        {
            return new CreateCurrencyResult();
        }

        public async Task<BlockUserBalanceResult> BlockUserBalance(BlockUserBalanceParameters parameters)
        {
            var account = RetrieveAccount(parameters.AccountId, null);
            if (account.Result.Success == true)
            {
                var newBalance = account.Result.Account.CurrentBalance - parameters.Amount;
                var retrieveAccountTypeParameters = new RetrieveAccountTypeParameters(accountTypeId: account.Result.Account.AccountTypeId);
                var retrieveAccountTypeResult = RetrieveAccountType(retrieveAccountTypeParameters);
                if (!retrieveAccountTypeResult.Result.AccountType.NegativeBalanceAllowed && newBalance < 0)
                    return new BlockUserBalanceResult() { Success = false, ErrorMessage = "Saldo insuficiente" };

                account.Result.Account.CurrentBalance = newBalance;
                account.Result.Account.BalanceBlocked = parameters.Amount;
                await DbContext.SaveChangesAsync();
                return new BlockUserBalanceResult() { Success = true };
            }
            else
                return new BlockUserBalanceResult() { Success = false, ErrorMessage = "Falha ao bloquear saldo do usuário." };
        }

        public async Task<UnblockUserBalanceResult> UnblockUserBalance(UnblockUserBalanceParameters parameters)
        {
            var account = RetrieveAccount(parameters.AccountId, null);
            if (account.Result.Success)
            {
                if (parameters.AmountToUnblock > account.Result.Account.BalanceBlocked)
                    return new UnblockUserBalanceResult() { Success = false, ErrorMessage = "Valor a ser desbloqueado é maior que o valor bloqueado" };
                var newBalance = account.Result.Account.CurrentBalance + parameters.AmountToUnblock;
                account.Result.Account.BalanceBlocked = account.Result.Account.BalanceBlocked - parameters.AmountToUnblock;
                account.Result.Account.CurrentBalance = newBalance;
                await DbContext.SaveChangesAsync();
                return new UnblockUserBalanceResult() { Success = true };
            }
            else
                return new UnblockUserBalanceResult() { Success = false };
        }
        public async Task<QueryBalanceResult> QueryBalance(QueryBalanceParameters parameters)
        {
            var account = RetrieveAccount(parameters.AccountId, null);
            if (account.Result.Success)
                return new QueryBalanceResult() { Success = true, Balance = account.Result.Account.CurrentBalance };
            else
                return new QueryBalanceResult() { Success = false, ErrorMessage = "Falha ao buscar saldo do usuário." };
        }
        public async Task<JoinChildrenAccountsResult> JoinChildrensAccounts(JoinChildrenAccountsParameters parameters)
        {
            var accountOne = RetrieveAccount(parameters.AccountOneId, null);
            var accountTwo = RetrieveAccount(parameters.AccountTwoId, null);
            if (accountOne.Result.Success && accountTwo.Result.Success)
            {
                if (AreValidForJoin(accountOne.Result.Account, accountTwo.Result.Account))
                {
                    CreateTransaction(accountOne.Result.Account, accountTwo.Result.Account, accountTwo.Result.Account.CurrentBalance, null, null, null, null);
                    accountOne.Result.Account.UpdatedAt = DateTime.UtcNow;
                    accountTwo.Result.Account.DeletedAt = DateTime.UtcNow;
                    await DbContext.SaveChangesAsync();
                    return new JoinChildrenAccountsResult() { Success = true };
                }
                else
                    return new JoinChildrenAccountsResult() { Success = false, ErrorMessage = "As contas não são válidas para serem unidas" };
            }
            else
                return new JoinChildrenAccountsResult() { Success = false, ErrorMessage = "Erro ao juntar contas" };
        }

        private static bool AreValidForJoin(Account accountOne, Account accountTwo)
        {
            if(accountOne.BalanceBlocked > 0 || accountTwo.BalanceBlocked > 0)
                return false;
            if (accountOne.AccountTypeId != accountTwo.AccountTypeId)
                return false;
            if (accountOne.CurrencyId != accountTwo.CurrencyId)
                return false;
            if (accountOne.MasterAccountUid != accountTwo.MasterAccountUid)
                return false;
            return true;
        }

        private void CreateTransaction(Account sourceAccount, Account receiverAccount,
            decimal amount, string? internalName, string? longDisplayName, string? shortDisplayName, string? description)
        {
            var balanceSourceAccountAfterTransaction = sourceAccount.CurrentBalance - amount;
            var balanceReceiverAccountAfterTransaction = receiverAccount.CurrentBalance + amount;
            sourceAccount.CurrentBalance = balanceSourceAccountAfterTransaction;
            receiverAccount.CurrentBalance = balanceReceiverAccountAfterTransaction;
            var transaction = new Transaction()
            {
                InternalName = internalName,
                LongDisplayName = longDisplayName,
                ShortDisplayName = shortDisplayName,
                Description = description,
                Value = amount,
                ReceiverAccountUid = receiverAccount.AccountUid,
                SourceAccountUid = sourceAccount.AccountUid,
                OldBalance = sourceAccount.CurrentBalance,
                NewBalance = balanceSourceAccountAfterTransaction,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = 1,
            };
            DbContext.SaveChanges();
        }

        public async Task<TransferBalanceResult> TransferBalance(TransferBalanceParameters parameters)
        {
            return null;
        }

    }
}
