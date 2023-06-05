using ExatoDigital.OpenSource.AccountModule.Domain.Models;

namespace ExatoDigital.OpenSource.AccountModule.Domain.Response.AccountTypeResult
{
    public class RetrieveAccountTypeResult : AccountModuleResult
    {
        public AccountType? AccountType { get; set; }

    }
}
