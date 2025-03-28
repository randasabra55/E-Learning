using E_Learning_Core.Features.Answers.Commands.Models;
using FluentValidation;


namespace E_Learning_Core.Features.Answers.Commands.Validations
{
    public class EditAnswerValidator : AbstractValidator<EditAnswerCommand>
    {
        public EditAnswerValidator()
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.AnswerText)
                 .NotEmpty().WithMessage("this field must not be empty")
                 .NotNull().WithMessage("this field must not be null");

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("this field must not be empty")
                .NotNull().WithMessage("this field must not be null");

            RuleFor(x => x.IsCorrect)
                .Must(x => x == true || x == false)
                .WithMessage("Invalid boolean value");

        }

        public void ApplyCustomValidationsRules()
        {

        }



    }
}
