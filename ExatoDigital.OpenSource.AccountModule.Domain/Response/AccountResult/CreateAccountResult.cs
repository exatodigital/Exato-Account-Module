using ExatoDigital.OpenSource.AccountModule.Domain.Models;

namespace ExatoDigital.OpenSource.AccountModule.Domain.Response.AccountResult
{
    public class CreateAccountResult : AccountModuleResult
    {
        #region Propriedades
        public string? Result { get; set; }
        public Account? Account { get; set; }

        #endregion

    }
}
