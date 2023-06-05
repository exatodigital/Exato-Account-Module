namespace ExatoDigital.OpenSource.AccountModule.Domain.Parameters.UserBalanceParameters
{
    public class QueryBalanceParameters : AccountModuleParameters
    {
        public QueryBalanceParameters(int accountId)
        {
            AccountId = accountId;
        }
        public int AccountId { get; set; }
    }
}
