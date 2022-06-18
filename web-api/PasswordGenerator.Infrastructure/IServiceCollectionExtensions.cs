using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using PasswordGenerator.Application;
using PasswordGenerator.Infrastructure.MediatrPipelines;

namespace PasswordGenerator.Infrastructure
{
    public static class IServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IPasswordMetadataProvider, AppSettingsPasswordMetadataProvider>();
            services.AddTransient(typeof(IRequestPreProcessor<>), typeof(SelfValidatablePreProcessor<>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(SelfLoggingPipeline<,>));
        }
    }
}