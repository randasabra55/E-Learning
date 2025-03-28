using E_Learning_Core.Features.Coursess.Commands.Models;
using E_Learning_Infrastructure.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_Core.Features.Coursess.Commands.Validations
{
    public class AddCourseValidator : AbstractValidator<AddCourseCommand>
    {
        Context context;
        public AddCourseValidator(Context context)
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
            this.context = context;
        }
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Title)
                 .NotEmpty().WithMessage("this field must not be empty")
                 .NotNull().WithMessage("this field must not be null");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("this field must not be empty")
                .NotNull().WithMessage("this field must not be null")
                .MaximumLength(30).WithMessage("max length must not exceeded 30");



        }

        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.Title)
                .MustAsync(IsUniqueTitle).WithMessage("Course title must be unique.");
        }

        private async Task<bool> IsUniqueTitle(string title, CancellationToken cancellationToken)
        {
            return !await context.courses.AnyAsync(c => c.Title == title, cancellationToken);
        }
    }
}
