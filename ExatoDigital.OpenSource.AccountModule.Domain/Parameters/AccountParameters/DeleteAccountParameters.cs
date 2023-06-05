namespace ExatoDigital.OpenSource.AccountModule.Domain.Parameters.AccountParameters
{
    public class DeleteAccountParameters : AccountModuleParameters
    {
        public DeleteAccountParameters(int accountId, Guid accountExternalUid, int deletedBy)
        {
            AccountId = accountId;
            AccountExternalUid = accountExternalUid;
            DeletedBy = deletedBy;
        }

        public int AccountId { get; set; }
        public int DeletedBy { get; set; }
        public Guid AccountExternalUid { get; set; }

    }
}
