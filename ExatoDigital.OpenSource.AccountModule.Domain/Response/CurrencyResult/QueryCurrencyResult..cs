using ExatoDigital.OpenSource.AccountModule.Domain.Models;

namespace ExatoDigital.OpenSource.AccountModule.Domain.Response.CurrencyResult
{
    public class QueryCurrencyResult : AccountModuleResult
    {
        public List<Currency>? Currencies { get; set; }
    }
}
