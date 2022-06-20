namespace PasswordGenerator.Application.Password;

public interface IPasswordRepository
{
    public Task AddPasswordAsync(UserPassword userPassword);
}
