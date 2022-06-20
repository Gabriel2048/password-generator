using System.Text.Json;
using PasswordGenerator.Application.Password;

namespace PasswordGenerator.Infrastructure.Storage.FileStorage.Repositories;

internal class FileStoragePasswordRepository : IPasswordRepository
{
    private readonly IFileStorageMutator _fileStorageMutator;

    public FileStoragePasswordRepository(IFileStorageMutator fileStorageMutator)
    {
        _fileStorageMutator = fileStorageMutator;
    }

    public Task AddPasswordAsync(UserPassword userPassword)
    {
        return _fileStorageMutator.MutateFile(async (fileMutator) =>
        {
            await JsonSerializer.SerializeAsync(fileMutator.BaseStream, userPassword);
        });
    }
}
