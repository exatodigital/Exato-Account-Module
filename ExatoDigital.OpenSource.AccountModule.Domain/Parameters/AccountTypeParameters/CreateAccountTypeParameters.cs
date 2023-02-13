using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExatoDigital.OpenSource.AccountModule.Domain.Parameters.AccountTypeParameters
{
    public class CreateAccountTypeParameters
    {
        public CreateAccountTypeParameters(string name, bool? negativeBalanceAllowed = false, bool? allowedToExpire = false, DateTime? expireAt = null)
        {
            Name = name;
            NegativeBalanceAllowed = negativeBalanceAllowed;
            AllowedToExpire = allowedToExpire;
            ExpiredAt = expireAt;
        }
        public string Name { get; set; }
        public bool? NegativeBalanceAllowed { get; set; }
        public bool? AllowedToExpire { get; set; }
        public DateTime? ExpiredAt { get; set; }
    }
}
