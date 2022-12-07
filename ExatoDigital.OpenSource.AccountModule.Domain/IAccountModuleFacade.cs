using ExatoDigital.OpenSource.AccountModule.Domain.Parameters;
using ExatoDigital.OpenSource.AccountModule.Domain.Response;
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
    }
}
