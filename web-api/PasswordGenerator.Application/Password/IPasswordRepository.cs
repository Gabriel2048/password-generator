namespace PasswordGenerator.Application.Password;

public interface IPasswordRepository
{
    public Task AddPassword(UserPassword userPassword);

    public Task DeleteForUser(string userId);
}
