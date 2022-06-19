namespace PasswordGenerator.Application.Password;

public record UserPassword
{
    public string UserId { get; init; }

    public string Password { get; init; }

    public DateTimeOffset CreatedAt { get; init; }

    public UserPassword(string userId, string password, DateTimeOffset createdAt)
    {
        UserId = userId;
        Password = password;
        CreatedAt = createdAt;
    }
}
