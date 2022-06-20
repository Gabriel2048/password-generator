using PasswordGenerator.Application;

namespace PasswordGenerator.Infrastructure;

internal class SystemDateTimeProvider : IDateTimeProvider
{
    public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
}
