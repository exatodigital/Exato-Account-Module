namespace ExatoDigital.OpenSource.AccountModule.Domain.Response.UserBalanceResult
{
    public class QueryBalanceResult : AccountModuleResult
    {
        public QueryBalanceResult()
        {
        }
        public decimal Balance { get; set; }
    }
}
