using MediatR;

namespace PasswordGenerator.Application.Password.Commands.CreatePassword;

internal class CreatePasswordCommandHandler : IRequestHandler<CreatePasswordCommand, CreatePasswordResponse>
{
    public Task<CreatePasswordResponse> Handle(CreatePasswordCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new CreatePasswordResponse { ExpiresAt = DateTime.UtcNow });
    }
}
