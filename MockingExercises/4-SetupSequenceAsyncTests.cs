using Moq;

namespace MockingExercises.SetupSequence;

public interface IRetryService
{
    string GetData();
}

public class DataConsumer(IRetryService service)
{

    public string FetchDataWithRetry()
    {
        // Attempt to get data up to 3 times.
        for (int i = 0; i < 3; i++)
        {
            try
            {
                var data = service.GetData();
                if (!string.IsNullOrEmpty(data))
                {
                    return data;
                }
            }
            catch
            {
            }
        }
        return null;
    }
}

public class SetupSequenceTests
{
    [Fact]
    public void FetchDataWithRetry_ReturnsDataWhenAvailable()
    {
        // Arrange
        var mockService = new Mock<IRetryService>();

        // TODO: Setup a sequence: first call throws an exception, second call returns empty string, third returns valid data.

        var consumer = new DataConsumer(mockService.Object);

        // Act
        var result = consumer.FetchDataWithRetry();

        // Assert
        Assert.Equal("Success", result);
    }
}
