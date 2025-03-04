namespace UnitTestWorkshop.UnitTests;

public class CalculatorTests
{
    // According to the naming convention please rename the class to CalculatorTests
    // Name convention: MethodName_StateUnderTest_ExpectedBehavior
    
    [Fact]
    public void Test1()
    {
        // Arrange
        var calculator = new Calculator();
        int a = 3;
        int b = 5;

        // Act
        int result = calculator.Add(a, b);

        // Assert
        Assert.True(result > 0);
    }
    
    [Fact]
    public void Test2()
    {
        // Arrange
        var calculator = new Calculator();
        int a = 5;
        int b = 5;

        // Act
        int result = calculator.Max(a, b);

        // Assert
        Assert.Equal(5, result);
    }
    
    [Fact]
    public void Test3()
    {
        // Arrange
        var calculator = new Calculator();
        int a = 3;
        int b = 0;

        // Act
        Func<object?> action = () => calculator.Divide(a, b);
        
        // Assert
        Assert.Throws<DivideByZeroException>(action);
    }
}
