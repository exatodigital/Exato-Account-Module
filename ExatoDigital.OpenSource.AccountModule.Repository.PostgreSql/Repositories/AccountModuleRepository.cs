using ExatoDigital.OpenSource.AccountModule.Domain.Models;
using ExatoDigital.OpenSource.AccountModule.Domain.Parameters.AccountParameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Parameters.AccountTypeParameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Parameters.CurrencyParameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Parameters.UserBalanceParameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Response.AccountResult;
using ExatoDigital.OpenSource.AccountModule.Domain.Response.AccountTypeResult;
using ExatoDigital.OpenSource.AccountModule.Domain.Response.CurrencyResult;
using ExatoDigital.OpenSource.AccountModule.Domain.Response.UserBalanceResult;
using ExatoDigital.OpenSource.AccountModule.Domain.Enums;
using ExatoDigital.OpenSource.AccountModule.Repository.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ExatoDigital.OpenSource.AccountModule.Repository.PostgreSql.Repositories
{
    public sealed class AccountModuleRepository : IAccountModuleRepository
    {
        public AccountModuleRepository(AccountModuleDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public AccountModuleDbContext DbContext { get; }

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
            var account = await RetrieveAccount(parameters.AccountId, parameters.AccountExternalUid);
            if (account.Success)
            {
                var accountDeleted = DbContext.Account.FirstOrDefault(x => x.AccountId == account.Account.AccountId);
                if (accountDeleted != null)
                {
                    accountDeleted.DeletedAt = DateTime.UtcNow;
                    accountDeleted.DeletedBy = parameters.DeletedBy;
                }
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
            var accountType = await RetrieveAccountType(accountTypeParameters);
            if (accountType.Success)
            {
                var accountTypeDeleted = DbContext.AccountType.FirstOrDefault(x => accountType.AccountType != null && x.AccountTypeId == accountType.AccountType.AccountTypeId);
                if (accountTypeDeleted != null)
                {
                    accountTypeDeleted.DeletedAt = DateTime.UtcNow;
                    accountTypeDeleted.DeletedBy = parameters.DeletedBy;
                }

                await DbContext.SaveChangesAsync();
                return new DeleteAccountTypeResult() { Success = true };
            }
            else
                return new DeleteAccountTypeResult() { Success = false, ErrorMessage = "Falha ao deletar AccountType." };
        }
        public async Task<QueryAccountTypeResult> QueryAccountType(QueryAccountTypeParameters parameters)
        {
            var filteredAccountTypes = DbContext.AccountType.AsNoTracking().Where(currency =>
                    (parameters.AccountTypeId == null || currency.AccountTypeId == parameters.AccountTypeId) &&
                    (parameters.AccountTypeUid == null || currency.AccountTypeUid == parameters.AccountTypeUid) &&
                    (parameters.AccountTypeExternalUid == null ||
                     currency.AccountTypeExternalUid == parameters.AccountTypeExternalUid) &&
                    (parameters.AccountTypeClientId == null ||
                     currency.AccountTypeClientId == parameters.AccountTypeClientId) &&
                    (parameters.Name == null || currency.Name == parameters.Name) &&
                    (parameters.NegativeBalanceAllowed == null ||
                     currency.NegativeBalanceAllowed == parameters.NegativeBalanceAllowed) &&
                    (parameters.AllowedToExpire == null || currency.AllowedToExpire == parameters.AllowedToExpire) &&
                    (parameters.ExpireAt == null || currency.ExpireAt == parameters.ExpireAt) &&
                    (parameters.CreatedAt == null || currency.CreatedAt == parameters.CreatedAt) &&
                    (parameters.CreatedBy == null || currency.CreatedBy == parameters.CreatedBy) &&
                    (parameters.UpdatedAt == null || currency.UpdatedAt == parameters.UpdatedAt) &&
                    (parameters.UpdatedBy == null || currency.UpdatedBy == parameters.UpdatedBy) &&
                    (parameters.DeletedAt == null || currency.DeletedAt == parameters.DeletedAt) &&
                    (parameters.DeletedBy == null || currency.DeletedBy == parameters.DeletedBy)
                )
                .Select(accountType => new AccountType(
                    accountType.AccountTypeId,
                    accountType.AccountTypeUid,
                    accountType.AccountTypeExternalUid,
                    accountType.AccountTypeClientId,
                    accountType.Name,
                    accountType.NegativeBalanceAllowed,
                    accountType.AllowedToExpire,
                    accountType.ExpireAt,
                    accountType.CreatedAt,
                    accountType.CreatedBy,
                    accountType.UpdatedAt,
                    accountType.UpdatedBy,
                    accountType.DeletedAt,
                    accountType.DeletedBy
                )).ToList();

            if (filteredAccountTypes.Any() && filteredAccountTypes.Count > 0)
                return new QueryAccountTypeResult() {Success = true, AccountTypes = filteredAccountTypes };
            return new QueryAccountTypeResult() {Success = false, ErrorMessage = "Não foi encontrado nenhuma Currency com os paramêtros passados."};
        }
        public async Task<CreateCurrencyResult> CreateCurrency(CreateCurrencyParameters parameters)
        {
            var currency = new Currency(currencyUid: default, currencyExternalUid: default, currencyClientId: default,
                internalName: parameters.InternalName, longDisplayName: parameters.LongDisplayName,
                shortDisplayName: parameters.ShortDisplayName, description: parameters.Description,
                additionalMetadata: default, decimalPrecision: parameters.DecimalPrecision,
                minValue: parameters.MinValue, maxValue: parameters.MaxValue, symbol: parameters.Symbol,
                createdAt: default, createdBy: default, updatedAt: default, updatedBy: default, deletedAt: default,
                deletedBy: default);

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
            if (currency.Result.Success)
            {
                if (currency.Result.Currency == null) return new DeleteCurrencyResult() { Success = true };
                currency.Result.Currency.DeletedAt = DateTime.UtcNow;
                currency.Result.Currency.DeletedBy = parameters.DeletedBy;
                var updateCurrencyParameters = new UpdateCurrencyParameters(currency.Result.Currency);
                await UpdateCurrency(updateCurrencyParameters);

                return new DeleteCurrencyResult() { Success = true };
            }
            else
                return new DeleteCurrencyResult() { Success = false, ErrorMessage = "Erro ao criar Currency." };
        }
        public async Task<QueryCurrencyResult> QueryCurrency(QueryCurrencyParameters parameters)
        {
            var filteredCurrencies = DbContext.Currency.AsNoTracking().Where(currency =>
                    (parameters.CurrencyId == null || currency.CurrencyId == parameters.CurrencyId) &&
                    (parameters.CurrencyUid == null || currency.CurrencyUid == parameters.CurrencyUid) &&
                    (parameters.CurrencyExternalUid == null ||
                     currency.CurrencyExternalUid == parameters.CurrencyExternalUid) &&
                    (parameters.CurrencyClientId == null || currency.CurrencyClientId == parameters.CurrencyClientId) &&
                    (parameters.InternalName == null || currency.InternalName == parameters.InternalName) &&
                    (parameters.LongDisplayName == null || currency.LongDisplayName == parameters.LongDisplayName) &&
                    (parameters.ShortDisplayName == null || currency.ShortDisplayName == parameters.ShortDisplayName) &&
                    (parameters.Description == null || currency.Description == parameters.Description) &&
                    (parameters.AdditionalMetadata == null ||
                     currency.AdditionalMetadata == parameters.AdditionalMetadata) &&
                    (parameters.DecimalPrecision == null || currency.DecimalPrecision == parameters.DecimalPrecision) &&
                    (parameters.MinValue == null || currency.MinValue == parameters.MinValue) &&
                    (parameters.MaxValue == null || currency.MaxValue == parameters.MaxValue) &&
                    (parameters.Symbol == null || currency.Symbol == parameters.Symbol) &&
                    (parameters.CreatedAt == null || currency.CreatedAt == parameters.CreatedAt) &&
                    (parameters.CreatedBy == null || currency.CreatedBy == parameters.CreatedBy) &&
                    (parameters.UpdatedAt == null || currency.UpdatedAt == parameters.UpdatedAt) &&
                    (parameters.UpdatedBy == null || currency.UpdatedBy == parameters.UpdatedBy) &&
                    (parameters.DeletedBy == null || currency.DeletedBy == parameters.DeletedBy)
                )
                .Select(currency => new Currency(
                    currency.CurrencyUid,
                    currency.CurrencyExternalUid,
                    currency.CurrencyClientId,
                    currency.InternalName,
                    currency.LongDisplayName,
                    currency.ShortDisplayName,
                    currency.Description,
                    currency.AdditionalMetadata,
                    currency.DecimalPrecision,
                    currency.MinValue,
                    currency.MaxValue,
                    currency.Symbol,
                    currency.CreatedAt,
                    currency.CreatedBy,
                    currency.UpdatedAt,
                    currency.UpdatedBy,
                    currency.DeletedAt,
                    currency.DeletedBy
                )).ToList();

            if (filteredCurrencies.Any() && filteredCurrencies.Count > 0)
                return new QueryCurrencyResult() {Success = true, Currencies = filteredCurrencies };
            return new QueryCurrencyResult() {Success = false, ErrorMessage = "Não foi encontrado nenhuma Currency com os paramêtros passados."};
        }

        public async Task<BlockUserBalanceResult> BlockUserBalance(BlockUserBalanceParameters parameters)
        {
            var account = RetrieveAccount(parameters.AccountId, null);
            if (account.Result.Success)
            {
                var newBalance = account.Result.Account.CurrentBalance - parameters.Amount;
                var retrieveAccountTypeParameters = new RetrieveAccountTypeParameters(accountTypeId: account.Result.Account.AccountTypeId);
                var retrieveAccountTypeResult = RetrieveAccountType(retrieveAccountTypeParameters);
                if (retrieveAccountTypeResult.Result.AccountType is { NegativeBalanceAllowed: false } && newBalance < 0)
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
            var account = await RetrieveAccount(parameters.AccountId, null);
            if (account.Success)
                return new QueryBalanceResult() { Success = true, Balance = account.Account.CurrentBalance };
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
                    decimal accountOneBalance = accountOne.Result.Account.CurrentBalance;
                    decimal accountTwoBalance = accountTwo.Result.Account.CurrentBalance;
                    decimal accountOneNewBalance = accountOneBalance + accountTwoBalance;
                    CreateTransaction(accountOne.Result.Account.AccountId, accountOne.Result.Account.AccountExternalUid, accountTwo.Result.Account.AccountExternalUid,accountTwoBalance, TransactionType.Withdraw, accountOneBalance, accountOneNewBalance, null, null, null, null);
                    CreateTransaction(accountTwo.Result.Account.AccountId, accountOne.Result.Account.AccountExternalUid, accountTwo.Result.Account.AccountExternalUid,accountTwoBalance, TransactionType.Deposit, accountOneBalance, accountOneNewBalance, null, null, null, null);
                    accountOne.Result.Account.CurrentBalance = accountOneNewBalance;
                    accountOne.Result.Account.UpdatedAt = DateTime.UtcNow;
                    accountTwo.Result.Account.CurrentBalance = 0;
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

        public async Task<TransferBalanceResult> TransferBalance(TransferBalanceParameters parameters)
        {
            var senderAccount = RetrieveAccount(parameters.SenderAccountId, null);
            var receiverAccount = RetrieveAccount(parameters.ReceiverAccountId, null);
            if (ValidateIfTransactionIsPossible(senderAccount.Result.Account, senderAccount.Result.Account, parameters.Amount))
            {
                var receiverOldBalance = receiverAccount.Result.Account.CurrentBalance;
                var receiverNewBalance = receiverOldBalance + parameters.Amount;
                CreateTransaction(senderAccount.Result.Account.AccountId, senderAccount.Result.Account.AccountExternalUid, receiverAccount.Result.Account.AccountExternalUid, parameters.Amount, TransactionType.Withdraw, receiverOldBalance, receiverNewBalance, null, null, null, null);
                CreateTransaction(receiverAccount.Result.Account.AccountId, senderAccount.Result.Account.AccountExternalUid, receiverAccount.Result.Account.AccountExternalUid, parameters.Amount, TransactionType.Deposit, receiverOldBalance, receiverNewBalance, null, null, null, null);
                receiverAccount.Result.Account.CurrentBalance = receiverNewBalance;
                senderAccount.Result.Account.CurrentBalance -= parameters.Amount;
                await DbContext.SaveChangesAsync();
                return new TransferBalanceResult() { Success = true, ReceiverAccount = receiverAccount.Result.Account, SenderAccount = senderAccount.Result.Account };
            }
            else
                return new TransferBalanceResult() { Success = false, ErrorMessage = "Erro ao transferir saldo" };

        }

        private static bool AreValidForJoin(Account accountOne, Account accountTwo)
        {
            if (accountOne.BalanceBlocked > 0 || accountTwo.BalanceBlocked > 0)
                return false;
            if (accountOne.AccountTypeId != accountTwo.AccountTypeId)
                return false;
            if (accountOne.CurrencyId != accountTwo.CurrencyId)
                return false;
            if (accountOne.MasterAccountUid != accountTwo.MasterAccountUid)
                return false;
            return true;
        }

        private async void CreateTransaction(int accountId, Guid sourceAccountUid, Guid receiverAccountUid,
            decimal amount, TransactionType transactionType, decimal receiverOldBalance, decimal receiverNewBalance, string? internalName, string? longDisplayName, string? shortDisplayName, string? description)
        {
            Transaction transaction = new Transaction()
            {
                AccountId = accountId,
                InternalName = internalName,
                LongDisplayName = longDisplayName,
                ShortDisplayName = shortDisplayName,
                Description = description,
                Value = amount,
                TransactionType = transactionType,
                ReceiverAccountUid = receiverAccountUid,
                SourceAccountUid = sourceAccountUid,
                ReceiverOldBalance = receiverOldBalance,
                ReceiverNewBalance = receiverNewBalance,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = 1,
            };
            await DbContext.SaveChangesAsync();
        }

        private static bool ValidateIfTransactionIsPossible(Account sourceAccount, Account receiverAccount, decimal amount)
        {
            if (sourceAccount.AccountTypeId != receiverAccount.AccountTypeId)
                return false;
            if (sourceAccount.CurrencyId != receiverAccount.CurrencyId)
                return false;
            if (sourceAccount.CurrentBalance < amount && !sourceAccount.AccountType.NegativeBalanceAllowed)
                return false;
            return true;
        }

    }
}
