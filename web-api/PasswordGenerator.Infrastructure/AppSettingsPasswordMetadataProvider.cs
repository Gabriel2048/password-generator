using Microsoft.Extensions.Configuration;
using PasswordGenerator.Application;

namespace PasswordGenerator.Infrastructure;

internal class AppSettingsPasswordMetadataProvider : IPasswordMetadataProvider
{
    private readonly IConfiguration _configuration;
    private const string PasswordDurationKey = "PasswordDuration";

    public AppSettingsPasswordMetadataProvider(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public TimeSpan ValidDuration => TimeSpan.Parse(_configuration.GetRequiredSection(PasswordDurationKey).Value);
}