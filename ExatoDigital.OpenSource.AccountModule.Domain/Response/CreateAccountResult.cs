using ExatoDigital.OpenSource.AccountModule.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExatoDigital.OpenSource.AccountModule.Domain.Response
{
    public class CreateAccountResult : AccountModuleResult
    {
        #region Propriedades
        public string? Result {get;set;}
        public Account? Account { get;set;}

        #endregion

    }
}
