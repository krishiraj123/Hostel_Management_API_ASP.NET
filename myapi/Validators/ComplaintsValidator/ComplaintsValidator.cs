using FluentValidation;
using myapi.Models;

namespace myapi.ComplaintsValidator.ComplaintsValidator
{
    public class ComplaintsValidator : AbstractValidator<ComplaintsModel>
    {
        public ComplaintsValidator()
        {
            // ComplainSubject
            RuleFor(x => x.ComplainSubject)
                .NotEmpty().WithMessage("ComplainSubject is required.")
                .MaximumLength(300).WithMessage("ComplainSubject must not exceed 100 characters.");

            // ComplainBody
            RuleFor(x => x.ComplainBody)
                .NotEmpty().WithMessage("ComplainBody is required.")
                .MaximumLength(500).WithMessage("ComplainBody must not exceed 500 characters.");

            // ComplainStatus
            RuleFor(x => x.ComplainStatus)
                .NotEmpty().WithMessage("ComplainStatus is required.");

            // HostelID
            RuleFor(x => x.HostelID).NotEmpty().NotNull();

            // RoomID
            RuleFor(x => x.RoomID).NotEmpty().NotNull();

            // StudentID
            RuleFor(x => x.StudentID).NotEmpty().NotNull();

            // CreatedAt
            RuleFor(x => x.CreatedAt)
                .NotEmpty().WithMessage("CreatedAt is required.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("CreatedAt cannot be in the future.");

            // UpdatedAt
            RuleFor(x => x.UpdatedAt)
                .NotEmpty().WithMessage("UpdatedAt is required.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("UpdatedAt cannot be in the future.")
                .GreaterThan(x => x.CreatedAt).WithMessage("UpdatedAt must be greater than CreatedAt.");

            // HostelName
            RuleFor(x => x.HostelName)
                .NotEmpty().WithMessage("HostelName is required.");

            // RoomNumber
            RuleFor(x => x.RoomNumber)
                .NotEmpty().WithMessage("RoomNumber is required.");
        }
    }
}


