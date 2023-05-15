using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExatoDigital.OpenSource.AccountModule.Domain.Parameters.UserBalanceParameters
{
    public class QueryBalanceParameters : AccountModuleParameters
    {
        public QueryBalanceParameters(int accountId)
        {
            AccountId = accountId;
        }
        public int AccountId { get; set; }
    }
}
