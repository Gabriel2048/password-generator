using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace PasswordGenerator.Application;

public static class IServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
    }
}
