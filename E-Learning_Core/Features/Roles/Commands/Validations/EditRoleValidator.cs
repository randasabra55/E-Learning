using E_Learning_Core.Features.Roles.Commands.Models;
using FluentValidation;

namespace E_Learning_Core.Features.Roles.Commands.Validations
{
    public class EditCourseValidator : AbstractValidator<EditRoleCommand>
    {
        public EditCourseValidator()
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
                 .NotEmpty().WithMessage("this field must not be empty")
                 .NotNull().WithMessage("this field must not be null");

            RuleFor(x => x.RoleName)
                .NotEmpty().WithMessage("this field must not be empty")
                .NotNull().WithMessage("this field must not be null")
                .MaximumLength(30).WithMessage("max length must not exceeded 30")
                .Must(role => new[] { "Admin", "Student", "Instructor" }.Contains(role))
                .WithMessage("Role must be either 'Admin', 'Student', or 'Instructor'.");

        }

        public void ApplyCustomValidationsRules()
        {

        }

    }

}
