using E_Learning_Core.Features.Lessonss.Commands.Models;
using E_Learning_Infrastructure.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;


namespace E_Learning_Core.Features.Lessonss.Commands.Validations
{
    public class EditLessonValidator : AbstractValidator<EditLessonCommand>
    {
        private readonly Context _context;

        public EditLessonValidator(Context context)
        {
            _context = context;

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("this field must not be empty")
                 .NotNull().WithMessage("this field must not be null")
                 .MaximumLength(100).WithMessage("max length must not exceeded 100");

            RuleFor(x => x.CourseId)
                .NotEmpty().WithMessage("this field must not be empty")
                 .NotNull().WithMessage("this field must not be null");

            RuleFor(x => x.VideoUrl)
                .NotEmpty().WithMessage("this field must not be empty")
                 .NotNull().WithMessage("this field must not be null");

            RuleFor(x => x.Order)
                .GreaterThan(0).WithMessage("Order must be positive")
                .MustAsync(BeUniqueOrder).WithMessage("The lesson order is already used in the same course, please choose another number.");
        }

        private async Task<bool> BeUniqueOrder(EditLessonCommand command, int order, CancellationToken cancellationToken)
        {
            return !await _context.lessons
                .AnyAsync(l => l.Order == order && l.CourseId == command.CourseId && l.Id != command.Id, cancellationToken);
        }
    }

}
