using ExatoDigital.OpenSource.AccountModule.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExatoDigital.OpenSource.AccountModule.Domain.Parameters.CurrencyParameters
{
    public class UpdateCurrencyParameters : AccountModuleParameters
    {
        public UpdateCurrencyParameters(Currency currency) 
        {
            Currency = currency;
        }
        public Currency Currency { get; set; }
    }
}
