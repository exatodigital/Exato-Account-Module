using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExatoDigital.OpenSource.AccountModule.Domain.Parameters.UserBalanceParameters
{
    public class TransferBalanceParameters : AccountModuleParameters
    {
        public TransferBalanceParameters(int accountOneId, int accountTwoId, decimal amount)
        {
            AccountOneId = accountOneId;
            AccountTwoId = accountTwoId;
            Amount = amount;
        }
        public int AccountOneId { get; set; }
        public int AccountTwoId { get; set; }
        public decimal Amount { get; set; }
    }
}
