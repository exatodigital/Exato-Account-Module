using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExatoDigital.OpenSource.AccountModule.Domain.Parameters
{
    public class CreateAccountParameters : AccountModuleParameters
    {
        public CreateAccountParameters(string id) { }

        #region Propriedades
        public string? id { get; set; }
        #endregion

    }
}
