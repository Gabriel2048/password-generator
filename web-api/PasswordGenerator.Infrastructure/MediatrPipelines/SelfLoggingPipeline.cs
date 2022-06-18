using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace PasswordGenerator.Infrastructure.MediatrPipelines;

internal class SelfLoggingPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ILogger<TRequest> _logger;

    public SelfLoggingPipeline(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        var requestName = request.GetType().Name;

        var stopWatch = new Stopwatch();
        stopWatch.Start();
        _logger.LogInformation($"Handling {requestName}");

        var result = await next();

        stopWatch.Stop();
        _logger.LogInformation($"Handled {requestName} successfully took {stopWatch.Elapsed}");
        return result;
    }
}
