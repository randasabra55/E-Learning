using E_Learning_Core.Features.Users.Commands.Models;
using FluentValidation;

namespace E_Learning_Core.Features.Users.Commands.Validations
{
    public class AddUserValidator : AbstractValidator<AddUserCommand>
    {
        public AddUserValidator()
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.FullName)
                 .NotEmpty().WithMessage("this field must not be empty")
                 .NotNull().WithMessage("this field must not be null")
                 .MaximumLength(100).WithMessage("max length must not exceeded 100");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("this field must not be empty")
                .NotNull().WithMessage("this field must not be null")
                .MaximumLength(100).WithMessage("max length must not exceeded 100");

            RuleFor(x => x.Email)
                 .NotEmpty().WithMessage("this field must not be empty")
                 .NotNull().WithMessage("this field must not be null");

            RuleFor(x => x.Password)
                 .NotEmpty().WithMessage("this field must not be empty")
                 .NotNull().WithMessage("this field must not be null");

            /*RuleFor(x => x.Role)
                .NotEmpty().WithMessage("this field must not be empty")
                .NotNull().WithMessage("this field must not be null");


            RuleFor(x => x.Specialization)
                 .NotEmpty().WithMessage("this field must not be empty")
                 .NotNull().WithMessage("this field must not be null")
                 .When(x => x.Role == "Instructor")
                 .WithMessage("Specialization is required for Instructors");

            RuleFor(x => x.YearExperiences)
                 .NotEmpty().WithMessage("this field must not be empty")
                 .NotNull().WithMessage("this field must not be null")
                 .When(x => x.Role == "Instructor")
                 .WithMessage("Experience years is required for Instructors");*/

        }

        public void ApplyCustomValidationsRules()
        {

        }

    }
}
