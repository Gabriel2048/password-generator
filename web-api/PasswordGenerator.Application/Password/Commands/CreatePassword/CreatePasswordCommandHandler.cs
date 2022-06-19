using MediatR;

namespace PasswordGenerator.Application.Password.Commands.CreatePassword;

internal class CreatePasswordCommandHandler : IRequestHandler<CreatePasswordCommand, CreatePasswordResponse>
{
    private readonly IPasswordRepository _passwordRepository;

    public CreatePasswordCommandHandler(IPasswordRepository passwordRepository)
    {
        _passwordRepository = passwordRepository;
    }

    public async Task<CreatePasswordResponse> Handle(CreatePasswordCommand request, CancellationToken cancellationToken)
    {
        await _passwordRepository.AddPassword(new UserPassword(request.UserId, "pass", DateTimeOffset.Now));

        return new CreatePasswordResponse();
    }
}
