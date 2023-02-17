using ExatoDigital.OpenSource.AccountModule.Domain.Parameters.AccountParameters;
using FluentValidation;

namespace ExatoDigital.OpenSource.AccountModule.Domain.Validations.AccountParametersValidation
{
    public class CreateAccountParametersValidator : AbstractValidator<CreateAccountParameters>
    {
        public CreateAccountParametersValidator()
        {
            RuleFor(createAccountParameters => createAccountParameters.AccountTypeId).NotNull();
            RuleFor(createAccountParameters => createAccountParameters.CurrencyId).NotNull();
            RuleFor(createAccountParameters => createAccountParameters.InternalName).NotNull();
            RuleFor(createAccountParameters => createAccountParameters.ShortDisplayName).NotNull();
            RuleFor(createAccountParameters => createAccountParameters.LongDisplayName).NotNull();
        }
    }
}
