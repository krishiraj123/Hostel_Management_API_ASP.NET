using FluentValidation;
using myapi.Models;

namespace myapi.ComplaintsValidator.ComplaintsValidator
{
    public class ComplaintsUpdateValidator : AbstractValidator<ComplainUpdateStatusModel>
    {
        public ComplaintsUpdateValidator()
        {
            RuleFor(c => c.ComplainID)
                .NotNull()
                .WithMessage("ComplainID is required.");

            RuleFor(c => c.ComplainStatus)
            .Must(status => new[] { "Accepted", "Rejected", "Pending", "Completed" }.Contains(status))
            .WithMessage("Invalid Complain Status. Allowed values: Accepted, Rejected, Pending, Completed.");

        }
    }
}
