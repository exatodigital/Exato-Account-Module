using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExatoDigital.OpenSource.AccountModule.Domain.Parameters.AccountParameters
{
    public class DeleteAccountParameters : AccountModuleParameters
    {
        public DeleteAccountParameters(int accountId, Guid accountExternalUid, int deletedBy)
        {
            AccountId = accountId;
            AccountExternalUid = accountExternalUid;
            DeletedBy = deletedBy;
        }

        public int AccountId { get; set; }
        public int DeletedBy { get; set; }
        public Guid AccountExternalUid { get; set; }

    }
}
