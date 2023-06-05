using ExatoDigital.OpenSource.AccountModule.Domain.Models;

namespace ExatoDigital.OpenSource.AccountModule.Domain.Response.CurrencyResult
{
    public class RetrieveCurrencyResult : AccountModuleResult   
    {
        public Currency? Currency { get; set; }

    }
}
