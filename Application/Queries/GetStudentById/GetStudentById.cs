using MediatR;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Application.Queries.GetStudentById
{
    public record GetStudentByIdQuery(int Id) : IRequest<Student?>;
}
