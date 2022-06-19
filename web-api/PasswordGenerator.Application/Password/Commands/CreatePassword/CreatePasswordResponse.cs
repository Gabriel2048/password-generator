namespace PasswordGenerator.Application.Password.Commands.CreatePassword;

public record CreatePasswordResponse(string Password, DateTimeOffset ExpiresAt);