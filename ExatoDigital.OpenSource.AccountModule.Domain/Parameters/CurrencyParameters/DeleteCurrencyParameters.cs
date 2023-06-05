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
