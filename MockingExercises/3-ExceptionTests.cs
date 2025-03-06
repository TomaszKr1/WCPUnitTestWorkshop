using Moq;

namespace MockingExercises.Exceptions;

public interface IDataService
{
    string GetData();
}

public class DataProcessor(IDataService dataService)
{
    public string ProcessData()
    {
        try
        {
            var data = dataService.GetData();
            return data.ToUpper();
        }
        catch (Exception)
        {
            return "ERROR";
        }
    }
}

public class DataProcessorTests
{
    [Fact]
    public void ProcessData_WhenDataServiceThrowsException_ReturnsDefaultValue()
    {
        // Arrange
        var dataServiceMock = new Mock<IDataService>();

        // TODO: Setup the mock to throw an InvalidOperationException when GetData is called.

        var processor = new DataProcessor(dataServiceMock.Object);

        // Act
        var result = processor.ProcessData();

        // Assert
        Assert.Equal("ERROR", result);
    }
}