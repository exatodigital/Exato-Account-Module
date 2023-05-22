using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExatoDigital.OpenSource.AccountModule.Domain.Parameters.AccountParameters
{
    public class JoinChildrenAccountsParameters : AccountModuleParameters
    {
        public JoinChildrenAccountsParameters(int accountOneId, int accountTwoId)
        {
            AccountOneId = accountOneId;
            AccountTwoId = accountTwoId;
        }
        public int AccountOneId { get; set; }
        public int AccountTwoId { get; set; }
    }
}
