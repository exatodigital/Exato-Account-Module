using ExatoDigital.OpenSource.AccountModule.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExatoDigital.OpenSource.AccountModule.Domain.Parameters.AccountTypeParameters
{
    public class RetrieveAccountTypeParameters : AccountModuleParameters
    {
        public RetrieveAccountTypeParameters(int accountTypeId)
        {
            AccountTypeId = accountTypeId;
        }
        public RetrieveAccountTypeParameters(Guid accountTypeExternalUid)
        {
            AccountTypeExternalUid = accountTypeExternalUid;
        }
        public RetrieveAccountTypeParameters(string name)
        {
            Name = name;
        }

        public int? AccountTypeId { get; set; }
        public Guid? AccountTypeExternalUid { get; set; }
        public string? Name { get; set; }
    }
}
