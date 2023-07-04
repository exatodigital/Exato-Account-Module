namespace ExatoDigital.OpenSource.AccountModule.Domain.Parameters.CurrencyParameters
{
    public class QueryCurrencyParameters : AccountModuleParameters
    {
        public QueryCurrencyParameters(
            int? currencyId,
            Guid? currencyUid,
            Guid? currencyExternalUid,
            int? currencyClientId,
            string? internalName,
            string? longDisplayName,
            string? shortDisplayName,
            string? description,
            string? additionalMetadata,
            int? decimalPrecision,
            int? minValue,
            int? maxValue,
            string? symbol,
            DateTime? createdAt,
            int? createdBy,
            DateTime? updatedAt,
            int? updatedBy,
            DateTime? deletedAt,
            int? deletedBy)
        {
            CurrencyId = currencyId;
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

        public int? CurrencyId { get; set; }
        public Guid? CurrencyUid { get; set; }
        public Guid? CurrencyExternalUid { get; set; }
        public int? CurrencyClientId { get; set; }
        public string? InternalName { get; set; }
        public string? LongDisplayName { get; set; }
        public string? ShortDisplayName { get; set; }
        public string? Description { get; set; }
        public string? AdditionalMetadata { get; set; }
        public int? DecimalPrecision { get; set; }
        public int? MinValue { get; set; }
        public int? MaxValue { get; set; }
        public string? Symbol { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? DeletedBy { get; set; }

    }
}
