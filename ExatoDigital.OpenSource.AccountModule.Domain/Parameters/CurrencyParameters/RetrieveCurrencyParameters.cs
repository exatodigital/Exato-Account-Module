using ExatoDigital.OpenSource.AccountModule.Domain.Response;

namespace ExatoDigital.OpenSource.AccountModule.Domain.Parameters.CurrencyParameters
{
    public class RetrieveCurrencyParameters : AccountModuleResult
    {
        public RetrieveCurrencyParameters(int currencyId)
        {
            CurrencyId = currencyId;
        }
        public RetrieveCurrencyParameters(Guid currencyExternalUid)
        {
            CurrencyExternalUid = currencyExternalUid;
        }
        public RetrieveCurrencyParameters(string internalName)
        {
            InternalName = internalName;
        }

        public int? CurrencyId { get; set; }
        public Guid? CurrencyExternalUid { get; set;}
        public string? InternalName { get; set; }

    }
}
