﻿using ExatoDigital.OpenSource.AccountModule.Domain.Parameters.AccountParameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Parameters.AccountTypeParameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Parameters.CurrencyParameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Parameters.UserBalanceParameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Response.AccountResult;
using ExatoDigital.OpenSource.AccountModule.Domain.Response.AccountTypeResult;
using ExatoDigital.OpenSource.AccountModule.Domain.Response.CurrencyResult;
using ExatoDigital.OpenSource.AccountModule.Domain.Response.UserBalanceResult;

namespace ExatoDigital.OpenSource.AccountModule.Domain
{
    public interface IAccountModuleFacade
    {
        public Task<CreateAccountResult> CreateAccount(CreateAccountParameters parameters);
        public Task<UpdateAccountResult> UpdateAccount(UpdateAccountParameters parameters);
        public Task<CreateAccountTypeResult> CreateAccountType(CreateAccountTypeParameters parameters);
        public Task<RetrieveAccountTypeResult> RetrieveAccountType(RetrieveAccountTypeParameters parameters);
        public Task<UpdateAccountTypeResult> UpdateAccountType(UpdateAccountTypeParameters parameters);
        public Task<CreateCurrencyResult> CreateCurrency(CreateCurrencyParameters parameters);
        public Task<RetrieveCurrencyResult> RetrieveCurrency(RetrieveCurrencyParameters parameters);
        public Task<UpdateCurrencyResult> UpdateCurrency(UpdateCurrencyParameters parameters);
        public Task<DeleteCurrencyResult> DeleteCurrency(DeleteCurrencyParameters parameters);
        public Task<QueryCurrencyResult> QueryCurrency(QueryCurrencyParameters parameters);
        public Task<BlockUserBalanceResult> BlockUserBalance(BlockUserBalanceParameters parameters);
        public Task<UnblockUserBalanceResult> UnblockUserBalance(UnblockUserBalanceParameters parameters);
        public Task<QueryBalanceResult> QueryBalance(QueryBalanceParameters parameters);
        public Task<JoinChildrenAccountsResult> JoinChildrensAccounts(JoinChildrenAccountsParameters parameters);

    }
}
