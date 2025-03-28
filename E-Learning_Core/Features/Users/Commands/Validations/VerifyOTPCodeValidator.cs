using E_Learning_Core.Features.Users.Commands.Models;
using FluentValidation;

namespace E_Learning_Core.Features.Users.Commands.Validations
{
    public class VerifyOTPCodeValidator : AbstractValidator<VerifyOTPCodeCommand>
    {
        public VerifyOTPCodeValidator()
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Email)
                 .NotEmpty().WithMessage("this field must not be empty")
                 .NotNull().WithMessage("this field must not be null");

            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("this field must not be empty")
                .NotNull().WithMessage("this field must not be null");
        }

        public void ApplyCustomValidationsRules()
        {

        }
    }
}
