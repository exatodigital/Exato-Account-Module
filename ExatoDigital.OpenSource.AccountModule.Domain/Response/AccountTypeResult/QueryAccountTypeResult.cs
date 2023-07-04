using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExatoDigital.OpenSource.AccountModule.Domain.Models;

namespace ExatoDigital.OpenSource.AccountModule.Domain.Response.AccountTypeResult
{
    public class QueryAccountTypeResult : AccountModuleResult
    {
        public List<AccountType>? AccountTypes { get; set; }
    }
}
