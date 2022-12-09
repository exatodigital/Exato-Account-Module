using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExatoDigital.OpenSource.AccountModule.Repository.Models
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
    }
}
