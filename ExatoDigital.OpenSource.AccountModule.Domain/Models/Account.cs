using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace ExatoDigital.OpenSource.AccountModule.Domain.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public int AccountTypeId { get; set; }
        public int CurrencyId { get; set; }
        public Guid AccountUid { get; set; }
        public Guid AccountExternalUid { get; set; }
        public int? AccountClientId { get; set; }
        public Guid? MasterAccountUid { get; set; }
        public Guid? RelatedAccountUid { get; set; }
        public string InternalName { get; set; }
        public string LongDisplayName { get; set; }
        public string ShortDisplayName { get; set; }
        public string? Description { get; set; }
        [Column(TypeName = "jsonb")]
        public string? Metadata { get; set; }
        public string? Owner { get; set; }
        public decimal CurrentBalance { get; set; }
        public decimal BalanceBlocked { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? DeletedBy { get; set; }
        public virtual AccountType? AccountType { get; set; }
        public virtual Currency? Currency { get; set; }
        public ICollection<Transaction>? Transactions { get; set; }
    }
}
