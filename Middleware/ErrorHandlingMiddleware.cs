using FluentValidation;
using StudentManagementAPI.Models;
using System.Net;

namespace StudentManagementAPI.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                var errors = ex.Errors.Select(e => e.ErrorMessage).ToList();
                var response = ApiResponse<string>.Fail("Validation failed", errors);
                await context.Response.WriteAsJsonAsync(response);
            }
            catch (KeyNotFoundException ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                var response = ApiResponse<string>.Fail(ex.Message);
                await context.Response.WriteAsJsonAsync(response);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var response = ApiResponse<string>.Fail("An unexpected error occurred.", new List<string> { ex.Message });
                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
