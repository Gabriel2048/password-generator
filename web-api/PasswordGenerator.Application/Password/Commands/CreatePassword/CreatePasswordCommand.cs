using MediatR;
using System.ComponentModel.DataAnnotations;

namespace PasswordGenerator.Application.Password.Commands.CreatePassword;

public record CreatePasswordCommand: IRequest<CreatePasswordResponse>
{
    [Required]
    public string UserId { get; set; }

    public CreatePasswordCommand(string userId)
    {
        UserId = userId;
    }
}
