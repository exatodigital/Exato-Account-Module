using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExatoDigital.OpenSource.AccountModule.Domain.Parameters
{
    public class CreateCurrencyParameters : AccountModuleParameters
    {
        public CreateCurrencyParameters(string internalName, string longDisplayName, string shortDisplayName, string? description, int decimalPrecision, int minValue, int maxValue, string symbol)
        {
            InternalName = internalName;
            LongDisplayName = longDisplayName;
            ShortDisplayName = shortDisplayName;
            Description = description;
            DecimalPrecision = decimalPrecision;
            MinValue = minValue;
            MaxValue = maxValue;
            Symbol = symbol;
        }
        public string InternalName { get; set; }
        public string LongDisplayName { get; set; }
        public string ShortDisplayName { get; set; }
        public string? Description { get; set; }
        public int DecimalPrecision { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public string Symbol { get; set; }
    }
}
