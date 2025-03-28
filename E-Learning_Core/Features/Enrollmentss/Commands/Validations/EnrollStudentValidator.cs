using E_Learning_Core.Features.Enrollmentss.Commands.Models;
using FluentValidation;

namespace E_Learning_Core.Features.Enrollmentss.Commands.Validations
{
    public class EnrollStudentValidator : AbstractValidator<EnrollStudentCommand>
    {
        public EnrollStudentValidator()
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.UserId)
                 .NotEmpty().WithMessage("this field must not be empty")
                 .NotNull().WithMessage("this field must not be null");

            RuleFor(x => x.CourseId)
                .NotEmpty().WithMessage("this field must not be empty")
                .NotNull().WithMessage("this field must not be null");



        }

        public void ApplyCustomValidationsRules()
        {

        }


    }
}
