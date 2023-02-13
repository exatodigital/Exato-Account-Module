using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExatoDigital.OpenSource.AccountModule.Domain.Parameters.CurrencyParameters
{
    public class DeleteCurrencyParameters : AccountModuleParameters
    {
        public DeleteCurrencyParameters(int currencyId, int? deletedBy) 
        {
            CurrencyId = currencyId;
            DeletedBy = deletedBy;
        }
        public int CurrencyId { get; set; }
        public int? DeletedBy { get; set; }
    }
}
