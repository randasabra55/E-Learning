using E_Learning_Core.Features.Questions.Commands.Models;
using FluentValidation;


namespace E_Learning_Core.Features.Questions.Commands.Validations
{
    public class AddQuestionValidator : AbstractValidator<AddQuestionCommand>
    {
        public AddQuestionValidator()
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Question)
                 .NotEmpty().WithMessage("this field must not be empty")
                 .NotNull().WithMessage("this field must not be null");

            RuleFor(x => x.QuizId)
                 .NotEmpty().WithMessage("this field must not be empty")
                 .NotNull().WithMessage("this field must not be null");
        }

        public void ApplyCustomValidationsRules()
        {

        }

    }
}
