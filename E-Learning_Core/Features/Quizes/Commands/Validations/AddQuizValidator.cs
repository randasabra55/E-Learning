using E_Learning_Core.Features.Quizes.Commands.Models;
using FluentValidation;

namespace E_Learning_Core.Features.Quizes.Commands.Validations
{
    public class AddQuizValidator : AbstractValidator<AddQuizCommand>
    {
        public AddQuizValidator()
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Title)
                 .NotEmpty().WithMessage("this field must not be empty")
                 .NotNull().WithMessage("this field must not be null")
                 .MaximumLength(50).WithMessage("max length must not exceeded 50");

            RuleFor(x => x.CourseId)
                 .NotEmpty().WithMessage("this field must not be empty")
                 .NotNull().WithMessage("this field must not be null");




        }

        public void ApplyCustomValidationsRules()
        {

        }

    }
}
