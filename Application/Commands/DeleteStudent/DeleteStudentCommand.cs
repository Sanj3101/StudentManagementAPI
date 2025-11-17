using MediatR;

namespace StudentManagementAPI.Application.Commands.DeleteStudent
{
    public record DeleteStudentCommand(int Id) : IRequest<bool>;
}
