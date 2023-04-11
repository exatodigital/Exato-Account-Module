namespace ExatoDigital.OpenSource.AccountModule.Domain.Parameters.AccountParameters
{
    public class UpdateAccountParameters : AccountModuleParameters
    {
        public UpdateAccountParameters
        (
        int accountId,
        Guid? accountExternalUid,
        string? internalName, 
        string? longDisplayName, 
        string? shortDisplayName,
        string? description,
        string? metadata,
        int updatedBy
        ) 
        {
            AccountId = accountId;
            AccountExternalUid = accountExternalUid;
            InternalName = internalName;
            LongDisplayName = longDisplayName;
            ShortDisplayName = shortDisplayName;
            Description = description;
            Metadata = metadata;
            UpdatedBy = updatedBy;
        }
        public int AccountId { get; set; }
        public Guid? AccountExternalUid { get; set; }
        public string? InternalName { get; set; }
        public string? LongDisplayName { get; set; }
        public string? ShortDisplayName { get; set; }
        public string? Description { get; set; }
        public string? Metadata { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }

    }
}
