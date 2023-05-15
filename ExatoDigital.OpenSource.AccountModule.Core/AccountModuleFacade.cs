using ExatoDigital.OpenSource.AccountModule.Repository.Repositories;
using ExatoDigital.OpenSource.AccountModule.Domain;
using ExatoDigital.OpenSource.AccountModule.Domain.Parameters.CurrencyParameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Response.CurrencyResult;
using ExatoDigital.OpenSource.AccountModule.Domain.Parameters.AccountParameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Parameters.AccountTypeParameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Parameters.UserBalanceParameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Response.AccountTypeResult;
using ExatoDigital.OpenSource.AccountModule.Domain.Response.AccountResult;
using ExatoDigital.OpenSource.AccountModule.Domain.Response.UserBalanceResult;
using FluentValidation;
using ExatoDigital.OpenSource.AccountModule.Domain.Validations.AccountParametersValidation;
using ExatoDigital.OpenSource.AccountModule.Domain.Models;


// Para logs: https://net-commons.github.io/common-logging/, https://www.nuget.org/packages/Common.Logging
// Para injeção de dependências: Autofac / Ninject
// Para JSON: Newtonsoft (Json.NET) / Microsoft

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
            var validation = new CreateAccountParametersValidator();
            validation.ValidateAndThrow(parameters);

            try
            {
                var repository = _accountModuleRepositoryFactory.Create();

                if (parameters.MasterAccountUid != null)
                {
                    var masterAccountExists = await repository.RetrieveAccount(null, parameters.MasterAccountUid);
                    if (masterAccountExists.Error)
                        return new CreateAccountResult { Success = masterAccountExists.Success, Error = masterAccountExists.Error, ErrorMessage = masterAccountExists.ErrorMessage };
                }
                if (parameters.RelatedAccountUid != null)
                {
                    var relatedAccount = await repository.RetrieveAccount(null, parameters.RelatedAccountUid);
                    if (relatedAccount.Error)
                        return new CreateAccountResult { Success = relatedAccount.Success, Error = relatedAccount.Error, ErrorMessage = relatedAccount.ErrorMessage };
                }

                var retrieveCurrencyParameters = new RetrieveCurrencyParameters(currencyId: parameters.CurrencyId);
                var currency = await repository.RetrieveCurrency(retrieveCurrencyParameters);
                if (currency.Error)
                    return new CreateAccountResult { Success = currency.Success, Error = currency.Error, ErrorMessage = currency.ErrorMessage };

                var retrieveAccountTypeParameters = new RetrieveAccountTypeParameters(accountTypeId: parameters.AccountTypeId);
                var accountType = await repository.RetrieveAccountType(retrieveAccountTypeParameters);
                if (accountType.Error)
                    return new CreateAccountResult { Success = accountType.Success, Error = accountType.Error, ErrorMessage = accountType.ErrorMessage };

                var response = await repository.CreateAccount(parameters);
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        public async Task<RetrieveAccountResult> RetrieveAccount(RetrieveAccountParameters parameters)
        {
            try
            {
                var repository = _accountModuleRepositoryFactory.Create();
                var response = await repository.RetrieveAccount(parameters.AccountId, parameters.AccountExternalUid);
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        public async Task<UpdateAccountResult> UpdateAccount(UpdateAccountParameters parameters)
        {
            try
            {
                var repository = _accountModuleRepositoryFactory.Create();
                var response = await repository.UpdateAccount(parameters);
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<DeleteAccountResult> DeleteAccount(DeleteAccountParameters parameters)
        {
            try
            {
                var repository = _accountModuleRepositoryFactory.Create();
                var response = await repository.DeleteAccount(parameters);
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        public async Task<CreateAccountTypeResult> CreateAccountType(CreateAccountTypeParameters parameters)
        {
            var repository = _accountModuleRepositoryFactory.Create();
            var response = await repository.CreateAccountType(parameters);
            return response;
        }
        public async Task<RetrieveAccountTypeResult> RetrieveAccountType(RetrieveAccountTypeParameters parameters)
        {
            var repository = _accountModuleRepositoryFactory.Create();
            var response = await repository.RetrieveAccountType(parameters);
            return response;
        }
        public async Task<UpdateAccountTypeResult> UpdateAccountType(UpdateAccountTypeParameters parameters)
        {
            var repository = _accountModuleRepositoryFactory.Create();
            var response = await repository.UpdateAccountType(parameters);
            return response;
        }
        public async Task<DeleteAccountTypeResult> DeleteAccountType(DeleteAccountTypeParameters parameters)
        {
            var repository = _accountModuleRepositoryFactory.Create();
            var response = await repository.DeleteAccountType(parameters);
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
            var response = await repository.BlockUserBalance(parameters);
            return response;
        }

        public async Task<UnblockUserBalanceResult> UnblockUserBalance(UnblockUserBalanceParameters parameters)
        {
            var repository = _accountModuleRepositoryFactory.Create();
            var response = await repository.UnblockUserBalance(parameters);
            return response;
        }


        public async Task<QueryBalanceResult> QueryBalance(QueryBalanceParameters parameters)
        {
            var repository = _accountModuleRepositoryFactory.Create();
            var response = await repository.QueryBalance(parameters);
            return response;
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
