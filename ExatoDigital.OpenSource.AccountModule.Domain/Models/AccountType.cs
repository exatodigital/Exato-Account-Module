namespace ExatoDigital.OpenSource.AccountModule.Domain.Models
{
    public class AccountType
    {
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
        public ICollection<Account> Accounts { get; set; }
    }
}
