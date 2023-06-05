using ExatoDigital.OpenSource.AccountModule.Domain.Models;

namespace ExatoDigital.OpenSource.AccountModule.Domain.Parameters.AccountTypeParameters
{
    public class UpdateAccountTypeParameters : AccountModuleParameters
    {
        public UpdateAccountTypeParameters(AccountType accountType)
        {
            AccountType = accountType;
        }
        public AccountType AccountType { get; set; }
    }
}
