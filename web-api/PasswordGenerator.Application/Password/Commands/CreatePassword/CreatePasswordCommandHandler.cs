using MediatR;

namespace PasswordGenerator.Application.Password.Commands.CreatePassword;

internal class CreatePasswordCommandHandler : IRequestHandler<CreatePasswordCommand, CreatePasswordResponse>
{
    private readonly IPasswordRepository _passwordRepository;
    private readonly IPasswordMetadataProvider _metadataProvider;

    public CreatePasswordCommandHandler(IPasswordRepository passwordRepository, IPasswordMetadataProvider metadataProvider)
    {
        _passwordRepository = passwordRepository;
        _metadataProvider = metadataProvider;
    }

    public async Task<CreatePasswordResponse> Handle(CreatePasswordCommand request, CancellationToken cancellationToken)
    {
        var password = Guid.NewGuid().ToString();
        var createdAt = DateTimeOffset.UtcNow;

        var userPassword = new UserPassword(request.UserId, password, createdAt);

        await _passwordRepository.AddPassword(userPassword);

        var expirationDate = createdAt.Add(_metadataProvider.ValidDuration);
        return new CreatePasswordResponse(password, expirationDate);
    }
}
