namespace PasswordGenerator.Infrastructure.Storage.FileStorage;

internal interface IFileStorageMutator
{
    Task MutateFile(Func<StreamWriter, Task> fileMutator);
}
