namespace UnitTestWorkshop.UnitTests;

public class CalculatorTests
{
    [Fact]
    public void Add_ShouldReturnSumOfTwoNumbers()
    {
        // Arrange
        var calculator = new Calculator();
        
        // Act
        var result = calculator.Add(1, 2);
        
        // Assert
        Assert.Equal(3, result);
    }
}