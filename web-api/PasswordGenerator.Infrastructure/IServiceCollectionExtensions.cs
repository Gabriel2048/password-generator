using Microsoft.Extensions.DependencyInjection;
using PasswordGenerator.Application;
using PasswordGenerator.Application.Password;
using PasswordGenerator.Infrastructure.Storage.FileStorage;
using PasswordGenerator.Infrastructure.MediatrPipelines;
using PasswordGenerator.Infrastructure.Storage.FileStorage.Repositories;
using MediatR;
using MediatR.Pipeline;

namespace PasswordGenerator.Infrastructure
{
    public static class IServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IPasswordMetadataProvider, AppSettingsPasswordMetadataProvider>();
            services.AddSingleton<IDateTimeProvider, SystemDateTimeProvider>();

            services.AddTransient(typeof(IRequestPreProcessor<>), typeof(SelfValidatablePreProcessor<>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(SelfLoggingPipeline<,>));

            services.AddSingleton<IPasswordRepository, FileStoragePasswordRepository>();
            services.AddSingleton<IFileStorageMutator, FileStorageMutator>();
        }
    }
}