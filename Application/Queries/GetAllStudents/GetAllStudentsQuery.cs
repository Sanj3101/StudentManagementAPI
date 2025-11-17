
using MediatR;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Application.Queries.GetAllStudents
{
    public record GetAllStudentsQuery() : IRequest<IEnumerable<Student>>;
}
