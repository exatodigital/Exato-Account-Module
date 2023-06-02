using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        int? CurrencyId { get; set; }
        Guid? CurrencyUid { get; set; }
        Guid? CurrencyExternalUid { get; set; }
        int? CurrencyClientId { get; set; }
        string? InternalName { get; set; }
        string? LongDisplayName { get; set; }
        string? ShortDisplayName { get; set; }
        string? Description { get; set; }
        string? AdditionalMetadata { get; set; }
        int? DecimalPrecision { get; set; }
        int? MinValue { get; set; }
        int? MaxValue { get; set; }
        string? Symbol { get; set; }
        DateTime? CreatedAt { get; set; }
        int? CreatedBy { get; set; }
        DateTime? UpdatedAt { get; set; }
        int? UpdatedBy { get; set; }
        DateTime? DeletedAt { get; set; }
        int? DeletedBy { get; set; }

    }
}
