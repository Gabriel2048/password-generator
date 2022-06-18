using Microsoft.Extensions.DependencyInjection;
using PasswordGenerator.Application;

namespace PasswordGenerator.Infrastructure
{
    public static class IServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IPasswordMetadataProvider, AppSettingsPasswordMetadataProvider>();
        }
    }
}