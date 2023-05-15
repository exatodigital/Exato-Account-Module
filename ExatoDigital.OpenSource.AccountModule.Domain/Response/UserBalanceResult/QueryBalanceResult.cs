using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExatoDigital.OpenSource.AccountModule.Domain.Response.UserBalanceResult
{
    public class QueryBalanceResult : AccountModuleResult
    {
        public QueryBalanceResult()
        {
        }
        public decimal Balance { get; set; }
    }
}
