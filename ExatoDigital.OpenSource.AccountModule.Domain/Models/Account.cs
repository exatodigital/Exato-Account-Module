﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ExatoDigital.OpenSource.AccountModule.Domain.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public int AccountTypeId { get; set; }
        public AccountType? AccountType { get; set; }
        public int CurrencyId { get; set; }
        public Currency? Currency { get; set; }
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
        public ICollection<Transaction>? Transactions { get; set; }
    }
}
