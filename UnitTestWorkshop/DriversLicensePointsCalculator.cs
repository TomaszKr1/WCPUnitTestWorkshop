namespace UnitTestWorkshop;

public class DriversLicensePointsCalculator
{
    private const int SpeedLimit = 50;
    private const int MaximumSpeed = 300;
    private const int PointsLimit = 24;
    
    public int CalculatePoints(int speed)
    {
        if(speed > MaximumSpeed || speed < 0)
        {
            throw new ArgumentOutOfRangeException($"Speed must be between 0 and {MaximumSpeed}");
        }

        if(speed <= SpeedLimit)
        {
            return 0;
        }

        var points = (speed - SpeedLimit) / 5.0;
        var realPoints = (int)Math.Ceiling(points);

        return realPoints;
    }
}