using E_Learning_Core.Features.Certifications.Commands.Models;
using FluentValidation;

namespace E_Learning_Core.Features.Certifications.Commands.Validations
{
    public class EditCertificateValidator : AbstractValidator<EditCertificateCommand>
    {
        public EditCertificateValidator()
        {
            ApplyValidationsRules();
        }
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.CertificateUrl)
                 .NotEmpty().WithMessage("this field must not be empty")
                 .NotNull().WithMessage("this field must not be null");

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("this field must not be empty")
                .NotNull().WithMessage("this field must not be null");




        }




    }
}
