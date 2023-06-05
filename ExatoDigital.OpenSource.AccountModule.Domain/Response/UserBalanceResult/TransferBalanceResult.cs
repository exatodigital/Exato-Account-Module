using ExatoDigital.OpenSource.AccountModule.Domain.Models;

namespace ExatoDigital.OpenSource.AccountModule.Domain.Response.UserBalanceResult
{
    public class TransferBalanceResult : AccountModuleResult
    {
        public Account? ReceiverAccount;
        public Account? SenderAccount;
    }
}
