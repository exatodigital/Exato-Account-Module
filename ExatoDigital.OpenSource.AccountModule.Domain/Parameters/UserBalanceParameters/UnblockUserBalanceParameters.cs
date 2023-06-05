namespace ExatoDigital.OpenSource.AccountModule.Domain.Parameters.UserBalanceParameters
{
    public class UnblockUserBalanceParameters : AccountModuleParameters
    {
        public UnblockUserBalanceParameters(int accountId, decimal amountToUnblock)
        {
            AccountId = accountId;
            AmountToUnblock = amountToUnblock;
        }
        public int AccountId { get; set; }
        public decimal AmountToUnblock { get; set; }
    }
}
