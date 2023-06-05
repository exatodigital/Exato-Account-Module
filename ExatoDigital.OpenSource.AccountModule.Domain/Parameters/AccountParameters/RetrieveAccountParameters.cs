namespace ExatoDigital.OpenSource.AccountModule.Domain.Parameters.AccountParameters
{
    public class RetrieveAccountParameters : AccountModuleParameters
    {
        public RetrieveAccountParameters(int accountId)
        {
            AccountId = accountId;
        }

        public RetrieveAccountParameters(Guid accountExternalUid)
        {
            AccountExternalUid = accountExternalUid;
        }

        public int AccountId { get; set; }
        public Guid AccountExternalUid { get; set; }
    }
}
