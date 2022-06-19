using Microsoft.Extensions.DependencyInjection;
using PasswordGenerator.Application;
using PasswordGenerator.Application.Password;
using PasswordGenerator.Infrastructure.MediatrPipelines;
using PasswordGenerator.Infrastructure.Storage.FileStorage.Repositories;
using MediatR;
using MediatR.Pipeline;
using PasswordGenerator.Infrastructure.Storage.FileStorage;

namespace PasswordGenerator.Infrastructure
{
    public static class IServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IPasswordMetadataProvider, AppSettingsPasswordMetadataProvider>();

            services.AddTransient(typeof(IRequestPreProcessor<>), typeof(SelfValidatablePreProcessor<>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(SelfLoggingPipeline<,>));

            services.AddSingleton<IPasswordRepository, FileStoragePasswordRepository>();
            services.AddSingleton<IFileStorageMutator, FileStorageMutator>();
        }
    }
}