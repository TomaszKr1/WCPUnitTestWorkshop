
namespace UnitTestWorkshop.UnitTests;

public class CalculatorTests
{
    [Theory]
    [InlineData(3, 5, 8)]
    [InlineData(3, 0, 3)]
    [InlineData(0, 5, 5)]
    public void Add_WhenCalled_ReturnsSumOfArguments(int a, int b, int expected)
    {
        // Arrange
        var calculator = new Calculator();

        // Act
        int result = calculator.Add(a, b);

        // Assert
        Assert.Equal(expected, result);
    }
        
    [Theory]
    //[MemberData(nameof(Max_SecondArgumentIsGreater_Data))]
    //[ClassData(typeof(MaxSecondArgumentIsGreaterDataGenerator))]
    [ClassData(typeof(MaxSecondArgumentIsGreaterDataGeneratorObject))]
    public void Max_SecondArgumentIsGreater_ReturnsSecondArgument(int firstNumber, int secondNumber, int expected)
    {
        // Arrange
        var calculator = new Calculator();

        // Act
        int result = calculator.Max(firstNumber, secondNumber);

        // Assert
        Assert.Equal(expected, result);
    }


    public static IEnumerable<TheoryDataRow<int, int, int>> Max_SecondArgumentIsGreater_Data()
    {
        yield return new TheoryDataRow<int, int, int>(3, 5, 5);
        yield return new TheoryDataRow<int, int, int>(3, 0, 3);
        yield return new TheoryDataRow<int, int, int>(0, 5, 5);
    }
}