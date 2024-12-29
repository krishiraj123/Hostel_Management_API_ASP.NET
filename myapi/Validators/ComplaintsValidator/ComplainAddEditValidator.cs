using FluentValidation;
using myapi.Models;

namespace myapi.ComplaintsValidator
{
    public class ComplainAddEditValidator : AbstractValidator<ComplainAddEditModel>
    {
        public ComplainAddEditValidator()
        {
            RuleFor(c => c.ComplainID)
                .GreaterThanOrEqualTo(0)
                .When(c => c.ComplainID.HasValue)
                .WithMessage("ComplainID is Required");

            RuleFor(c => c.StudentID)
                .NotEmpty()
                .WithMessage("StudentID is required");

            RuleFor(c => c.HostelID)
                .NotEmpty()
                .WithMessage("HostelID is required");

            RuleFor(c => c.RoomID)
                .NotEmpty()
                .WithMessage("RoomID is required");

            RuleFor(c => c.ComplainSubject)
                .NotEmpty()
                .WithMessage("Complain Subject is required.")
                .MaximumLength(300)
                .WithMessage("Complain Subject cannot exceed 300 characters.");

            RuleFor(c => c.ComplainBody)
                .NotEmpty()
                .WithMessage("Complain Body is required.")
                .MaximumLength(500)
                .WithMessage("Complain Body cannot exceed 500 characters.");
        }
    }
}
