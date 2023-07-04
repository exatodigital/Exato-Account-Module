namespace ExatoDigital.OpenSource.AccountModule.Domain.Models
{
    public class AccountType
    {
        public AccountType(int accountTypeId, Guid accountTypeUid, Guid accountTypeExternalUid, int accountTypeClientId, string name, bool negativeBalanceAllowed, bool allowedToExpire, DateTime expireAt, DateTime createdAt, int createdBy, DateTime updatedAt, int updatedBy, DateTime deletedAt, int deletedBy)
        {
            AccountTypeId = accountTypeId;
            AccountTypeUid = accountTypeUid;
            AccountTypeExternalUid = accountTypeExternalUid;
            AccountTypeClientId = accountTypeClientId;
            Name = name;
            NegativeBalanceAllowed = negativeBalanceAllowed;
            AllowedToExpire = allowedToExpire;
            ExpireAt = expireAt;
            CreatedAt = createdAt;
            CreatedBy = createdBy;
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            DeletedAt = deletedAt;
            DeletedBy = deletedBy;
        }

        public AccountType(){}

        public int AccountTypeId { get; set; }
        public Guid AccountTypeUid { get; set; }
        public Guid AccountTypeExternalUid { get; set; }
        public int AccountTypeClientId { get; set; }
        public string Name { get; set; }
        public bool NegativeBalanceAllowed { get; set; }
        public bool AllowedToExpire { get; set; }
        public DateTime ExpireAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime DeletedAt { get; set; }
        public int DeletedBy { get; set; }
        public ICollection<Account>? Accounts { get; set; }
    }
}
