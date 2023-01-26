using ExatoDigital.OpenSource.AccountModule.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExatoDigital.OpenSource.AccountModule.Domain.Parameters
{
    public class CreateAccountParameters : AccountModuleParameters
    {
        public CreateAccountParameters(string internalName, string longDisplayName, string shortDisplayName, string? description, string? owner, decimal balance, Guid? masterAccountUid, Guid? relatedAccountUid, int currencyId, int accountTypeId)
        {
            InternalName = internalName;
            LongDisplayName = longDisplayName;
            ShortDisplayName = shortDisplayName;
            Description = description;
            Owner = owner;
            Balance = balance;
            MasterAccountUid = masterAccountUid;
            RelatedAccountUid = relatedAccountUid;
            CurrencyId = currencyId;
            AccountTypeId = accountTypeId;
        }

        #region Propriedades

        public string InternalName { get; set; }
        public string LongDisplayName { get; set; }
        public string ShortDisplayName { get; set; }
        public string? Description { get; set; }
        public string? Owner { get; set; }
        public decimal Balance { get; set; }
        public Guid? MasterAccountUid { get; set; }
        public Guid? RelatedAccountUid { get; set; }
        public int CurrencyId { get; set; }
        public int AccountTypeId { get; set;}
    
        #endregion

    }
}
