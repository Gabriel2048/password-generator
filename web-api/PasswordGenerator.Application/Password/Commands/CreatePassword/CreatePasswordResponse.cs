namespace PasswordGenerator.Application.Password.Commands.CreatePassword;

public record struct CreatePasswordResponse
{
    public DateTime ExpiresAt { get; set; }
}