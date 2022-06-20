using MediatR;

namespace PasswordGenerator.Application.Password.Commands.CreatePassword;

internal class CreatePasswordCommandHandler : IRequestHandler<CreatePasswordCommand, CreatePasswordResponse>
{
    private readonly IPasswordRepository _passwordRepository;
    private readonly IPasswordMetadataProvider _metadataProvider;
    private readonly IDateTimeProvider _dateTimeProvider;

    public CreatePasswordCommandHandler(
        IPasswordRepository passwordRepository,
        IPasswordMetadataProvider metadataProvider,
        IDateTimeProvider dateTimeProvider)
    {
        _passwordRepository = passwordRepository;
        _metadataProvider = metadataProvider;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<CreatePasswordResponse> Handle(CreatePasswordCommand request, CancellationToken cancellationToken)
    {
        var password = Guid.NewGuid().ToString();
        var createdAt = _dateTimeProvider.UtcNow;

        var userPassword = new UserPassword(request.UserId, password, createdAt);

        await _passwordRepository.AddPasswordAsync(userPassword);

        var expirationDate = createdAt.Add(_metadataProvider.ValidDuration);
        return new CreatePasswordResponse(password, expirationDate);
    }
}
