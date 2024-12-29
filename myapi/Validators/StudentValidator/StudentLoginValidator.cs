using FluentValidation;

namespace myapi.Validators.StudentValidator
{
    public class StudentLoginValidator : AbstractValidator<StudentLoginModel>
    {
        public StudentLoginValidator() {
            RuleFor(s => s.UserName).NotNull().WithMessage("Username is required")
                .NotEmpty().WithMessage("Username is required");
            RuleFor(s => s.Password).NotNull().WithMessage("Password is required")
                .NotEmpty().WithMessage("Password is required");
        }
    }
}
