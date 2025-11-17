using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Application.Commands.CreateStudent;
using StudentManagementAPI.Application.Commands.DeleteStudent;
using StudentManagementAPI.Application.Commands.UpdateStudent;
using StudentManagementAPI.Application.Queries.GetAllStudents;
using StudentManagementAPI.Application.Queries.GetStudentById;
using StudentManagementAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // CREATE
    [HttpPost]
    public async Task<IActionResult> Create(CreateStudentCommand command)
    {
        try
        {
            var id = await _mediator.Send(command);
            return Ok(ApiResponse<object>.Ok(
                new { Id = id },
                "Student created successfully"
            ));
        }
        catch (ValidationException ex)
        {
            var errors = ex.Errors.Select(e => e.ErrorMessage).ToList();
            return BadRequest(ApiResponse<object>.Fail("Validation failed", errors));
        }
    }

    // GET ALL
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var students = await _mediator.Send(new GetAllStudentsQuery());
        return Ok(ApiResponse<object>.Ok(students, "Students retrieved successfully"));
    }

    // GET BY ID
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var student = await _mediator.Send(new GetStudentByIdQuery(id));

        if (student == null)
            return NotFound(ApiResponse<string>.Fail($"Student with ID {id} not found"));

        return Ok(ApiResponse<object>.Ok(student, "Student retrieved successfully"));
    }

    // UPDATE
    [HttpPut]
    public async Task<IActionResult> Update(UpdateStudentCommand command)
    {
        try
        {
            var success = await _mediator.Send(command);

            if (!success)
                return NotFound(ApiResponse<string>.Fail("Student not found"));

            return Ok(ApiResponse<string>.Ok("Student updated successfully"));
        }
        catch (ValidationException ex)
        {
            var errors = ex.Errors.Select(e => e.ErrorMessage).ToList();
            return BadRequest(ApiResponse<object>.Fail("Validation failed", errors));
        }
    }

    // DELETE
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _mediator.Send(new DeleteStudentCommand(id));

        if (!success)
            return NotFound(ApiResponse<string>.Fail($"Student with ID {id} not found"));

        return Ok(ApiResponse<string>.Ok("Student deleted successfully"));
    }
}
