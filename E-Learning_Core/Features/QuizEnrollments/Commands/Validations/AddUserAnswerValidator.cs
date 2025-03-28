using E_Learning_Core.Features.QuizEnrollments.Commands.Models;
using FluentValidation;

namespace E_Learning_Core.Features.QuizEnrollments.Commands.Validations
{
    public class AddUserAnswerValidator : AbstractValidator<AddUserAnswerCommand>
    {
        public AddUserAnswerValidator()
        {
            ApplyValidationsRules();
        }
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.UserQuizAttemptId)
                 .NotEmpty().WithMessage("this field must not be empty")
                 .NotNull().WithMessage("this field must not be null");

            RuleFor(x => x.Answers)
                 .NotEmpty().WithMessage("this field must not be empty")
                 .NotNull().WithMessage("this field must not be null");

            RuleForEach(x => x.Answers).SetValidator(new UserAnswerDtoValidator());
        }

        public class UserAnswerDtoValidator : AbstractValidator<UserAnswerDto>
        {
            public UserAnswerDtoValidator()
            {
                RuleFor(x => x.QuestionId)
                    .GreaterThan(0).WithMessage("QuestionId must be greater than 0");

                RuleFor(x => x.AnswerId)
                    .GreaterThan(0).WithMessage("AnswerId must be greater than 0");
            }
        }

    }
}
