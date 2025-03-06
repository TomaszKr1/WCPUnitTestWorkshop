using Moq;
using Moq.Protected;

namespace MockingExercises.Protected;

public class MyService
{
    public string GetProcessedData() => $"Processed {GetData()}";
    protected virtual string GetData() => "Real Data";
}

public class MyServiceTests
{
    [Fact]
    public void GetProcessedData_ReturnsProcessedMockData()
    {
        // Arrange
        var myServiceMock = new Mock<MyService>();
        // TODO: Setup the mock to return "Mock Data" when GetData is called.

        // Act
        var result = myServiceMock.Object.GetProcessedData();

        // Assert
        Assert.Equal("Processed Mock Data", result);

        // TODO: Verify that the protected method was called once.
    }
}