using PasswordGenerator.Infrastructure.MediatrPipelines;
using System.ComponentModel.DataAnnotations;

namespace Test.Unit.Infrastructure;

public class SelfValidatablePreProcessorTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("   ")]
    public async Task Should_Throw_For_Invalid_Data(string id)
    {
        // Arrange
        var validationPreProcessor = new SelfValidatablePreProcessor<MockCommand>();
        var command = new MockCommand(id);

        // Act + Assert
        await Assert.ThrowsAsync<ValidationException>(async () => await validationPreProcessor.Process(command, CancellationToken.None));
    }

    private class MockCommand
    {
        [Required]
        public string Id { get; set; }

        public MockCommand(string id)
        {
            Id = id;
        }
    }
}