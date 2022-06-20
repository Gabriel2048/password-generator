using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using PasswordGenerator.Api.Middlewares;

namespace Test.Unit.Api.Middlewares;

public class ValidationErrorHandlerMiddlewareTests
{
    [Fact]
    public async Task Should_Create_BadRequest_Response_For_Validation_Exception()
    {
        // Arrange
        var errorMessage = "Invalid prop";
        DefaultHttpContext mockContext = new();
        Task validationErrorDelegate(HttpContext httpContext)
        {
            throw new ValidationException(errorMessage);
        }

        // Act
        var middlewareInstance = new ValidationErrorMiddleware(validationErrorDelegate);
        await middlewareInstance.Invoke(mockContext);

        // Assert
        Assert.Equal(StatusCodes.Status400BadRequest, mockContext.Response.StatusCode);
    }
}
