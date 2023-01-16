using ExatoDigital.OpenSource.AccountModule.Domain.Parameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Response;
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

        public Task<BlockUserBalanceResult> BlockUserBalance(BlockUserBalanceParameters parameters);
    }
}
