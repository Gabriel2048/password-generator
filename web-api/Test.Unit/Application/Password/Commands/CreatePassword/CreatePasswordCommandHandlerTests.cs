using PasswordGenerator.Application;
using PasswordGenerator.Application.Password;
using PasswordGenerator.Application.Password.Commands.CreatePassword;
using NSubstitute;

namespace Test.Unit.Application.Password.Commands.CreatePassword;

public class CreatePasswordCommandHandlerTests
{
    private readonly IPasswordRepository _passwordRepo = Substitute.For<IPasswordRepository>();
    private readonly IPasswordMetadataProvider _passwordMetadata = Substitute.For<IPasswordMetadataProvider>();
    private readonly IDateTimeProvider _dateTimeProvider = Substitute.For<IDateTimeProvider>();

    [Fact]
    public async Task Should_Calculate_Expiration_Date()
    {
        // Arrange
        var now = DateTimeOffset.Parse("06/20/2022 12:00:00 +00:00");
        _dateTimeProvider.UtcNow.Returns(now);

        var validDuration = TimeSpan.FromSeconds(30);
        _passwordMetadata.ValidDuration.Returns(validDuration);
        
        var handler = new CreatePasswordCommandHandler(_passwordRepo, _passwordMetadata, _dateTimeProvider);

        // Act
        var result = await handler.Handle(new CreatePasswordCommand("someUser"), CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        await _passwordRepo.Received(1).AddPasswordAsync(Arg.Any<UserPassword>());
        Assert.Equal(now + validDuration, result.ExpiresAt);
    }
}
