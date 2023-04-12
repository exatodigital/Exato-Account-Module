namespace ExatoDigital.OpenSource.AccountModule.Domain.Parameters.UserBalanceParameters
{
    public class BlockUserBalanceParameters
    {
        public BlockUserBalanceParameters(int accountId, decimal amount)
        {
            AccountId = accountId;
            Amount = amount;
        }
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
    }
}