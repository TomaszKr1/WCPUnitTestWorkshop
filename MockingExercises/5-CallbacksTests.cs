using Moq;

namespace MockingExercises.Callbacks;


public record User (int Id, string Email);

public interface IUserRepository
{
    void UpdateUser(User user);
}

public class UserService(IUserRepository userRepository)
{
    public void ChangeEmail(int userId, string newEmail)
    {
        var user = new User(userId, newEmail);
        userRepository.UpdateUser(user);
    }
}

public class CallbacksTests
{

    [Fact]
    public void ChangeEmail_UpdatesUserWithCurrentTimestamp()
    {
        // Arrange
        var userRepoMock = new Mock<IUserRepository>();
        User capturedUser = null;

        // TODO: Capture the user argument

        var userService = new UserService(userRepoMock.Object);
        var newEmail = "newuser@example.com";

        // Act
        userService.ChangeEmail(1, newEmail);

        // Assert
        Assert.NotNull(capturedUser);
        Assert.Equal(newEmail, capturedUser.Email);
    }
}
