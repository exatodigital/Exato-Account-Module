namespace ExatoDigital.OpenSource.AccountModule.Domain.Parameters.UserBalanceParameters
{
    public class TransferBalanceParameters : AccountModuleParameters
    {
        public TransferBalanceParameters(int senderAccountId, int receiverAccountId, decimal amount)
        {
            SenderAccountId = senderAccountId;
            ReceiverAccountId = receiverAccountId;
            Amount = amount;
        }
        public int SenderAccountId { get; set; }
        public int ReceiverAccountId { get; set; }
        public decimal Amount { get; set; }
    }
}
