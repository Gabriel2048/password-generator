using System.ComponentModel.DataAnnotations;
using MediatR;

namespace PasswordGenerator.Application.Password.Commands.CreatePassword;

public record CreatePasswordCommand: IRequest<CreatePasswordResponse>
{
    [Required(ErrorMessage = "User's is required")]
    public string UserId { get; set; }

    public CreatePasswordCommand(string userId)
    {
        UserId = userId;
    }
}
