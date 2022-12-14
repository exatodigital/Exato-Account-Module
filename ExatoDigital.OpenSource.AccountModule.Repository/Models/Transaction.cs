using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExatoDigital.OpenSource.AccountModule.Repository.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public Guid TransactionUid { get; set; }
        public Guid TransactionExternalUid { get; set; }
        public int TransactionClientId { get; set; }
        public string InternalName { get; set; }
        public string LongDisplayName { get; set; }
        public string ShortDisplayName { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "jsonb")]
        public string Metadata { get; set; }
        public int TransactionType { get; set; }
        public decimal Value { get; set; }
        public Guid CurrentAccountUid { get; set; }
        public Guid SourceAccountUid { get; set; }
        public decimal OldBalance { get; set; }
        public decimal NewBalance { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
    }
}
