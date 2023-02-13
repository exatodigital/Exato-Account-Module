using ExatoDigital.OpenSource.AccountModule.Domain.Parameters.AccountParameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Parameters.AccountTypeParameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Parameters.UserBalanceParameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Response.AccountResult;
using ExatoDigital.OpenSource.AccountModule.Domain.Response.AccountTypeResult;
using ExatoDigital.OpenSource.AccountModule.Domain.Response.UserBalanceResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExatoDigital.OpenSource.AccountModule.Domain
{
    public interface IAccountModuleFacade
    {
        public Task<BlockUserBalanceResult> BlockUserBalance(BlockUserBalanceParameters parameters);
        public Task<CreateAccountResult> CreateAccount(CreateAccountParameters parameters);
        public Task<CreateAccountTypeResult> CreateAccountType(CreateAccountTypeParameters parameters);

    }
}
