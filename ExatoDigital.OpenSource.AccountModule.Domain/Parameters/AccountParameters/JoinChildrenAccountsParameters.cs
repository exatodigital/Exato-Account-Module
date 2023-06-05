namespace ExatoDigital.OpenSource.AccountModule.Domain.Parameters.AccountParameters
{
    public class JoinChildrenAccountsParameters : AccountModuleParameters
    {
        public JoinChildrenAccountsParameters(int accountOneId, int accountTwoId)
        {
            AccountOneId = accountOneId;
            AccountTwoId = accountTwoId;
        }
        public int AccountOneId { get; set; }
        public int AccountTwoId { get; set; }
    }
}
