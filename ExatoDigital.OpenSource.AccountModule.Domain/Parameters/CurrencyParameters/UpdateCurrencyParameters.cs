using ExatoDigital.OpenSource.AccountModule.Domain.Models;

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
