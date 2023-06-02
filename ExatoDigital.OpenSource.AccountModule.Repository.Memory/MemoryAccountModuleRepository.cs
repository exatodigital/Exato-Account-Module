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
using ExatoDigital.OpenSource.AccountModule.Domain.Enums;

namespace ExatoDigital.OpenSource.AccountModule.Repository.Memory
{
    public sealed class MemoryAccountModuleRepository : IAccountModuleRepository
    {
        static DbContextOptions options = new DbContextOptionsBuilder<AccountModuleDbContext>()
            .UseInMemoryDatabase(databaseName: "AccountModuleDb").Options;
        private AccountModuleDbContext _accountModuleDbContext { get; set; } = new AccountModuleDbContext(options);
        
        public async Task<CreateAccountResult> CreateAccount(CreateAccountParameters parameters)
        {
            var retrieveAccountTypeParameters = new RetrieveAccountTypeParameters(parameters.AccountTypeId);
            var retrieveAccountType = await RetrieveAccountType(retrieveAccountTypeParameters);
            var retrieveCurrencyParameters = new RetrieveCurrencyParameters(parameters.CurrencyId);
            var retrieveCurrency = await RetrieveCurrency(retrieveCurrencyParameters);
            Account account = new Account()
            {
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
                DeletedBy = null,
                //AccountTypeId = retrieveAccountType.AccountType.AccountTypeId,
                //CurrencyId = retrieveCurrency.Currency.CurrencyId,
                AccountType = retrieveAccountType.AccountType,
                Currency = retrieveCurrency.Currency
            };
            _accountModuleDbContext.Account.Add(account);
            var teste = _accountModuleDbContext.Account.Select(row => row);
            await _accountModuleDbContext.SaveChangesAsync();
            return new CreateAccountResult() { Success = true, Account = account };
        }

