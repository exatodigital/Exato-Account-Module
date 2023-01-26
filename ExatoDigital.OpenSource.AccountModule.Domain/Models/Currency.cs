using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExatoDigital.OpenSource.AccountModule.Domain.Models
{
    public class Currency
    {
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
        public int DeletedBy { get; set; }
        public virtual RealCurrency? RealCurrency { get; set; }
    }
}
