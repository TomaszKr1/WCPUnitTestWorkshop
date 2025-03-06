
using FakeItEasy;
using Moq;
using NSubstitute;

namespace MockingExercises.CompareTools;

public interface IEmailService
{
    void SendEmail(string recipient, string message);
    void SomeOtherMethod(string recipient, string message);
    Task<bool> SendEmailAsync(string recipient, string message);
}

public class NotificationService(IEmailService emailService)
{
    public void NotifyUser(string user, string message) =>
        emailService.SendEmail(user, message);
}

public class CompareToolsTests
{
    class MockEmailService(string expectedReceipent, string expectedMessage) : IEmailService
    {
        public int Counter { get; private set; }
        public bool ParametersAsExpected { get; private set; }

        public void SendEmail(string recipient, string message)
        {
            Counter++;
            ParametersAsExpected = recipient == expectedReceipent && message == expectedMessage;
        }

        // other methods required if interface has more
        public Task<bool> SendEmailAsync(string recipient, string message)
        {
            throw new NotImplementedException();
        }

        public void SomeOtherMethod(string recipient, string message)
        {
            throw new NotImplementedException();
        }
    }


    [Fact]
    public void NONE_NotifyUser_Should_Call_SendEmail()
    {
        // Arrange
        var mockEmailService = new MockEmailService("user@example.com", "Hello!");
        var notificationService = new NotificationService(mockEmailService);

        // Act
        notificationService.NotifyUser("user@example.com", "Hello!");

        // Assert
        Assert.Equal(1, mockEmailService.Counter);
        Assert.True(mockEmailService.ParametersAsExpected);
    }

    [Fact]
    public void MOQ_NotifyUser_Should_Call_SendEmail()
    {
        // Arrange
        var mockEmailService = new Mock<IEmailService>();
        var notificationService = new NotificationService(mockEmailService.Object);

        // Act
        notificationService.NotifyUser("user@example.com", "Hello!");

        // Assert
        // TODO: Verify that the SendEmail method was called once with the expected recipient and messag using Moq.
        mockEmailService.Verify(x => x.SendEmail("user@example.com", "Hello!"), Moq.Times.Once);
    }

    [Fact]
    public void NSubstitute_NotifyUser_Should_Call_SendEmail()
    {
        // Arrange
        var emailService = Substitute.For<IEmailService>();
        var notificationService = new NotificationService(emailService);

        // Act
        notificationService.NotifyUser("user@example.com", "Hello!");

        // Assert
        // TODO: Verify that the SendEmail method was called once with the expected recipient and messag using NSubstitute.
        emailService.Received(1).SendEmail("user@example.com", "Hello!");
    }

    [Fact]
    public void FakeItEasy_NotifyUser_Should_Call_SendEmail()
    {
        // Arrange
        var emailService = A.Fake<IEmailService>();
        var notificationService = new NotificationService(emailService);

        // Act
        notificationService.NotifyUser("user@example.com", "Hello!");

        // Assert
        // TODO: Verify that the SendEmail method was called once with the expected recipient and messag using FakeItEasy.
        A.CallTo(() => emailService.SendEmail("user@example.com", "Hello!"))
            .MustHaveHappenedOnceExactly();
    }
}
