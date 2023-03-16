using ExatoDigital.OpenSource.AccountModule.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExatoDigital.OpenSource.AccountModule.Domain.Parameters.AccountParameters
{
    public class UpdateAccountParameters : AccountModuleParameters
    {
        public UpdateAccountParameters(Account account) 
        {
            Account = account;
        }
        public Account Account { get; set; }
    }
}
