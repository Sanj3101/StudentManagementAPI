using FluentValidation;

namespace StudentManagementAPI.Application.Queries.GetStudentById
{
    public class GetStudentByIdValidator : AbstractValidator<GetStudentByIdQuery>
    {
        public GetStudentByIdValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Student ID must be greater than 0.");
        }
    }
}
