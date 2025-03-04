namespace UnitTestWorkshop.UnitTests;

public class DriversLicensePointsCalculatorTests
{
    // Requirements:
    // 1. Maximum speed limit is 50 km/h.
    // 2. For each 5 km/h above the speed limit, the driver gets 1 point.
    // 3. Valid speed is between 0 and 300 km/h. If the speed is out of this range, the method should throw an exception.
    
    // Test cases:
    // 1. Speed is 50 km/h. Expected result: 0 points.
    // 2. Speed is 55 km/h. Expected result: 1 point.
    // 3. Speed is 60 km/h. Expected result: 2 points.
    // 6. Speed is 301 km/h. Expected result: exception.
    // 7. Speed is -1 km/h. Expected result: exception.
    // 8. Speed is 0 km/h. Expected result: 0 points. 
    
    
    private readonly DriversLicensePointsCalculator _calculator;

    public DriversLicensePointsCalculatorTests()
    {
        _calculator = new DriversLicensePointsCalculator();
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(50, 0)]
    [InlineData(51, 1)]
    [InlineData(55, 1)]
    [InlineData(56, 2)]
    [InlineData(60, 2)]
    [InlineData(150, 20)]
    [InlineData(300, 50)]
    public void CalculatePoints_SpeedIsInRegularRange_ReturnsPoints(int speed, int expectedPoints)
    {
        var result = _calculator.CalculatePoints(speed);
        Assert.Equal(expectedPoints, result);
    }
    
    [Theory]
    [InlineData(-1)]
    [InlineData(301)]
    public void CalculatePoints_NotInRange_ThrowsException(int speed)
    {
        // Arrange

        // Act
        Action act = () => _calculator.CalculatePoints(speed);
    
        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(act);
    }
 
}