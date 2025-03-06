using Moq;

namespace MockingExercises.StaticTime;

// TODO: Use TimeProvider to refactor GreeterService and its tests.

public class GreeterService(TimeProvider timeProvider)
{
    public string Greet()
    {
        var date = timeProvider.GetUtcNow();
        return date.Hour switch
        {
            < 12 => "Good morning",
            < 18 => "Good afternoon",
            _ => "Good evening"
        };
    }
}

public class GreeterServiceTests
{
    [Fact]
    public void Greet_ReturnsGoodMorning_WhenBeforeNoon()
    {
        // Arrange
        // TODO: Setup the mock to return a fixed date and time, either by FakeTimeProvider or Moq.

        //FakeTimeProvider fake = new();
        //fake.SetUtcNow(new DateTime(2025, 1, 1, 10, 0, 0));

        Mock<TimeProvider> timeProviderMock = new();
        timeProviderMock.Setup(x => x.GetUtcNow()).Returns(new DateTime(2025, 1, 1, 10, 0, 0));

        GreeterService greeterService = new(timeProviderMock.Object);

        // Act
        var result = greeterService.Greet();

        // Assert
        Assert.Equal("Good morning", result);
    }

    [Fact]
    public void Greet_ReturnsGoodAfternoon_WhenAfterNoon()
    {
        // Arrange
        // TODO: Setup the mock to return a fixed date and time, either by FakeTimeProvider or Moq
        Mock<TimeProvider> timeProviderMock = new();
        timeProviderMock.Setup(x => x.GetUtcNow()).Returns(new DateTime(2025, 1, 1, 14, 0, 0));

        GreeterService greeterService = new(timeProviderMock.Object);

        // Act
        var result = greeterService.Greet();

        // Assert
        Assert.Equal("Good afternoon", result);
    }

    [Fact]
    public void Greet_ReturnsGoodEvening_WhenAfterEvening()
    {
        // Arrange
        // TODO: Setup the mock to return a fixed date and time, either by FakeTimeProvider or Moq.
        Mock<TimeProvider> timeProviderMock = new();
        timeProviderMock.Setup(x => x.GetUtcNow()).Returns(new DateTime(2025, 1, 1, 20, 0, 0));

        GreeterService greeterService = new(timeProviderMock.Object);

        // Act
        var result = greeterService.Greet();

        // Assert
        Assert.Equal("Good evening", result);
    }
}