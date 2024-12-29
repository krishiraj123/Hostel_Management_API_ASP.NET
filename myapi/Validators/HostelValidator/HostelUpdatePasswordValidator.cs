using FluentValidation;
using myapi.Models;

namespace myapi.HostelValidator
{
    public class HostelUpdatePasswordValidator : AbstractValidator<HostelUpdatePasswordModel>
    {
        public HostelUpdatePasswordValidator()
        {
            RuleFor(h => h.HostelID)
                .NotNull()
                .NotEmpty()
                .WithMessage("Hostel ID is required.");

            RuleFor(h => h.CurrentPassword)
                .NotNull()
                .NotEmpty()
                .WithMessage("Current password is required.");

            RuleFor(h => h.NewPassword)
                .NotNull()
                .NotEmpty()
                .WithMessage("New password is required.");

            RuleFor(h => h.ConfirmPassword)
                .NotNull()
                .NotEmpty()
                .WithMessage("Confirm password is required.")
                .Equal(h => h.NewPassword)
                .WithMessage("Confirm password must match the new password.");
        }
    }
}
