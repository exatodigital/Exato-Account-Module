using ExatoDigital.OpenSource.AccountModule.Domain.Parameters.AccountParameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Parameters.AccountTypeParameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Parameters.CurrencyParameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Parameters.UserBalanceParameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Response.AccountResult;
using ExatoDigital.OpenSource.AccountModule.Domain.Response.AccountTypeResult;
using ExatoDigital.OpenSource.AccountModule.Domain.Response.CurrencyResult;
using ExatoDigital.OpenSource.AccountModule.Domain.Response.UserBalanceResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExatoDigital.OpenSource.AccountModule.Repository.Repositories
{
    public interface IAccountModuleRepository
    {
        public Task<CreateAccountResult> CreateAccount(CreateAccountParameters parameters);
        public Task<CreateAccountTypeResult> CreateAccountType(CreateAccountTypeParameters parameters);
        public Task<RetrieveAccountTypeResult> RetrieveAccountType(RetrieveAccountTypeParameters parameters);
        public Task<CreateCurrencyResult> CreateCurrency(CreateCurrencyParameters parameters);
        public Task<RetrieveCurrencyResult> RetrieveCurrency(RetrieveCurrencyParameters parameters);
        public Task<UpdateCurrencyResult> UpdateCurrency(UpdateCurrencyParameters parameters);
        public Task<DeleteCurrencyResult> DeleteCurrency(DeleteCurrencyParameters parameters);
        public Task<BlockUserBalanceResult> BlockUserBalance(BlockUserBalanceParameters parameters);
    }
}
