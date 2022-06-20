namespace PasswordGenerator.Application;

public interface IDateTimeProvider
{
    DateTimeOffset UtcNow { get; }
}
