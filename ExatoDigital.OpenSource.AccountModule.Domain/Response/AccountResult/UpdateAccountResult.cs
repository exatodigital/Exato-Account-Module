using ExatoDigital.OpenSource.AccountModule.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExatoDigital.OpenSource.AccountModule.Domain.Response.AccountResult
{
    public class UpdateAccountResult : AccountModuleResult
    {
        public Account? Account { get; set; }
    }
}
