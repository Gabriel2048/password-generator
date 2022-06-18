using MediatR;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace PasswordGenerator.Infrastructure.MediatrPipelines;

/// <summary>
/// A Mediatr request pipeline that logs beofre and after completing a request.
/// </summary>
/// <typeparam name="TRequest"></typeparam>
/// <typeparam name="TResponse"></typeparam>
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

        try
        {
            var result = await next();
            stopWatch.Stop();
            _logger.LogInformation($"Handled {requestName} successfully took {stopWatch.Elapsed}.");
            return result;
        }
        catch (ValidationException)
        {
            _logger.LogInformation($"Handling {requestName} failed due to invalid data.");
            throw;
        }
        catch
        {
            _logger.LogInformation($"Handling {requestName} failed due to unhandled error.");
            throw;
        }
    }
}
