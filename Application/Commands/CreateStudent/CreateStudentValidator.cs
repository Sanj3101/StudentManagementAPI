using FluentValidation;
using static StudentManagementAPI.Application.Commands.CreateStudent.CreateStudentCommand;

namespace StudentManagementAPI.Application.Commands.CreateStudent
{
    public class CreateStudentValidator : AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.")
                                     .MinimumLength(2).WithMessage("First name must be at least 2 characters.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required.")
                                    .MinimumLength(2).WithMessage("Last name must be at least 2 characters.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.")
                                 .EmailAddress().WithMessage("Email must be valid.");
            RuleFor(x => x.Age).InclusiveBetween(0, 120).WithMessage("Age must be between 0 and 120.");
        }
    }
}
