using E_Learning_Core.Features.QuizEnrollments.Commands.Models;
using FluentValidation;

namespace E_Learning_Core.Features.QuizEnrollments.Commands.Validations
{
    public class EnrollUserInQuizValidator : AbstractValidator<EnrollUserInQuizCommand>
    {
        public EnrollUserInQuizValidator()
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.QuizId)
                 .NotEmpty().WithMessage("this field must not be empty")
                 .NotNull().WithMessage("this field must not be null");

            RuleFor(x => x.UserId)
                 .NotEmpty().WithMessage("this field must not be empty")
                 .NotNull().WithMessage("this field must not be null");

        }

        public void ApplyCustomValidationsRules()
        {

        }

    }
}
