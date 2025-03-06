using Moq;

namespace MockingExercises.StaticTime;

// TODO: Use TimeProvider to refactor GreeterService and its tests.


public class GreeterService
{
    public static string Greet()
    {
        var date = DateTime.Now;
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

        // Act
        var result = GreeterService.Greet();

        // Assert
        Assert.Equal("Good morning", result);
    }

    [Fact]
    public void Greet_ReturnsGoodAfternoon_WhenAfterNoon()
    {
        // Arrange
        // TODO: Setup the mock to return a fixed date and time, either by FakeTimeProvider or Moq

        // Act
        var result = GreeterService.Greet();

        // Assert
        Assert.Equal("Good afternoon", result);
    }

    [Fact]
    public void Greet_ReturnsGoodEvening_WhenAfterEvening()
    {
        // Arrange
        // TODO: Setup the mock to return a fixed date and time, either by FakeTimeProvider or Moq.

        // Act
        var result = GreeterService.Greet();

        // Assert
        Assert.Equal("Good evening", result);
    }
}