        public async Task<RetrieveAccountResult> RetrieveAccount(int? accountId, Guid? accountExternalUid)
        {
            IQueryable<Account> query = _accountModuleDbContext.Account;
            if (accountId != null)
                query = query.AsQueryable().Where(c => c.AccountId == accountId).Include(at => at.AccountType).Include(c => c.Currency);
            if (accountExternalUid != null)
                query = query.AsQueryable().Where(c => c.AccountExternalUid == accountExternalUid).Include(at => at.AccountType).Include(c => c.Currency);

            var result = await query.FirstOrDefaultAsync();
            if (result != null)
                return new RetrieveAccountResult() { Account = result, Success = true };
            else
                return new RetrieveAccountResult() { Account = null, Success = false };
        }
        public async Task<UpdateAccountResult> UpdateAccount(UpdateAccountParameters parameters)
        {
            var account = _accountModuleDbContext.Account.FirstOrDefault(x => x.AccountId == parameters.AccountId);
            if (account != null)
            {
                account.AccountExternalUid = parameters.AccountExternalUid ?? account.AccountExternalUid;
                account.InternalName = parameters.InternalName ?? account.InternalName;
                account.LongDisplayName = parameters.LongDisplayName ?? account.LongDisplayName;
                account.ShortDisplayName = parameters.ShortDisplayName ?? account.ShortDisplayName;
                account.Description = parameters.Description ?? account.Description;
                account.Metadata = parameters.Metadata ?? account.Metadata;
            }
            await _accountModuleDbContext.SaveChangesAsync();
            return new UpdateAccountResult() { Success = true };
        }
        public async Task<DeleteAccountResult> DeleteAccount(DeleteAccountParameters parameters)
        {
            var account = RetrieveAccount(parameters.AccountId, parameters.AccountExternalUid);
            if (account.Result.Success == true)
            {
                var accountDeleted = _accountModuleDbContext.Account.Where(x => x.AccountId == account.Result.Account.AccountId).FirstOrDefault();
                accountDeleted.DeletedAt = DateTime.UtcNow;
                accountDeleted.DeletedBy = parameters.DeletedBy;
                await _accountModuleDbContext.SaveChangesAsync();
                return new DeleteAccountResult() { Success = true };
            }
            else
                return new DeleteAccountResult() { Success = false };
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

            var result = await query.FirstOrDefaultAsync();
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

        public async Task<DeleteAccountTypeResult> DeleteAccountType(DeleteAccountTypeParameters parameters)
        {
            var accountTypeParameters = new RetrieveAccountTypeParameters(accountTypeId: parameters.AccountTypeId);
            var accountType = RetrieveAccountType(accountTypeParameters);
            if (accountType.Result.Success == true)
            {
                var accountTypeDeleted = _accountModuleDbContext.AccountType.Where(x => x.AccountTypeId == accountType.Result.AccountType.AccountTypeId).FirstOrDefault();
                accountTypeDeleted.DeletedAt = DateTime.UtcNow;
                accountTypeDeleted.DeletedBy = parameters.DeletedBy;
                await _accountModuleDbContext.SaveChangesAsync();
                return new DeleteAccountTypeResult() { Success = true };
            }
            else
                return new DeleteAccountTypeResult() { Success = false };
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

            var result = await query.FirstOrDefaultAsync();
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

        public async Task<QueryCurrencyResult> QueryCurrency(QueryCurrencyParameters parameters)
        {
            return new QueryCurrencyResult();
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
                    return new BlockUserBalanceResult() { Success = false, Error = true, ErrorMessage = "Saldo insuficiente" };

                account.Result.Account.CurrentBalance = newBalance;
                account.Result.Account.BalanceBlocked = parameters.Amount;
                await _accountModuleDbContext.SaveChangesAsync();
                return new BlockUserBalanceResult() { Success = true };
            }
            else
                return new BlockUserBalanceResult() { Success = false };
        }
        public async Task<UnblockUserBalanceResult> UnblockUserBalance(UnblockUserBalanceParameters parameters)
        {
            return new UnblockUserBalanceResult();
        }
        public async Task<QueryBalanceResult> QueryBalance(QueryBalanceParameters parameters)
        {
            return new QueryBalanceResult();
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
                    CreateTransaction(accountOne.Result.Account.AccountId, accountOne.Result.Account.AccountExternalUid, accountTwo.Result.Account.AccountExternalUid, accountTwoBalance, TransactionType.Withdraw, accountOneBalance, accountOneNewBalance, null, null, null, null);
                    CreateTransaction(accountTwo.Result.Account.AccountId, accountOne.Result.Account.AccountExternalUid, accountTwo.Result.Account.AccountExternalUid, accountTwoBalance, TransactionType.Deposit, accountOneBalance, accountOneNewBalance, null, null, null, null);
                    accountOne.Result.Account.CurrentBalance = accountOneNewBalance;
                    accountOne.Result.Account.UpdatedAt = DateTime.UtcNow;
                    accountTwo.Result.Account.CurrentBalance = 0;
                    accountTwo.Result.Account.DeletedAt = DateTime.UtcNow;
                    await _accountModuleDbContext.SaveChangesAsync();
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
            // Acho que dá pra refatorar esse método em pequenas funções ( Tipo Crédit(), Debit() )
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
                await _accountModuleDbContext.SaveChangesAsync();
                return new TransferBalanceResult() { Success = true, receiverAccount = receiverAccount.Result.Account, senderAccount = senderAccount.Result.Account };
            }
            else
                return new TransferBalanceResult() { Success = false, ErrorMessage = "Erro ao transferir saldo" };
        }

        private async void CreateTransaction(int accountId, Guid sourceAccountUid, Guid receiverAccountUid,
            decimal amount, TransactionType transactionType, decimal receiverOldBalance, decimal receiverNewBalance, string? internalName, string? longDisplayName, string? shortDisplayName, string? description)
        {
            var transaction = new Transaction()
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
            await _accountModuleDbContext.SaveChangesAsync();
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

        public static void Clear() {}
    }
}
