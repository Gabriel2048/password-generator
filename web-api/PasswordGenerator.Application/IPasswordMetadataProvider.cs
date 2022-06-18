namespace PasswordGenerator.Application;

public interface IPasswordMetadataProvider
{
    public TimeSpan ValidDuration { get; }
}