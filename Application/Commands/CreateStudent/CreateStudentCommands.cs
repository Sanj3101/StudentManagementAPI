using MediatR;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Application.Commands.CreateStudent
{
    public record CreateStudentCommand(string FirstName, string LastName, string Email, int Age)
        : IRequest<int>;
}
