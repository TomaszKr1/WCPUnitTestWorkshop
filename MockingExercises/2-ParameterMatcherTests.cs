using Moq;

namespace MockingExercises.ParameterMatcher;


public record User(string Email, string Name);
public record Email(string Recipient, string Subject);

public interface IEmailSender
{
    void SendEmail(Email email);
}

public interface IUserRepository
{
    void Add(User user);
    int GetSeats(User user);
}

public class UserRegistrationService(IUserRepository userRepository, IEmailSender emailSender)
{
    public void RegisterUser(User user)
    {
        userRepository.Add(user);

        var welcomeEmail = new Email(
            user.Email,
            GetSubject(user)
        );

        emailSender.SendEmail(welcomeEmail);
    }

    private string GetSubject(User user) => userRepository.GetSeats(user) switch
    {
        > 10 => "Welcome, enterprise user!",
        _ => "Welcome, new user!"
    };
}

public class ParameterMatcherTests
{
    [Fact]
    public void RegisterUser_ValidUser_AddsUserToRepository()
    {
        // Arrange
        var mockUserRepository = new Mock<IUserRepository>();
        var mockEmailSender = new Mock<IEmailSender>();
        var service = new UserRegistrationService(mockUserRepository.Object, mockEmailSender.Object);
        var user = new User("test@example.com", "Test User");

        // Act
        service.RegisterUser(user);

        // Assert
        // TODO: Verify that the Add method was called once with a user that has the expected email and name.
    }

    [Fact]
    public void RegisterUser_ValidUser_SendsWelcomeEmail()
    {
        // Arrange
        var mockRepository = new Mock<IUserRepository>();
        var mockEmailSender = new Mock<IEmailSender>();
        var service = new UserRegistrationService(mockRepository.Object, mockEmailSender.Object);
        var user = new User("test@example.com", "Test User");

        // Act
        service.RegisterUser(user);

        // Assert
        // TODO: Verify that the SendEmail method was called once with an email that has the expected recipient and subject
    }

    [Fact]
    public void RegisterUser_ValidEnterpriseUser_SendsWelcomeEmail()
    {
        // Arrange
        var mockRepository = new Mock<IUserRepository>();

        // TODO: Setup mockRepository to return 20 seats for a user with "test@example.com" email
        
        var mockEmailSender = new Mock<IEmailSender>();
        var service = new UserRegistrationService(mockRepository.Object, mockEmailSender.Object);
        var user = new User("test@example.com", "Test User");

        // Act
        service.RegisterUser(user);

        // Assert
        // TODO: Verify that the SendEmail method was called once with an email that has the expected recipient and subject
    }
}