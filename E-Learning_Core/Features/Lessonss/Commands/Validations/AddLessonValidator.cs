using E_Learning_Core.Features.Lessonss.Commands.Models;
using FluentValidation;



namespace E_Learning_Core.Features.Lessonss.Commands.Validations
{
    public class AddLessonValidator : AbstractValidator<AddLessonCommand>
    {
        public AddLessonValidator()
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Title)
                 .NotEmpty().WithMessage("this field must not be empty")
                 .NotNull().WithMessage("this field must not be null")
                 .MaximumLength(100).WithMessage("max length must not exceeded 100");

            RuleFor(x => x.VideoUrl)
                .NotEmpty().WithMessage("this field must not be empty")
                .NotNull().WithMessage("this field must not be null");

            RuleFor(x => x.CourseId)
                 .NotEmpty().WithMessage("this field must not be empty")
                 .NotNull().WithMessage("this field must not be null");

            RuleFor(x => x.Order)
                 .NotEmpty().WithMessage("this field must not be empty")
                 .NotNull().WithMessage("this field must not be null");


        }

        public void ApplyCustomValidationsRules()
        {

        }

    }
}
