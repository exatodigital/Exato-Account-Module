using ExatoDigital.OpenSource.AccountModule.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExatoDigital.OpenSource.AccountModule.Domain.Response.AccountTypeResult
{
    public class RetrieveAccountTypeResult : AccountModuleResult
    {
        public AccountType? AccountType { get; set; }

    }
}
