using System.ComponentModel.DataAnnotations.Schema;

namespace ExatoDigital.OpenSource.AccountModule.Domain.Models
{
    public class Currency
    {
        public Currency(Guid currencyUid, Guid currencyExternalUid, int currencyClientId, string internalName, string longDisplayName, string shortDisplayName, string? description, string? additionalMetadata, int decimalPrecision, int minValue, int maxValue, string symbol, DateTime createdAt, int createdBy, DateTime updatedAt, int updatedBy, DateTime deletedAt, int? deletedBy)
        {
            CurrencyUid = currencyUid;
            CurrencyExternalUid = currencyExternalUid;
            CurrencyClientId = currencyClientId;
            InternalName = internalName;
            LongDisplayName = longDisplayName;
            ShortDisplayName = shortDisplayName;
            Description = description;
            AdditionalMetadata = additionalMetadata;
            DecimalPrecision = decimalPrecision;
            MinValue = minValue;
            MaxValue = maxValue;
            Symbol = symbol;
            CreatedAt = createdAt;
            CreatedBy = createdBy;
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            DeletedAt = deletedAt;
            DeletedBy = deletedBy;
        }

        public int CurrencyId { get; set; }
        public Guid CurrencyUid { get; set; }
        public Guid CurrencyExternalUid { get; set; }
        public int CurrencyClientId { get; set; }
        public string InternalName { get; set; }
        public string LongDisplayName { get; set; }
        public string ShortDisplayName { get; set; }
        public string? Description { get; set; }
        [Column(TypeName = "jsonb")]
        public string? AdditionalMetadata { get; set; }
        public int DecimalPrecision { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public string Symbol { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime DeletedAt { get; set; }
        public int? DeletedBy { get; set; }
        public virtual RealCurrency? RealCurrency { get; set; }
        public ICollection<Account>? Accounts{ get; set; }
    }
}
