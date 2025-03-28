using E_Learning_Core.Features.Certifications.Commands.Models;
using FluentValidation;

namespace E_Learning_Core.Features.Certifications.Commands.Validations
{
    public class AddCertificateValidator : AbstractValidator<AddCertificateCommand>
    {
        public AddCertificateValidator()
        {
            ApplyValidationsRules();
        }
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.CertificateUrl)
                 .NotEmpty().WithMessage("this field must not be empty")
                 .NotNull().WithMessage("this field must not be null");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("this field must not be empty")
                .NotNull().WithMessage("this field must not be null");

            RuleFor(x => x.CourseId)
                .NotEmpty().WithMessage("this field must not be empty")
                .NotNull().WithMessage("this field must not be null");


        }




    }
}
