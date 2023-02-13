using ExatoDigital.OpenSource.AccountModule.Repository.Repositories;
using ExatoDigital.OpenSource.AccountModule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExatoDigital.OpenSource.AccountModule.Repository.PostgreSql.Repositories;
using Microsoft.EntityFrameworkCore;
using ExatoDigital.OpenSource.AccountModule.Domain.Parameters.CurrencyParameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Response.CurrencyResult;
using ExatoDigital.OpenSource.AccountModule.Domain.Parameters.AccountParameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Parameters.AccountTypeParameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Parameters.UserBalanceParameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Response.AccountTypeResult;
using ExatoDigital.OpenSource.AccountModule.Domain.Response.AccountResult;
using ExatoDigital.OpenSource.AccountModule.Domain.Response.UserBalanceResult;


// Para logs: https://net-commons.github.io/common-logging/, https://www.nuget.org/packages/Common.Logging
// Para injeção de dependências: Autofac / Ninject
// Para JSON: Newtonsoft (Json.NET) / Microsoft
// Para testes, talvez seja melhor usar da própria Microsoft

namespace ExatoDigital.OpenSource.AccountModule.Core
{
    public class AccountModuleFacade : IAccountModuleFacade
    {
        private readonly IAccountModuleRepositoryFactory _accountModuleRepositoryFactory;

        /// <param name="accountModuleRepositoryFactory"></param>
        public AccountModuleFacade(IAccountModuleRepositoryFactory accountModuleRepositoryFactory)
        {
            _accountModuleRepositoryFactory = accountModuleRepositoryFactory ?? throw new ArgumentNullException(nameof(accountModuleRepositoryFactory));

        }

        // public abstract class AccountModuleResult (deu sucesso ou não, mensagens de erro e etc., ou seja, tudo o que for comum para todas as operações.) - OK
        // public class CreateAccountResult : AccountModuleResult (o que for específico da operação, por exemplo o id da conta, UID que foi gerado, etc.) - OK
        // public async Task<CreateAccountResult> CreateAccount(CreateAccountParameters parameters) - OK 
        public async Task<CreateAccountResult> CreateAccount(CreateAccountParameters parameters)
        {
            var repository = _accountModuleRepositoryFactory.Create();
            var response = await repository.CreateAccount(parameters);
            return response;
        }
        public async Task<CreateAccountTypeResult> CreateAccountType(CreateAccountTypeParameters parameters)
        {
            var repository = _accountModuleRepositoryFactory.Create();
            var response = await repository.CreateAccountType(parameters);
            return response;
        }
        public async Task<CreateCurrencyResult> CreateCurrency(CreateCurrencyParameters parameters)
        {
            var repository = _accountModuleRepositoryFactory.Create();
            var response = await repository.CreateCurrency(parameters);
            return response;
        }

        public async Task<RetrieveCurrencyResult> RetrieveCurrency(RetrieveCurrencyParameters parameters)
        {
            var repository = _accountModuleRepositoryFactory.Create();
            var response = await repository.RetrieveCurrency(parameters);
            return response;
        }

        public async Task<UpdateCurrencyResult> UpdateCurrency(UpdateCurrencyParameters parameters)
        {
            var repository = _accountModuleRepositoryFactory.Create();
            var response = await repository.UpdateCurrency(parameters);
            return response;
        }
        public async Task<DeleteCurrencyResult> DeleteCurrency(DeleteCurrencyParameters parameters)
        {
            var repository = _accountModuleRepositoryFactory.Create();
            var response = await repository.DeleteCurrency(parameters);
            return response;
        }


        public async Task<BlockUserBalanceResult> BlockUserBalance(BlockUserBalanceParameters parameters)
        {
            var repository = _accountModuleRepositoryFactory.Create();
            await repository.BlockUserBalance(parameters);
            return new BlockUserBalanceResult();
        }

        // AccountModulePrincipal : IPrincipal (https://learn.microsoft.com/en-us/dotnet/api/system.security.principal.iprincipal?view=net-6.0)
        // Thread.CurrentPrincipal (https://learn.microsoft.com/pt-br/dotnet/api/system.threading.thread.currentprincipal?view=net-6.0)

        // Exemplo de parâmetros para Query
        // public class QueryAccountParameters : AccountModuleParameters
        // {
        //      public Guid? AccountId;
        //      public Guid? AccountExternalId;
        //      public string? OnwerId;
        //      public string? RelatedAccountId;
        //      public string? MasterAccountId;
        //      public DateTime? CreatedAtFrom; 
        //      public DateTime? CreatedAtTo;
        //      public DateTime? LastTransactionTimestampFrom;
        //      public DateTime? LastTransactionTimestampTo;
        // }

        // public async Task<CreateCurrencyResult> CreateCurrency(CreateCurrencyParameters parameters)
        // public async Task<RetrieveCurrencyResult> RetrieveCurrency(RetrieveCurrencyParameters parameters)
        // public async Task<UpdateCurrencyResult> UpdateCurrency(UpdateCurrencyParameters parameters)
        // public async Task<DeleteCurrencyResult> DeleteCurrency(DeleteCurrencyParameters parameters)
        // public async Task<QueryCurrencyResult> QueryCurrency(QueryCurrencyParameters parameters)

        // public async Task<CreateAccountTypeResult> CreateAccountType(CreateAccountTypeParameters parameters)
        // public async Task<RetrieveAccountTypeResult> RetrieveAccountType(RetrieveAccountTypeParameters parameters)
        // public async Task<UpdateAccountTypeResult> UpdateAccountType(UpdateAccountTypeParameters parameters)
        // public async Task<DeleteAccountTypeResult> DeleteAccountType(DeleteAccountTypeParameters parameters)
        // public async Task<QueryAccountTypesResult> QueryAccountType(QueryAccountTypeParameters parameters)

        // public async Task<CreateAccountResult> CreateAccount(CreateAccountParameters parameters)
        // public async Task<RetrieveAccountResult> RetrieveAccount(RetrieveAccountParameters parameters)
        // public async Task<UpdateAccountResult> UpdateAccount(UpdateAccountParameters parameters)
        // public async Task<DeleteAccountResult> DeleteAccount(DeleteAccountParameters parameters)
        // public async Task<QueryAccountResult> QueryAccount(QueryAccountParameters parameters)

        // public async Task<TransferCurrencyResult> TransferCurrency(TransferCurrencyParameters parameters)
        // public async Task<QueryBalanceResult> QueryBalance(QueryBalanceParameters parameters)
        // public async Task<QueryStatementResult> QueryStatement(QueryStatementParameters parameters)

        // public async Task<JoinChildrenAccountsResult> JoinChildrenAccounts(JoinChildrenAccountsParameters parameters)
        // public async Task<BlockUserBalanceResult> BlockUserBalance(BlockUserBalanceParameters parameters)
        // public async Task<UnblockUserBalanceResult> UnblockUserBalance(UnblockUserBalanceParameters parameters)

    }
}
