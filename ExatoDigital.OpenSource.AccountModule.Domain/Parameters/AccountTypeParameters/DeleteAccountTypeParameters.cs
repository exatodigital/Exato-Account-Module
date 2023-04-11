using ExatoDigital.OpenSource.AccountModule.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExatoDigital.OpenSource.AccountModule.Domain.Parameters.AccountTypeParameters
{
    public class DeleteAccountTypeParameters : AccountModuleParameters
    {
        public DeleteAccountTypeParameters(int accountTypeId, Guid accountTypeExternalUid, int deletedBy)
        {
            AccountTypeId = accountTypeId;
            AccountTypeExternalUid = accountTypeExternalUid;    
            DeletedBy = deletedBy;
        }

        public int AccountTypeId { get; set; }
        public Guid AccountTypeExternalUid { get; set; }
        public int DeletedBy { get; set; }
    }
}
