using Moq;

namespace MockingExercises.StrictMode;

public interface ICalculator
{
    int Add(int a, int b);
    int Subtract(int a, int b);
}

public class CalculatorService(ICalculator calculator)
{
    public int Sum(int a, int b) => calculator.Add(a, b);
}

public class CalculatorServiceTests
{
    [Fact]
    public void Sum_CallsAddMethod_AndReturnsCorrectResult()
    {
        // Arrange
        // TODO: Change the mock behavior to strict.
        var calculatorMock = new Mock<ICalculator>(MockBehavior.Strict);
        calculatorMock
            .Setup(c => c.Add(It.IsAny<int>(), It.IsAny<int>()))
            .Returns((int a, int b) => a + b);

        var service = new CalculatorService(calculatorMock.Object);

        // Act
        var result = service.Sum(2, 3);

        // Assert
        Assert.Equal(5, result);
        calculatorMock.Verify(c => c.Add(2, 3), Times.Once);
    }

    [Fact]
    public void StrictMock_ThrowsOnUnexpectedCall()
    {
        // Arrange
        // TODO: Change the mock behavior to strict.
        var calculatorMock = new Mock<ICalculator>(MockBehavior.Strict);
        calculatorMock
            .Setup(c => c.Add(It.IsAny<int>(), It.IsAny<int>()))
            .Returns(0);

        // Act & Assert: Calling Subtract, which is not set up, should throw an exception.
        Assert.Throws<MockException>(() => calculatorMock.Object.Subtract(5, 3));
    }
}