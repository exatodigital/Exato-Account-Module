using ExatoDigital.OpenSource.AccountModule.Domain.Models;

namespace ExatoDigital.OpenSource.AccountModule.Domain.Response.AccountResult
{
    public class UpdateAccountResult : AccountModuleResult
    {
        public Account? Account { get; set; }
    }
}
