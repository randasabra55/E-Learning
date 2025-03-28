using E_Learning_Core.Features.Answers.Commands.Models;
using FluentValidation;

namespace E_Learning_Core.Features.Answers.Commands.Validations
{
    public class AddAnswerValidator : AbstractValidator<AddAnswerCommand>
    {
        public AddAnswerValidator()
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Answers)
                .NotEmpty().WithMessage("At least one answer is required")
                .NotNull().WithMessage("Answers list must not be null");

            RuleForEach(x => x.Answers).SetValidator(new AnswerDtoValidator());

            RuleFor(x => x.QuestionId)
                .NotEmpty().WithMessage("this field must not be empty")
                .NotNull().WithMessage("this field must not be null");

            /*RuleFor(x => x.IsCorrect)
                .Must(x => x == true || x == false)
                .WithMessage("Invalid boolean value");*/
            // .NotEmpty().WithMessage("this field must not be empty")
            // .NotNull().WithMessage("this field must not be null");

        }

        public void ApplyCustomValidationsRules()
        {

        }



    }

    public class AnswerDtoValidator : AbstractValidator<AnswerDto>
    {
        public AnswerDtoValidator()
        {
            RuleFor(x => x.AnswerText)
                .NotEmpty().WithMessage("Answer text must not be empty")
                .NotNull().WithMessage("Answer text must not be null");

            RuleFor(x => x.IsCorrect)
                .Must(x => x == true || x == false)
                .WithMessage("Invalid boolean value");
        }
    }
}
