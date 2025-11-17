using MediatR;

namespace StudentManagementAPI.Application.Commands.UpdateStudent
{
    public record UpdateStudentCommand(int Id, string FirstName, string LastName, string Email, int Age) : IRequest<bool>;
}
