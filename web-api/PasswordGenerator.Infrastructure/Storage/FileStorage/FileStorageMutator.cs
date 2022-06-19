using Microsoft.Extensions.Configuration;

namespace PasswordGenerator.Infrastructure.Storage.FileStorage;

internal class FileStorageMutator : IFileStorageMutator
{
    private const string FileStoragePathKey = "FileStoragePath";
    private readonly string _filePath;

    public FileStorageMutator(IConfiguration configuration)
    {
        _filePath = configuration.GetRequiredSection(FileStoragePathKey).Value;
    }

    public async Task MutateFile(Func<StreamWriter, Task> fileMutator)
    {
        using StreamWriter file = new(_filePath, append: true);
        await fileMutator(file);
        await file.WriteLineAsync();
    }
}
