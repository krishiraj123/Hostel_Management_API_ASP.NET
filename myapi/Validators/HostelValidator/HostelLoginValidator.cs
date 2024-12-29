using FluentValidation;
using myapi.Models;

namespace myapi.HostelValidator
{
    public class HostelLoginValidator : AbstractValidator<HostelLoginModel>
    {
        public HostelLoginValidator()
        {
            RuleFor(h => h.UserName)
                .NotNull().NotEmpty().WithMessage("Valid Username is required.");

            RuleFor(h => h.Password)
                .NotNull().NotEmpty().WithMessage("Valid Password is required.");
        }
    }
}
