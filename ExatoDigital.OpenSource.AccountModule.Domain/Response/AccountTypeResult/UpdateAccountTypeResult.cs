using ExatoDigital.OpenSource.AccountModule.Domain.Models;

namespace ExatoDigital.OpenSource.AccountModule.Domain.Response.AccountTypeResult
{
    public class UpdateAccountTypeResult : AccountModuleResult
    {
        public AccountType? AccountType { get; set; }
    }
}
