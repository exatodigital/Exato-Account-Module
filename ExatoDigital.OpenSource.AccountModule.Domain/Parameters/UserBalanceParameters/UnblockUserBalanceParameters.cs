using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExatoDigital.OpenSource.AccountModule.Domain.Parameters.UserBalanceParameters
{
    public class UnblockUserBalanceParameters : AccountModuleParameters
    {
        public UnblockUserBalanceParameters(int accountId, decimal amountToUnblock)
        {
            AccountId = accountId;
            AmountToUnblock = amountToUnblock;
        }
        public int AccountId { get; set; }
        public decimal AmountToUnblock { get; set; }
    }
}
