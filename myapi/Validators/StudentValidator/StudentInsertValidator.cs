using FluentValidation;

namespace myapi.Validators.StudentValidator
{
    public class StudentInsertValidator : AbstractValidator<StudentAddEditModel>
    {
        public StudentInsertValidator()
        {
            RuleFor(student => student.StudentName)
                .NotEmpty().WithMessage("Student name is required.")
                .MaximumLength(100).WithMessage("Student name cannot exceed 100 characters.");

            RuleFor(student => student.StudentPhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches("^\\d{10}$").WithMessage("Phone number must be 10 digits.");

            RuleFor(student => student.StudentEmail)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email address.");

            RuleFor(student => student.StudentDOB)
                .NotEmpty().WithMessage("Date of birth is required.")
                .LessThan(DateTime.Now).WithMessage("Date of birth must be in the past.");

            RuleFor(student => student.StudentGender)
                .NotEmpty().WithMessage("Gender is required.")
                .Must(gender => new[] { "Male", "Female", "Other" }.Contains(gender))
                .WithMessage("Invalid gender value.");

            RuleFor(student => student.StudentEducationStatus)
                .NotEmpty().WithMessage("Education status is required.");

            RuleFor(student => student.EmergencyContactNumber)
                .NotEmpty().WithMessage("Emergency contact number is required.")
                .Matches("^\\d{10}$").WithMessage("Emergency contact number must be 10 digits.");

            RuleFor(student => student.StudentCity)
                .NotEmpty().WithMessage("City is required.");

            RuleFor(student => student.StudentState)
                .NotEmpty().WithMessage("State is required.");

            RuleFor(student => student.StudentCountry)
                .NotEmpty().WithMessage("Country is required.");

            RuleFor(student => student.StudentPincode)
                .NotEmpty().WithMessage("Pincode is required.")
                .Matches("^\\d{6}$").WithMessage("Pincode must be 6 digits.");

            RuleFor(student => student.GuardianName)
                .NotEmpty().WithMessage("Guardian name is required.");

            RuleFor(student => student.GuardianPhoneNumber)
                .NotEmpty().WithMessage("Guardian phone number is required.")
                .Matches("^\\d{10}$").WithMessage("Guardian phone number must be 10 digits.");

            RuleFor(student => student.AdmissionDate)
                .NotEmpty().WithMessage("Admission date is required.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Admission date cannot be in the future.");

            RuleFor(student => student.StudentPassword)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.");

            RuleFor(student => student.RoomID)
                .GreaterThan(0).WithMessage("Room ID must be greater than 0.");

            RuleFor(student => student.HostelID)
                .GreaterThan(0).WithMessage("Hostel ID must be greater than 0.");
        }
    }
}
