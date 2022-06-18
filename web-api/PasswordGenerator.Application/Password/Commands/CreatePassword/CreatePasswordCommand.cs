using MediatR;

namespace PasswordGenerator.Application.Password.Commands.CreatePassword;

public record struct CreatePasswordCommand: IRequest<CreatePasswordResponse>
{
    public string UserId { get; set; }

    public CreatePasswordCommand(string userId)
    {
        UserId = userId;
    }
}
