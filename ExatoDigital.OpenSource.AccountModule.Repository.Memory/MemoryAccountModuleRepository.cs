using ExatoDigital.OpenSource.AccountModule.Domain.Parameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Response;
using ExatoDigital.OpenSource.AccountModule.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExatoDigital.OpenSource.AccountModule.Repository.Memory
{
    public sealed class MemoryAccountModuleRepository : IAccountModuleRepository
    {
        public async Task<CreateAccountResult> CreateAccount(CreateAccountParameters parameters)
        {
            return new CreateAccountResult() { Success = true };
        }

        public async Task<BlockUserBalanceResult> BlockUserBalance(BlockUserBalanceParameters parameters)
        {
            return null;
        }
        public static void Clear() { }
    }
}
