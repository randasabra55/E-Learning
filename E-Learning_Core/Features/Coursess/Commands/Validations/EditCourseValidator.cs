using E_Learning_Core.Features.Coursess.Commands.Models;
using E_Learning_Infrastructure.Data;
using E_Learning_Service.Abstracts;
using FluentValidation;

namespace E_Learning_Core.Features.Coursess.Commands.Validations
{
    public class EditCourseValidator : AbstractValidator<EditCourseCommand>
    {
        Context context;
        ICourseService courseService;
        public EditCourseValidator(Context context, ICourseService courseService)
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
            this.context = context;
            this.courseService = courseService;
        }
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Title)
                 .NotEmpty().WithMessage("this field must not be empty")
                 .NotNull().WithMessage("this field must not be null");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("this field must not be empty")
                .NotNull().WithMessage("this field must not be null")
                .MaximumLength(100).WithMessage("max length must not exceeded 100");

        }

        public void ApplyCustomValidationsRules()
        {
            /*RuleFor(x => x.Title)
                .MustAsync(async (model, Key, CancellationToken) => !await courseService.IsTitleExistExcludeSelf(Key, model.Id))
                .WithMessage("this title must be unique");*/
            /* RuleFor(x => x.InstructorId)
                 .MustAsync(async (model, instructorId, cancellationToken) =>
                    {
                        var course = await context.courses.FindAsync(model.Id);
                        if (course == null) return false;

                        return course.InstructorId == instructorId;
                    })
                  .WithMessage("You can only edit courses that you own.");*/
        }


    }
}
