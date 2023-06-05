namespace ExatoDigital.OpenSource.AccountModule.Domain.Response
{
    public class AccountModuleResult
    {
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
