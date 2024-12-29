using FluentValidation;
using myapi.Models;

namespace myapi.ComplaintsValidator.ComplaintsValidator
{
    public class ComplaintInsertValidator : AbstractValidator<ComplainAddEditModel>
    {
        public ComplaintInsertValidator()
        {
            // StudentID
            RuleFor(x => x.StudentID).NotEmpty().NotNull();

            // HostelID
            RuleFor(x => x.HostelID).NotEmpty().NotNull();

            // RoomID
            RuleFor(x => x.RoomID).NotEmpty().NotNull();

            // ComplainSubject
            RuleFor(x => x.ComplainSubject)
                .NotEmpty().WithMessage("ComplainSubject is required.")
                .MaximumLength(100).WithMessage("ComplainSubject must not exceed 100 characters.");

            // ComplainBody
            RuleFor(x => x.ComplainBody)
                .NotEmpty().WithMessage("ComplainBody is required.")
                .MaximumLength(500).WithMessage("ComplainBody must not exceed 500 characters.");
        }
    }
}
